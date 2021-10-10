using System;
using Dex.Tweaker.Util;
using UnityEngine;
using AK;
using Player;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Core
{
    class ObjectiveModifier : ConfigBaseMultiple<ObjectiveModifier.Data>
    {
        public class Data : DataBase
        {
            public uint DataBlockId { get; set; } = 34U;
            public float TimeLimit { get; set; } = 10f;
            public Infection Infection { get; set; } = new();
            public bool ExplodePlayer { get; set; } = true;
            public string name { get; set; } = "Default";
        }

        public class Infection
        {
            public float Amount { get; set; } = 0.01f;
            public MinMaxf Rate { get; set; } = new(1.0f, 1.5f);
            public bool Enabled { get; set; } = false;
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(CM_PageLoadout_UpdatePageData)
        };

        public void OnExpeditionStart()
        {
            foreach (var modifier in this.Config)
            {
                if (!modifier.internalEnabled) continue;
                Modifier = modifier.DataBlockId == RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId ? modifier : null;
                if (Modifier != null)
                {
                    InfectionTime = 0f;
                    InfectionCurrent = 0f;
                    InfectionTarget = 0f;
                    TimeLevelStart = Time;
                    TimeLimit = TimeLevelStart + modifier.TimeLimit;
                    Modifier = modifier;
                    break;
                }
            }
        }

        public void OnUpdate(ref PlayerAgent playerAgent)
        {
            if (Modifier == null) return;
            if (Time <= TimeLimit) return;
            if (Modifier.ExplodePlayer)
            {
                playerAgent.Damage.ExplosionDamage(playerAgent.PlayerData.health, playerAgent.Position, UnityEngine.Vector3.one * 100f);
                ulong _ = CellSound.Post(EVENTS.STICKYMINEEXPLODE, playerAgent.Position);
                Modifier = null; // Remove the modifier since the level is done
                return;
            }
            if (!Modifier.Infection.Enabled) return;
            if (InfectionTime <= TimeDelta)
            { // Update infection target based on config amount and a random config rate; sync network and map data
                InfectionCurrent = InfectionTarget;
                InfectionTarget = playerAgent.Damage.Infection + Modifier.Infection.Amount;
                InfectionTime = UnityEngine.Random.Range(Modifier.Infection.Rate.Min, Modifier.Infection.Rate.Max);
                if (InfectionCurrent == 0) return;
                playerAgent.Damage.ModifyInfection(new()
                {
                    amount = InfectionCurrent,
                    mode = pInfectionMode.Set
                }, true, true);
            }
            else
            { // Smoothly update local infection using supplied target and time based on frame delta
                InfectionCurrent = Mathf.Lerp(playerAgent.Damage.Infection, InfectionTarget, TimeDelta / InfectionTime);
                InfectionTime -= TimeDelta;
                playerAgent.Damage.ModifyInfection(new()
                {
                    amount = InfectionCurrent,
                    mode = pInfectionMode.Set
                }, false, false);
            }
        }


        public Data Modifier { get; set; }
        public bool Enabled { get; set; }
        public float Time { get => Clock.Time; }
        public float TimeDelta { get => UnityEngine.Time.deltaTime; }
        public float TimeLevelStart { get; set; }
        public float TimeLimit { get; set; }
        public float InfectionCurrent { get; set; }
        public float InfectionTarget { get; set; }
        public float InfectionTime { get; set; }
    }
}
