using System;
using Enemies;
using HarmonyLib;
using Agents;
using Dex.Tweaker.Util;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyDetection), "DetectOnNoiseDistance_Conditional_AnimatedWindow")]
    class EnemyDetection_DetectOnNoiseDistance_Conditional_AnimatedWindow
    {
        public static void Prefix(ref AgentTarget agentTarget)
        {
            CoreManager.Current.PlayerModifier.Bhop(agentTarget.m_agent);
        }
    }
}
