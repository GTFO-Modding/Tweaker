using System;
using System.Text;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;
using GameData;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyScanner), "Setup")]
    class EnemyScanner_Setup
    {
        public static void Prefix(ref ItemDataBlock data, EnemyScanner __instance)
        {
            CoreManager.Current.BioTracker.Setup(data.persistentID, __instance);
        }
    }
}