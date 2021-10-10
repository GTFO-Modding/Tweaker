using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using UnityEngine.AI;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(NavMeshBuilder), "UpdateNavMeshDataAsync")]
    class NavMeshBuilder_UpdateNavMeshDataAsync
    {
        public static void Prefix(ref NavMeshBuildSettings buildSettings)
        {
            CoreManager.Current.NavMesh.UpdateData(ref buildSettings);
        }
    }
}
