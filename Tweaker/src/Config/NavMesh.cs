using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class NavMesh : DataTransfer.ConfigBaseSingle<DataTransfer.NavMesh>
    {
        public override void OnConfigLoaded()
        {
            if (this.Config.internalEnabled)
            {
                BasePlugin.Instance.PatchAll(typeof(EnemyAI_Setup));
                BasePlugin.Instance.PatchAll(typeof(NavMeshBuilder_UpdateNavMeshDataAsync));
            }
        }
    }
}
