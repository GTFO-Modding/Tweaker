using System;
using Gear;
using UnityEngine;

namespace Dex.Tweaker.Core
{
    class Hammer
    {
        public static void ReplaceData(MeleeAttackData original, DataTransfer.HammerData custom)
        {
            original.m_animBlendIn = custom.AnimBlendIn;
            original.m_attackCamFwdHitTime = custom.AttackCamFwdHitTime;
            original.m_attackHitTime = custom.AttackHitTime;
            original.m_attackLength = custom.AttackLength;
            original.m_comboEarlyTime = custom.ComboEarlyTime;
            original.m_damageEndTime = custom.DamageEndTime;
            original.m_damageStartTime = custom.DamageStartTime;
        }
        public static void SetTransform(Transform original, DataTransfer.HammerPart custom)
        {
            var vec = new Vector3(custom.Scale.X, custom.Scale.Y, custom.Scale.Z);
            if (vec != Vector3.one) original.localScale = vec;
            vec = new Vector3(custom.Position.X, custom.Position.Y, custom.Position.Z);
            if (vec != Vector3.zero) original.localPosition = vec;
            vec = new Vector3(custom.Rotation.X, custom.Rotation.Y, custom.Rotation.Z);
            if (vec != Vector3.zero) original.localEulerAngles = vec;
        }
        public static DataTransfer.Hammer Equiped { get; set; }
    }
}
