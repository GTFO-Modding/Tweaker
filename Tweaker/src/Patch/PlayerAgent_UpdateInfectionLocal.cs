using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Player;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerAgent), "UpdateInfectionLocal")]
    class PlayerAgent_UpdateInfectionLocal
    {
        public static void Prefix(PlayerAgent __instance)
        {
            ObjectiveModifier.Update(ref __instance);

            //probably move this into the player input handler?
            if (!ConfigManager.UseDebugNavMesh.Value) return;
            if (Core.Debug.VisualNavMesh == null) return;
            if (Input.GetKeyDown(ConfigManager.DebugNavMeshToggle.Value))
                Core.Debug.VisualNavMesh.SetActive(!Core.Debug.VisualNavMesh.active);
            if (Input.GetKeyDown(ConfigManager.DebugNavMeshReset.Value))
                Core.Debug.VisualNavMesh.transform.localPosition = Vector3.zero;
            if (Input.GetKeyDown(ConfigManager.DebugNavMeshUp.Value))
                Core.Debug.VisualNavMesh.transform.localPosition = Core.Debug.VisualNavMesh.transform.localPosition + (Vector3.one * 0.01f);
            if (Input.GetKeyDown(ConfigManager.DebugNavMeshDown.Value))
                Core.Debug.VisualNavMesh.transform.localPosition = Core.Debug.VisualNavMesh.transform.localPosition - (Vector3.one * 0.01f);
        }
    }
}