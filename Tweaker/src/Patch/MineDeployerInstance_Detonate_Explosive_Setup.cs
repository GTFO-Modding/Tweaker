using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(MineDeployerInstance_Detonate_Explosive), nameof(MineDeployerInstance_Detonate_Explosive.Setup))]
class MineDeployerInstance_Detonate_Explosive_Setup
{
    public static void Prefix(ref iMineDeployerInstanceCore core, MineDeployerInstance_Detonate_Explosive __instance)
    {
        Log.Debug(
            "Mine Explosive Setup" +
            $"\n\tdelay:{__instance.m_delay}" +
            $"\n\tradius:{__instance.m_radius}" +
            $"\n\tdistanceMin:{__instance.m_distanceMin}" +
            $"\n\tdistanceMax:{__instance.m_distanceMax}" +
            $"\n\tdamageMin:{ __instance.m_damageMin}" +
            $"\n\tdamageMax:{__instance.m_damageMax}" +
            $"\n\texplosionForce:{__instance.m_explosionForce}" +
            $"\n\texplosionDelay:{__instance.m_explosionDelay}"
        );

        foreach (var config in ConfigManager.Mine.Config)
        {
            if (!config.internalEnabled
                || config.ItemID != core.Owner.FPItemHolder.m_inventoryLocal.WieldedItem.ItemDataBlock.persistentID)
                continue;
            __instance.m_delay = config.Delay;
            __instance.m_radius = config.Radius;
            __instance.m_distanceMin = config.Distance.Min;
            __instance.m_distanceMax = config.Distance.Max;
            __instance.m_damageMin = config.Damage.Min;
            __instance.m_damageMax = config.Damage.Max;
            __instance.m_explosionForce = config.Force;
            __instance.m_explosionDelay = config.ExplosionDelay;
            break;
        }
    }
}