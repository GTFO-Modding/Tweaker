using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using LevelGeneration;

namespace Dex.Tweaker.Core
{
    class ElevatorCargo : ConfigBaseMultiple<ElevatorCargo.Data>
    {
        public class Data : DataBase
        {
            public uint DataBlockId { get; set; } = 34U;
            public uint[] ItemID { get; set; } = new[] { 133U };
            public bool ForceDisable { get; set; } = false;
            public string name { get; set; } = "Fog Turbine";
        }
        public override Type[] PatchClasses => new[]
        {
            typeof(ElevatorCargoCage_SpawnObjectiveItemsInLandingArea)
        };

        public bool Pre()
        {
            Cargo = null;
            foreach (var cargo in this.Config)
            {
                if (!cargo.internalEnabled
                || cargo.DataBlockId != RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId)
                    continue;

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

        public void Post(ElevatorCargoCage instance)
        {
            if (Cargo == null) return;
            if (Cargo.ItemID.Length < 1) return;
            instance.m_itemsToMoveToCargo = new UnityEngine.Transform[Cargo.ItemID.Length];
            var index = 0;
            foreach (var item in Cargo.ItemID)
            {
                var lgPickupCustom = LG_PickupItem.SpawnGenericPickupItem(ElevatorShaftLanding.CargoAlign);
                lgPickupCustom.SpawnNode = Builder.GetElevatorArea().m_courseNode;
                lgPickupCustom.SetupAsBigPickupItem(UnityEngine.Random.Range(0, int.MaxValue), item, false);
                instance.m_itemsToMoveToCargo[index] = lgPickupCustom.transform;
                index++;
            }
            ElevatorRide.Current.m_cargoCageInUse = true;
        }

        public Data Cargo { get; set; }
    }
}
