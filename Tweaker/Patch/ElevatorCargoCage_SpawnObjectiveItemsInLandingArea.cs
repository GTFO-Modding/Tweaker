using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(ElevatorCargoCage), "SpawnObjectiveItemsInLandingArea")]
    class ElevatorCargoCage_SpawnObjectiveItemsInLandingArea
    {
        public static bool Prefix()
        {
            return CoreManager.Current.ElevatorCargo.Pre();
        }

        public static void Postfix(ElevatorCargoCage __instance)
        {
            CoreManager.Current.ElevatorCargo.Post(__instance);
        }
    }
}
