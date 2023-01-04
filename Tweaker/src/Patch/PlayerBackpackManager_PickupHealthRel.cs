using Dex.Tweaker.Core;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(PlayerBackpackManager), nameof(PlayerBackpackManager.PickupHealthRel))]
class PlayerBackpackManager_PickupHealthRel
{
    public static void Prefix(ref float amountRel)
    {
        if (ResourcePack.Instance == null) return;
        amountRel = ResourcePack.Instance.healthAmountRel;
    }
}