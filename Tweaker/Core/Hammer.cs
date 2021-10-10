using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using GameData;
using Gear;

namespace Dex.Tweaker.Core
{
    class Hammer : ConfigBaseMultiple<Hammer.Data>
    {
        public class Data : DataBase
        {
            public MinMaxf Damage { get; set; } = new(4f, 20f);
            public float PrecisionDamageMulti { get; set; } = 1f;
            public float CameraDamageRayLength { get; set; } = 1.8f;
            public float InputBufferTime { get; set; } = 0.5f;
            public float MaxPushFrequency { get; set; } = 1.2f;
            public float AttackDamageSphereDotScale { get; set; } = 0.9f;
            public float PushDamageSphereRadius { get; set; } = 0.6f;
            public float SyncTimeout { get; set; } = 2f;
            public float BufferedAttackTime { get; set; } = -1f;
            public float BufferedPushTime { get; set; } = -1f;
            public MinMaxf StaminaSpeed { get; set; } = new(0.8f, 1f);
            public float ChargeUpTime { get; set; } = 2f;
            public float AutoAttackTime { get; set; } = 4f;
            public Timing AttackMissRight { get; set; } = new()
            {
                AnimBlendIn = 0.2f,
                AttackLength = 1f,
                AttackHitTime = 0.3333333f,
                AttackCamFwdHitTime = 0.5f,
                DamageStartTime = 0.3333333f,
                DamageEndTime = 0.7666667f,
                ComboEarlyTime = 0.6666667f
            };
            public Timing AttackMissLeft { get; set; } = new()
            {
                AnimBlendIn = 0.2f,
                AttackLength = 1f,
                AttackHitTime = 0.3333333f,
                AttackCamFwdHitTime = 0.5f,
                DamageStartTime = 0.3333333f,
                DamageEndTime = 0.7666667f,
                ComboEarlyTime = 0.6666667f
            };
            public Timing AttackHitRight { get; set; } = new()
            {
                AnimBlendIn = 0.0f,
                AttackLength = 0.5f,
                AttackHitTime = 0.5f,
                ComboEarlyTime = 0.4f
            };
            public Timing AttackHitLeft { get; set; } = new()
            {
                AnimBlendIn = 0.0f,
                AttackLength = 0.5f,
                AttackHitTime = 0.5f,
                ComboEarlyTime = 0.4f
            };
            public Timing AttackPush { get; set; } = new()
            {
                AnimBlendIn = 0.2f,
                AttackLength = 0.6666667f,
                DamageStartTime = 0.1333333f,
                DamageEndTime = 0.2666667f,
                AttackCamFwdHitTime = 0.3333333f,
                ComboEarlyTime = 0.8333333f
            };
            public Timing AttackChargeUpRight { get; set; } = new()
            {
                AnimBlendIn = 0.23f
            };
            public Timing AttackChargeUpLeft { get; set; } = new()
            {
                AnimBlendIn = 0.3f
            };
            public Timing AttackChargeUpReleaseRight { get; set; } = new()
            {
                AnimBlendIn = 0.0f,
                AttackLength = 0.3666667f,
                AttackHitTime = 0.1333333f,
                DamageStartTime = 0.0f,
                DamageEndTime = 0.3666667f,
                AttackCamFwdHitTime = 0.1333333f,
                ComboEarlyTime = 0.3f
            };
            public Timing AttackChargeUpReleaseLeft { get; set; } = new()
            {
                AnimBlendIn = 0.0f,
                AttackLength = 0.3666667f,
                AttackHitTime = 0.1333333f,
                DamageStartTime = 0.0f,
                DamageEndTime = 0.3666667f,
                AttackCamFwdHitTime = 0.1333333f,
                ComboEarlyTime = 0.3f
            };
            public Transform Head { get; set; } = new();
            public Transform Neck { get; set; } = new();
            public Transform Handle { get; set; } = new();
            public Transform Pommel { get; set; } = new();
            public uint ItemID { get; set; } = 100U;
            public string name { get; set; } = "Default";
        }

        public class Timing
        {
            public float AnimBlendIn { get; set; }
            public float AttackLength { get; set; }
            public float AttackHitTime { get; set; }
            public float AttackCamFwdHitTime { get; set; }
            public float DamageStartTime { get; set; }
            public float DamageEndTime { get; set; }
            public float ComboEarlyTime { get; set; }
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(MeleeWeaponFirstPerson_Setup),
            typeof(MeleeWeaponFirstPerson_OnWield),
            typeof(MWS_Chargeup_Enter),
            typeof(MWS_ChargeUp_Update),
            typeof(Dam_EnemyDamageLimb_MeleeDamage)
        };

