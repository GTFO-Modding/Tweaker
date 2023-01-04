using Dex.Tweaker.Core;
using HarmonyLib;
using LevelGeneration;
using UnityEngine;

namespace Dex.Tweaker.Patch;

using Random = UnityEngine.Random;

[HarmonyPatch(typeof(ElevatorCargoCage), nameof(ElevatorCargoCage.SpawnObjectiveItemsInLandingArea))]
class ElevatorCargoCage_SpawnObjectiveItemsInLandingArea
{
    public static bool Prefix()
    {
        AddedCargo = null;
        foreach(var cargo in ConfigManager.ElevatorCargo.Config)
        {
            if (!cargo.internalEnabled) continue;
            if (cargo.DataBlockId != RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId) continue;
            if (cargo.ForceDisable)
            {
                ElevatorRide.Current.m_cargoCageInUse = false;
                return false;
            }
            AddedCargo = cargo;
            break;
        }
        return true;
    }

    public static void Postfix(ElevatorCargoCage __instance)
    {
        if (AddedCargo == null) return;
        if (AddedCargo.CargoItems.Length < 1) return;

        if (__instance.m_itemsToMoveToCargo == null)
            __instance.m_itemsToMoveToCargo = new();
        
        foreach(var cargo in AddedCargo.CargoItems)
        {
            var lgPickupCustom = LG_PickupItem.SpawnGenericPickupItem(ElevatorShaftLanding.CargoAlign);
            lgPickupCustom.SpawnNode = Builder.GetElevatorArea().m_courseNode;
            lgPickupCustom.SetupAsBigPickupItem(Random.Range(0, int.MaxValue), cargo.ItemId, false, cargo.ObjectiveChainIndex);
            __instance.m_itemsToMoveToCargo.Add(lgPickupCustom.transform);
        }
        ElevatorRide.Current.m_cargoCageInUse = true;
    }

    public static DataTransfer.ElevatorCargo AddedCargo { get; set; }
}
