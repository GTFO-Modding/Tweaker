using System.Collections.Generic;
using UnityEngine;
using LevelGeneration;
using Player;
using AK;

namespace Dex.Tweaker.Core
{
    class GamerGlowstick
    {
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

        public class Param
        {
            public static bool internalEnabled { get => ConfigManager.GamerGlowstick.Config.internalEnabled; }
            public static uint itemID { get => ConfigManager.GamerGlowstick.Config.ItemID; }
            public static float newRed { get => ConfigManager.GamerGlowstick.Config.Min.Red + (Random.value * (ConfigManager.GamerGlowstick.Config.Max.Red - ConfigManager.GamerGlowstick.Config.Min.Red)); }
            public static float newGreen { get => ConfigManager.GamerGlowstick.Config.Min.Green + (Random.value * (ConfigManager.GamerGlowstick.Config.Max.Green - ConfigManager.GamerGlowstick.Config.Min.Green)); }
            public static float newBlue { get => ConfigManager.GamerGlowstick.Config.Min.Blue + (Random.value * (ConfigManager.GamerGlowstick.Config.Max.Blue - ConfigManager.GamerGlowstick.Config.Min.Blue)); }
        }

        public static bool Exist(int instanceID, Item item)
        {
            if(Param.internalEnabled && item.ItemDataBlock.persistentID == Param.itemID)
            {
                notUsed = false;
            }
            else
            {
                notUsed = true;
                return false;
            }
            if (lookup == null) lookup = new Dictionary<int, Setting>();
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
                Update(instanceID);
                currentID = instanceID;
                return true;
            }
            else
            {
                lookup.Add(instanceID, new Setting());
                return false;
            }
        }

        public static void Update(int instanceID)
        {
            if (lookup[instanceID].time <= Time.deltaTime)
            {
                lookup[instanceID].color = lookup[instanceID].target;
                lookup[instanceID].target = new Color()
                {
                    r = Param.newRed,
                    g = Param.newGreen,
                    b = Param.newBlue,
                };
                lookup[instanceID].time += ConfigManager.GamerGlowstick.Config.PulseRate;
            }
            else
            {
                lookup[instanceID].color = Color.Lerp(lookup[instanceID].color, lookup[instanceID].target, Time.deltaTime / lookup[instanceID].time);
                lookup[instanceID].time -= Time.deltaTime;
            }
        }

        public static void TurnOffLights(ref Collision col)
        {
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

        public static void Despawn(int instanceID, Vector3 position)
        {
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
        public static CellSoundPlayer m_sound { get; set; }
        public static Dictionary<int, Setting> lookup { get; set; }
        static bool isActive { get; set; }
        static bool notUsed { get; set; }
        public static int currentID { get; set; }
        private static ulong cellSoundNum { get; set; }
    }
}
