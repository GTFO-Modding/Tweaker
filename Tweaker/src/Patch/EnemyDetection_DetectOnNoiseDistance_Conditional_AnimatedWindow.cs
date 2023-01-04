using Agents;
using Dex.Tweaker.Core;
using Enemies;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(EnemyDetection), nameof(EnemyDetection.DetectOnNoiseDistance_Conditional_AnimatedWindow))]
class EnemyDetection_DetectOnNoiseDistance_Conditional_AnimatedWindow
{
    public static void Prefix(ref AgentTarget agentTarget)
    {
        if (!ConfigManager.PlayerModifier.Config.internalEnabled || ConfigManager.PlayerModifier.Config.CanStealthBhop) return;
        if (agentTarget.m_agent.Noise == Agent.NoiseType.Jump)
            agentTarget.m_agent.Noise = Agent.NoiseType.Run;
    }
}
