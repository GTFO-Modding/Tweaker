using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Enemies;
using UnityEngine.AI;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyAI), "Setup")]
    class EnemyAI_Setup
    {
        public static void Postfix(EnemyAI __instance)
        {
            if (!ConfigManager.NavMesh.Config.internalEnabled) return;
            if (ConfigManager.NavMesh.Config.MediumQualityObstacleAvoidance)
                __instance.m_navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
            if (ConfigManager.NavMesh.Config.ReduceAgentRadius)
                __instance.m_navMeshAgent.radius = __instance.m_navMeshAgent.radius - Core.NavMesh.VoxelSize;
        }
    }
}
