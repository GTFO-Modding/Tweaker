using Dex.Tweaker.Core;
using HarmonyLib;
using Player;

namespace Dex.Tweaker;

[HarmonyPatch(typeof(LocalPlayerAgent), nameof(LocalPlayerAgent.UpdateInfectionLocal))]
class LocalPlayerAgent_UpdateInfectionLocal
{
    public static void Prefix(LocalPlayerAgent __instance)
    {
        ObjectiveModifier.Update(__instance);
    }
}