        public bool TryReadData(uint persistentID)
        {
            Equiped = new();
            foreach (var hammer in this.Config)
            {
                if (!hammer.internalEnabled
                    || hammer.ItemID != persistentID) continue;
                Equiped = hammer;
                return true;
            }
            return false;
        }

        public void ReplaceData(MeleeWeaponFirstPerson instance)
        {
            instance.m_damageLight = Equiped.Damage.Min;
            instance.m_damageHeavy = Equiped.Damage.Max;
            instance.m_cameraDamageRayLength = Equiped.CameraDamageRayLength;
            instance.m_inputBufferTime = Equiped.InputBufferTime;
            instance.m_maxPushFrequency = Equiped.MaxPushFrequency;
            instance.m_attackDamageSphereDotScale = Equiped.AttackDamageSphereDotScale;
            instance.m_pushDamageSphereRadius = Equiped.PushDamageSphereRadius;
            instance.m_syncTimeout = Equiped.SyncTimeout;
            instance.m_bufferedAttackTime = Equiped.BufferedAttackTime;
            instance.m_bufferedPushTime = Equiped.BufferedPushTime;
            instance.m_staminaSpeedMinMax.Set(Equiped.StaminaSpeed.Min, Equiped.StaminaSpeed.Max);
            ReplaceData(instance.m_attackMissRight, Equiped.AttackMissRight);
            ReplaceData(instance.m_attackMissLeft, Equiped.AttackMissLeft);
            ReplaceData(instance.m_attackHitRight, Equiped.AttackHitRight);
            ReplaceData(instance.m_attackHitLeft, Equiped.AttackHitLeft);
            ReplaceData(instance.m_attackPush, Equiped.AttackPush);
            ReplaceData(instance.m_attackChargeUpRight, Equiped.AttackChargeUpRight);
            ReplaceData(instance.m_attackChargeUpLeft, Equiped.AttackChargeUpLeft);
            ReplaceData(instance.m_attackChargeUpReleaseLeft, Equiped.AttackChargeUpReleaseLeft);
            ReplaceData(instance.m_attackChargeUpReleaseRight, Equiped.AttackChargeUpReleaseRight);
        }

        public void ReplaceData(MeleeAttackData original, Timing custom)
        {
            original.m_animBlendIn = custom.AnimBlendIn;
            original.m_attackCamFwdHitTime = custom.AttackCamFwdHitTime;
            original.m_attackHitTime = custom.AttackHitTime;
            original.m_attackLength = custom.AttackLength;
            original.m_comboEarlyTime = custom.ComboEarlyTime;
            original.m_damageEndTime = custom.DamageEndTime;
            original.m_damageStartTime = custom.DamageStartTime;
        }

        public void SetTransform(GearPartHolder gearPart)
        {
            SetTransform(gearPart.MeleeHeadPart.transform, Equiped.Head);
            SetTransform(gearPart.MeleeNeckPart.transform, Equiped.Neck);
            SetTransform(gearPart.MeleeHandlePart.transform, Equiped.Handle);
            SetTransform(gearPart.MeleePommelPart.transform, Equiped.Pommel);
        }

        public void SetTransform(UnityEngine.Transform original, Transform custom)
        {
            original.localScale.Set(custom.Scale.X, custom.Scale.Y, custom.Scale.Z);
            original.localPosition.Set(custom.Position.X, custom.Position.Y, custom.Position.Z);
            original.localEulerAngles.Set(custom.Rotation.X, custom.Rotation.Y, custom.Rotation.Z);
        }

        public void ModifyDamage(ref float dam, Dam_EnemyDamageLimb instance)
        {
            if (Equiped.internalEnabled)
                if (instance.m_type == eLimbDamageType.Weakspot)
                    dam = dam * Equiped.PrecisionDamageMulti;
        }

        public void ModifyChargeTime(MWS_ChargeUp instance)
        {
            if (this.Equiped == null) return;
            if (this.Equiped.internalEnabled)
                instance.m_maxDamageTimeDef = this.Equiped.ChargeUpTime;
        }

        public void ModifyAutoAttack(MWS_ChargeUp instance)
        {
            if (this.Equiped == null) return;
            if (this.Equiped.internalEnabled)
                instance.m_autoAttackTime = this.Equiped.AutoAttackTime;
        }

        public void Setup(ItemDataBlock data, MeleeWeaponFirstPerson instance)
        {
            if (this.TryReadData(data.persistentID))
            {
                this.ReplaceData(instance);
            }
        }

        public void OnWield(MeleeWeaponFirstPerson instance)
        {
            if (this.IsValid)
            {
                this.SetTransform(instance.FPItemHolder.m_inventoryLocal.m_wieldedItem.GearPartHolder);
            }
        }

        public Data Equiped { get; set; }

        public bool IsValid => Equiped != null;
    }
}
