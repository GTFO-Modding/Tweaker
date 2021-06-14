using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Player;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerAgent), "Setup")]
    class PlayerAgent_Setup
    {
        public static void Postfix(PlayerAgent __instance)
        {
            if (ConfigManager.PlayerModifier.Config.internalEnabled && ConfigManager.PlayerModifier.Config.ModelScale != 1f)
                __instance.PlayerSyncModel.transform.localScale = Vector3.one * ConfigManager.PlayerModifier.Config.ModelScale;
        }
    }
}
