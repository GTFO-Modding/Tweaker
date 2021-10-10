using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using Player;

namespace Dex.Tweaker.Core
{
    class ResourcePack : ConfigBaseMultiple<ResourcePack.Data>
    {
        public class Data : DataBase
        {
            public uint DataBlockId { get; set; } = 34U;
            public float ammoStandardRel { get; set; } = 0.2f;
            public float ammoSpecialRel { get; set; } = 0.2f;
            public float ammoClassRel { get; set; } = 0.2f;
            public float healthAmountRel { get; set; } = 0.2f;
            public string name { get; set; } = "Default";
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(PlayerBackpackManager_PickupHealthRel),
            typeof(PlayerBackpackManager_ReceiveAmmoGive)
        };

        public void OnExpeditionStart()
        {
            foreach (var resourcePack in this.Config)
                if (resourcePack.DataBlockId == RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId)
                    Instance = resourcePack.internalEnabled ? resourcePack : null;
        }

        public void Receive(ref pAmmoGive data)
        {
            if (this.Instance == null) return;
            if (data.ammoStandardRel > 0) data.ammoStandardRel = this.Instance.ammoStandardRel;
            if (data.ammoSpecialRel > 0) data.ammoSpecialRel = this.Instance.ammoSpecialRel;
            if (data.ammoClassRel > 0) data.ammoClassRel = this.Instance.ammoClassRel;
        }

        public void Receive(ref float amountRel)
        {
            if (this.Instance == null) return;
            amountRel = this.Instance.healthAmountRel;
        }

        public Data Instance { get; private set; }
    }
}
