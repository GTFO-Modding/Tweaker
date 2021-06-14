using System;
using System.Text;
using Dex.Tweaker.Core;
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
            var sb = new StringBuilder();

            sb.AppendLine("Nav Mesh Build original settings");
            sb.AppendLine($"\tAgent climb:{buildSettings.agentClimb}");
            sb.AppendLine($"\tAgent height:{buildSettings.agentHeight}");
            sb.AppendLine($"\tAgent radius:{buildSettings.agentRadius}");
            sb.AppendLine($"\tAgent slope:{buildSettings.agentSlope}");
            sb.AppendLine($"\tMin region area:{buildSettings.minRegionArea}");
            sb.AppendLine($"\tOverride tile size:{buildSettings.overrideTileSize}");
            sb.AppendLine($"\tOverride voxel size:{buildSettings.overrideVoxelSize}");
            sb.AppendLine($"\tTile size:{buildSettings.tileSize}");
            sb.AppendLine($"\tVoxel size:{buildSettings.voxelSize}");

            if (!ConfigManager.NavMesh.Config.internalEnabled)
            {
                Log.Debug(sb.ToString());
                return;
            }

            buildSettings.agentClimb = ConfigManager.NavMesh.Config.Agent.Climb;
            buildSettings.agentHeight = ConfigManager.NavMesh.Config.Agent.Height;
            //Agent radius is 0.25f, change to 0.5f (the ai agent radius is 0.5f)
            buildSettings.agentRadius = ConfigManager.NavMesh.Config.Agent.Radius;
            buildSettings.agentSlope = ConfigManager.NavMesh.Config.Agent.Slope;
            buildSettings.minRegionArea = ConfigManager.NavMesh.Config.minRegionArea;
            buildSettings.overrideTileSize = ConfigManager.NavMesh.Config.Override.TileSize;
            buildSettings.overrideVoxelSize = ConfigManager.NavMesh.Config.Override.VoxelSize;
            buildSettings.tileSize = ConfigManager.NavMesh.Config.TileSize;
            //Adjust voxel size based on agent radius change
            Core.NavMesh.VoxelSize = ConfigManager.NavMesh.Config.Agent.Radius / ConfigManager.NavMesh.Config.VoxelSizeDenominator;
            buildSettings.voxelSize = Core.NavMesh.VoxelSize;

            sb.AppendLine("Nav Mesh Build settings");
            sb.AppendLine($"\tAgent climb:{buildSettings.agentClimb}");
            sb.AppendLine($"\tAgent height:{buildSettings.agentHeight}");
            sb.AppendLine($"\tAgent radius:{buildSettings.agentRadius}");
            sb.AppendLine($"\tAgent slope:{buildSettings.agentSlope}");
            sb.AppendLine($"\tMin region area:{buildSettings.minRegionArea}");
            sb.AppendLine($"\tOverride tile size:{buildSettings.overrideTileSize}");
            sb.AppendLine($"\tOverride voxel size:{buildSettings.overrideVoxelSize}");
            sb.AppendLine($"\tTile size:{buildSettings.tileSize}");
            sb.AppendLine($"\tVoxel size:{buildSettings.voxelSize}");

            if (ConfigManager.UseDebugNavMesh.Value && Debug.VisualNavMesh != null)
            {
                Debug.VisualNavMesh.SetActive(false);
                Debug.VisualNavMesh.transform.localPosition = UnityEngine.Vector3.zero;
            }
            Log.Debug(sb.ToString());
        }
    }
}
