using Dex.Tweaker.Core;
using HarmonyLib;
using UnityEngine;
using LevelGeneration;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(ElevatorCargoCage), "SpawnObjectiveItemsInLandingArea")]
    class ElevatorCargoCage_SpawnObjectiveItemsInLandingArea
    {
        public static bool Prefix()
        {
            Cargo = null;
            foreach(var cargo in ConfigManager.ElevatorCargo.Config)
            {
                if (!cargo.internalEnabled) continue;
                if (cargo.DataBlockId != RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId) continue;
                if (cargo.ForceDisable)
                {
                    ElevatorRide.Current.m_cargoCageInUse = false;
                    return false;
                }
                Cargo = cargo;
                break;
            }
            return true;
        }

        public static void Postfix(ElevatorCargoCage __instance)
        {
            if (Cargo == null) return;
            if (Cargo.ItemID.Length < 1) return;
            __instance.m_itemsToMoveToCargo = new Transform[Cargo.ItemID.Length];
            var index = 0;
            foreach(var item in Cargo.ItemID)
            {
                var lgPickupCustom = LG_PickupItem.SpawnGenericPickupItem(ElevatorShaftLanding.CargoAlign);
                lgPickupCustom.SpawnNode = Builder.GetElevatorArea().m_courseNode;
                lgPickupCustom.SetupAsBigPickupItem(Random.Range(0, int.MaxValue), item, false);
                __instance.m_itemsToMoveToCargo[index] = lgPickupCustom.transform;
                index++;
            }
            ElevatorRide.Current.m_cargoCageInUse = true;
        }

        public static DataTransfer.ElevatorCargo Cargo { get; set; }
    }
}
