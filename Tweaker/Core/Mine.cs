using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using GameData;

namespace Dex.Tweaker.Core
{
    class Mine : ConfigBaseMultiple<Mine.Data>
    {
        public class Data : DataBase
        {
            public float Delay { get; set; } = 0.25f;
            public float Radius { get; set; } = 2.5f;
            public MinMaxf Distance { get; set; } = new(3f, 15f);
            public MinMaxf Damage { get; set; } = new(15f, 35f);
            public float Force { get; set; } = 1000f;
            public float ExplosionDelay { get; set; } = 0.25f;
            public float DeployPickupInteractionDuration { get; set; } = 0.5f;
            public float TimeBetweenPlacements { get; set; } = 2f;
            public uint ItemID { get; set; } = 37U;
            public string name { get; set; } = "Default";
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(MineDeployerFirstPerson_Setup),
            typeof(MineDeployerInstance_Detonate_Explosive_Setup)
        };

        public void OnSetup(ref ItemDataBlock data, MineDeployerFirstPerson instance)
        {
            Log.Debug(
                "Mine Deployer Setup" +
                $"\n\tdeployPickupInteractionDuration:{instance.m_deployPickupInteractionDuration}" +
                $"\n\ttimeBetweenPlacements:{instance.m_timeBetweenPlacements}"
            );
            foreach (var config in this.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                instance.m_deployPickupInteractionDuration = config.DeployPickupInteractionDuration;
                instance.m_timeBetweenPlacements = config.TimeBetweenPlacements;
                break;
            }
        }

        public void OnSetup(ref iMineDeployerInstanceCore core, MineDeployerInstance_Detonate_Explosive instance)
        {
            Log.Debug(
                "Mine Explosive Setup" +
                $"\n\tdelay:{instance.m_delay}" +
                $"\n\tradius:{instance.m_radius}" +
                $"\n\tdistanceMin:{instance.m_distanceMin}" +
                $"\n\tdistanceMax:{instance.m_distanceMax}" +
                $"\n\tdamageMin:{instance.m_damageMin}" +
                $"\n\tdamageMax:{instance.m_damageMax}" +
                $"\n\texplosionForce:{instance.m_explosionForce}" +
                $"\n\texplosionDelay:{instance.m_explosionDelay}"
            );

            foreach (var config in this.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != core.Owner.FPItemHolder.m_inventoryLocal.WieldedItem.ItemDataBlock.persistentID)
                    continue;
                instance.m_delay = config.Delay;
                instance.m_radius = config.Radius;
                instance.m_distanceMin = config.Distance.Min;
                instance.m_distanceMax = config.Distance.Max;
                instance.m_damageMin = config.Damage.Min;
                instance.m_damageMax = config.Damage.Max;
                instance.m_explosionForce = config.Force;
                instance.m_explosionDelay = config.ExplosionDelay;
                break;
            }
        }
    }
}
