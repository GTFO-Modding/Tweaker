using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerBackpackManager), "ReceiveAmmoGive")]
    class PlayerBackpackManager_ReceiveAmmoGive
    {
        public static void Prefix(ref pAmmoGive data)
        {
            CoreManager.Current.ResourcePack.Receive(ref data);
        }
    }
}
