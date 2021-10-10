using System;
using System.Text;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using Enemies;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Dex.Tweaker.Core
{
    class NavMesh : ConfigBaseSingle<NavMesh.Data>
    {
        public class Data : DataBase
        {
            public Agent Agent { get; set; } = new();
            public float minRegionArea { get; set; } = 0f;
            public Override Override { get; set; } = new();
            public int TileSize { get; set; } = 768;
            public float VoxelSizeDenominator { get; set; } = 3.0f;
            public bool MediumQualityObstacleAvoidance { get; set; } = true;
            public bool ReduceAgentRadius { get; set; } = true;
        }

        public class Agent
        {
            public float Climb { get; set; } = 0.5f;
            public float Height { get; set; } = 2f;
            public float Radius { get; set; } = 0.25f;
            public float Slope { get; set; } = 55f;
        }

        public class Override
        {
            public bool TileSize { get; set; } = false;
            public bool VoxelSize { get; set; } = false;
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(EnemyAI_Setup),
            typeof(NavMeshBuilder_UpdateNavMeshDataAsync)
        };

        public void OnExpeditionStart()
        {
            if (!CoreManager.Current.UseDebugNavMesh.Value) return;

            var debugMesh = new Mesh();
            debugMesh.name = "DebugNavMesh";
            var triangulation = UnityEngine.AI.NavMesh.CalculateTriangulation();
            debugMesh.indexFormat = Mathf.Max(triangulation.vertices.Length, triangulation.indices.Length) >= 65534 ? IndexFormat.UInt32 : IndexFormat.UInt16;
            debugMesh.vertices = triangulation.vertices;
            debugMesh.triangles = triangulation.indices;


            var output = "Debug Nav Mesh";
            output = $"{output}\n\tvertices:{triangulation.vertices.Length}";
            output = $"{output}\n\ttriangles:{triangulation.indices.Length}";

            if (this.Generated == null)
            {
                this.Generated = new();
                GameObject.DontDestroyOnLoad(this.Generated);
                var meshFilter = this.Generated.AddComponent<MeshFilter>();
                var meshRenderer = this.Generated.AddComponent<MeshRenderer>();
                meshFilter.mesh = debugMesh;
                meshRenderer.material = new(Shader.Find("Standard"));
                output = $"{output}\n\tMesh created";
            }
            else
            {
                var meshFilter = this.Generated.GetComponent<MeshFilter>();
                meshFilter.mesh = debugMesh;
                output = $"{output}\n\tMesh already exists! updated information for it";
            }

            this.Generated.SetActive(false);
            Log.Debug(output);
        }

        public void Setup(EnemyAI instance)
        {
            if (!this.Config.internalEnabled) return;
            if (this.Config.MediumQualityObstacleAvoidance)
                instance.m_navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
            if (this.Config.ReduceAgentRadius)
                instance.m_navMeshAgent.radius = instance.m_navMeshAgent.radius - this.VoxelSize;
        }

        public void OnUpdate()
        {
            if (!CoreManager.Current.UseDebugNavMesh.Value) return;
            if (this.Generated == null) return;
            if (Input.GetKeyDown(CoreManager.Current.DebugNavMeshToggle.Value))
                this.Generated.SetActive(!this.Generated.active);
            if (Input.GetKeyDown(CoreManager.Current.DebugNavMeshReset.Value))
                this.Generated.transform.localPosition = UnityEngine.Vector3.zero;
            if (Input.GetKeyDown(CoreManager.Current.DebugNavMeshUp.Value))
                this.Generated.transform.localPosition = this.Generated.transform.localPosition + (UnityEngine.Vector3.one * 0.01f);
            if (Input.GetKeyDown(CoreManager.Current.DebugNavMeshDown.Value))
                this.Generated.transform.localPosition = this.Generated.transform.localPosition - (UnityEngine.Vector3.one * 0.01f);
        }

        public void UpdateData(ref NavMeshBuildSettings buildSettings)
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

            if (!this.Config.internalEnabled)
            {
                Log.Debug(sb.ToString());
                return;
            }

            buildSettings.agentClimb = this.Config.Agent.Climb;
            buildSettings.agentHeight = this.Config.Agent.Height;
            //Agent radius is 0.25f, change to 0.5f (the ai agent radius is 0.5f)
            buildSettings.agentRadius = this.Config.Agent.Radius;
            buildSettings.agentSlope = this.Config.Agent.Slope;
            buildSettings.minRegionArea = this.Config.minRegionArea;
            buildSettings.overrideTileSize = this.Config.Override.TileSize;
            buildSettings.overrideVoxelSize = this.Config.Override.VoxelSize;
            buildSettings.tileSize = this.Config.TileSize;
            //Adjust voxel size based on agent radius change
            this.VoxelSize = this.Config.Agent.Radius / this.Config.VoxelSizeDenominator;
            buildSettings.voxelSize = this.VoxelSize;

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

            if (CoreManager.Current.UseDebugNavMesh.Value && this.Generated != null)
            {
                this.Generated.SetActive(false);
                this.Generated.transform.localPosition = UnityEngine.Vector3.zero;
            }
            Log.Debug(sb.ToString());
        }

        public GameObject Generated { get; private set; }
        public float VoxelSize { get; set; }
    }
}
