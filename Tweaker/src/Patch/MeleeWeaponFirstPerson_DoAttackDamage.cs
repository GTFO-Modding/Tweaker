using System;
using Dex.Tweaker.Util;
using Dex.Tweaker.Core;
using HarmonyLib;
using Gear;
using SNetwork;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "DoAttackDamage")]
    class MeleeWeaponFirstPerson_DoAttackDamage
    {
        public static void Prefix(MeleeWeaponFirstPerson __instance)
        {
            if (!ConfigManager.DifficultyScale.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (ConfigManager.DifficultyScale.Config.Solo.enabled && ConfigManager.DifficultyScale.Config.Solo.HammerDamage != 1.0f)
                        __instance.m_damageToDeal = __instance.m_damageToDeal * ConfigManager.DifficultyScale.Config.Solo.HammerDamage;
                    break;
                case 2:
                    if (ConfigManager.DifficultyScale.Config.Duo.enabled && ConfigManager.DifficultyScale.Config.Duo.HammerDamage != 1.0f)
                        __instance.m_damageToDeal = __instance.m_damageToDeal * ConfigManager.DifficultyScale.Config.Duo.HammerDamage;
                    break;
                case 3:
                    if (ConfigManager.DifficultyScale.Config.Trio.enabled && ConfigManager.DifficultyScale.Config.Trio.HammerDamage != 1.0f)
                        __instance.m_damageToDeal = __instance.m_damageToDeal * ConfigManager.DifficultyScale.Config.Trio.HammerDamage;
                    break;
                case 4:
                    if (ConfigManager.DifficultyScale.Config.Full.enabled && ConfigManager.DifficultyScale.Config.Full.HammerDamage != 1.0f)
                        __instance.m_damageToDeal = __instance.m_damageToDeal * ConfigManager.DifficultyScale.Config.Full.HammerDamage;
                    break;
                default:
                    Log.Warning("Abnormal number of players detected in session");
                    break;
            }
        }
    }
}