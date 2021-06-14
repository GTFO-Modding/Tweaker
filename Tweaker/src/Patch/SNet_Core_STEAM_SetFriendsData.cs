using System;
using HarmonyLib;
using SNetwork;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(SNet_Core_STEAM), "SetFriendsData", new Type[] { typeof(FriendsDataType), typeof(string) })]
    class SNet_Core_STEAM_SetFriendsData
    {
        public static void Prefix(ref string data)
            => data = string.Empty;
    }
}