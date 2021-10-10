using System;
using Dex.Tweaker.Util;
using System.Collections.Generic;
using UnityEngine;
using LevelGeneration;
using Player;
using AK;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Core
{
    class GamerGlowstick : ConfigBaseSingle<GamerGlowstick.Data>
    {
        public class Data : DataBase
        {
            public uint ItemID { get; set; } = 130U;
            public float PulseRate { get; set; } = 1f;
            public RGB Max { get; set; } = new(0.8f, 0.8f, 0.8f);
            public RGB Min { get; set; } = new(0.4f, 0.4f, 0.4f);
            public bool ToggleLevelLight { get; set; } = true;
        }
        class Light
        {
            public static LG_LightCollection collection { get; set; }
            public static bool turnOff { get; set; }
        }
        public class Setting
        {
            public Color color { get; set; }
            public Color target { get; set; }
            public float time { get; set; }
        }

        public bool Exist(int instanceID, Item item)
        {
            if (this.Config.internalEnabled && item.ItemDataBlock.persistentID == this.Config.ItemID)
            {
                notUsed = false;
            }
            else
            {
                notUsed = true;
                return false;
            }
            if (lookup == null) lookup = new();
            if (lookup.Count == 0) // First thrown
            {
                if (PlayerManager.TryGetLocalPlayerAgent(out PlayerAgent agent))
                {
                    Light.collection = LG_LightCollection.Create(agent.CourseNode, agent.Position, LG_LightCollectionSorting.Distance, 100f);
                }
                isActive = true;
                Light.turnOff = true;
            }
            if (lookup.ContainsKey(instanceID))
            {
                this.Update(instanceID);
                currentID = instanceID;
                return true;
            }
            else
            {
                lookup.Add(instanceID, new());
                return false;
            }
        }

        public void Update(int instanceID)
        {
            if (lookup[instanceID].time <= Time.deltaTime)
            {
                lookup[instanceID].color  = lookup[instanceID].target;
                lookup[instanceID].target = new(this.newRed, this.newGreen, this.newBlue);
                lookup[instanceID].time  += this.Config.PulseRate;
            }
            else
            {
                lookup[instanceID].color = Color.Lerp(lookup[instanceID].color, lookup[instanceID].target, Time.deltaTime / lookup[instanceID].time);
                lookup[instanceID].time -= Time.deltaTime;
            }
        }

        public void Update(GlowstickInstance instance)
        {
            if (!this.Config.internalEnabled) return;
            if (instance == null) return;
            if (!instance.m_hasLight) return;
            if (this.Exist(instance.GetInstanceID(), instance.GetItem()))
            {
                instance.m_light.SetColor(this.lookup[this.currentID].color);
                instance.m_light.UpdateData();
            }
        }

        public void TurnOffLights(ref Collision col)
        {
            if (!this.Config.internalEnabled) return;
            if (notUsed) return;
            if (isActive)
            {
                if (Light.turnOff)
                {
                    Light.collection.SetMode(false);
                    Light.turnOff = false;
                    cellSoundNum = CellSound.Post(EVENTS.LIGHTS_OFF_GLOBAL, col.transform.position);
                }
            }
        }

        public void Despawn(int instanceID, UnityEngine.Vector3 position)
        {
            if (!this.Config.internalEnabled) return;
            if (notUsed) return;
            if (lookup.TryGetValue(instanceID, out _))
            {
                lookup.Remove(instanceID);
            }
            if (lookup.Count < 1)
            {
                if (isActive)
                {
                    Light.collection.SetMode(true);
                    isActive = false;
                    cellSoundNum = CellSound.Post(EVENTS.LIGHTS_ON_INTENSITY_4, position);
                }
            }
        }
        public float newRed => this.Config.Min.Red + (UnityEngine.Random.value * (this.Config.Max.Red - this.Config.Min.Red));
        public float newGreen => this.Config.Min.Green + (UnityEngine.Random.value * (this.Config.Max.Green - this.Config.Min.Green));
        public float newBlue => this.Config.Min.Blue + (UnityEngine.Random.value * (this.Config.Max.Blue - this.Config.Min.Blue));
        public CellSoundPlayer m_sound { get; set; }
        public Dictionary<int, Setting> lookup { get; set; }
        static bool isActive { get; set; }
        static bool notUsed { get; set; }
        public int currentID { get; set; }
        private ulong cellSoundNum { get; set; }
        public override Type[] PatchClasses => new[]
        {
            typeof(GlowstickInstance_OnCollisionEnter),
            typeof(GlowstickInstance_OnDespawn),
            typeof(GlowstickInstance_Update)
        };  
    }       
}
