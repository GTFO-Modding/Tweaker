using System;
using Agents;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using Player;

namespace Dex.Tweaker.Core
{
    class PlayerModifier : ConfigBaseSingle<PlayerModifier.Data>
    {
        public class Data : DataBase
        {
            public float SlideForceScale { get; set; } = 1f;
            public float EvadeSpeed { get; set; } = 3f;
            public float ModelScale { get; set; } = 1f;
            public bool CanStealthBhop { get; set; } = true;
        }
        public override Type[] PatchClasses => new[]
        {
            typeof(EnemyDetection_DetectOnNoiseDistance_Conditional_AnimatedWindow),
            typeof(PlayerAgent_Setup),
            typeof(PlayerLocomotion_AddExternalPushForce),
            typeof(PLOC_Stand_Update)
        };

        public void Evade(PLOC_Stand instance)
        {
            if (this.Config.internalEnabled && this.Config.EvadeSpeed != 3f)
                if (instance.m_moveSpeedMulti == 3f)
                    instance.m_moveSpeedMulti = this.Config.EvadeSpeed;
        }

        public void Slide(ref UnityEngine.Vector3 force)
        {
            if (this.Config.internalEnabled && this.Config.SlideForceScale != 1f)
                force = force * this.Config.SlideForceScale;
        }

        public void Scale(PlayerAgent instance)
        {
            if (this.Config.internalEnabled && this.Config.ModelScale != 1f)
                instance.PlayerSyncModel.transform.localScale = UnityEngine.Vector3.one * this.Config.ModelScale;
        }

        public void Bhop(Agent player)
        {
            if (!this.Config.internalEnabled || this.Config.CanStealthBhop) return;
            if (player.Noise == Agent.NoiseType.Jump)
                player.Noise = Agent.NoiseType.Run;
        }
    }
}
