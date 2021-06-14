using System;

namespace Dex.Tweaker.DataTransfer
{
    class NavMesh
    {
        public NavMeshAgent Agent { get; set; } = new NavMeshAgent();
        public float minRegionArea { get; set; } = 0f;
        public NavMeshOverride Override { get; set; } = new NavMeshOverride();
        public int TileSize { get; set; } = 768;
        public float VoxelSizeDenominator { get; set; } = 3.0f;
        public bool MediumQualityObstacleAvoidance { get; set; } = true;
        public bool ReduceAgentRadius { get; set; } = true;
        public bool internalEnabled { get; set; } = false;
    }
}
