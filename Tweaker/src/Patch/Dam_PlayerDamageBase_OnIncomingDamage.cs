using System;
using Dex.Tweaker.Util;
using Dex.Tweaker.Core;
using HarmonyLib;
using SNetwork;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_PlayerDamageBase), "OnIncomingDamage")]
    class Dam_PlayerDamageBase_OnIncomingDamage
    {
        public static void Prefix(ref float damage)
        {
            if (!ConfigManager.DifficultyScale.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (ConfigManager.DifficultyScale.Config.Solo.enabled && ConfigManager.DifficultyScale.Config.Solo.DamagePlayer != 1.0f)
                        damage = damage * ConfigManager.DifficultyScale.Config.Solo.DamagePlayer;
                    break;
                case 2:
                    if (ConfigManager.DifficultyScale.Config.Duo.enabled && ConfigManager.DifficultyScale.Config.Duo.DamagePlayer != 1.0f)
                        damage = damage * ConfigManager.DifficultyScale.Config.Duo.DamagePlayer;
                    break;
                case 3:
                    if (ConfigManager.DifficultyScale.Config.Trio.enabled && ConfigManager.DifficultyScale.Config.Trio.DamagePlayer != 1.0f)
                        damage = damage * ConfigManager.DifficultyScale.Config.Trio.DamagePlayer;
                    break;
                case 4:
                    if (ConfigManager.DifficultyScale.Config.Full.enabled && ConfigManager.DifficultyScale.Config.Full.DamagePlayer != 1.0f)
                        damage = damage * ConfigManager.DifficultyScale.Config.Full.DamagePlayer;
                    break;
                default:
                    Log.Warning("Abnormal number of players detected in session");
                    break;
            }
        }
    }
}
