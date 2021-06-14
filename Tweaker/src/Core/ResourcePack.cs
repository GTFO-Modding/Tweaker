using System;
using System.Collections.Generic;
using System.Text;

namespace Dex.Tweaker.Core
{
    class ResourcePack
    {
        public static void Load()
        {
            foreach (var resourcePack in ConfigManager.ResourcePack.Config)
                if (resourcePack.DataBlockId == RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId)
                    Instance = resourcePack.internalEnabled ? resourcePack : null;
        }
        public static DataTransfer.ResourcePack Instance { get; private set; }
    }
}
