using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using SNetwork;

namespace Dex.Tweaker.Core
{
    class DifficultyScale : ConfigBaseSingle<DifficultyScale.Data>
    {
        public class Data : DataBase
        {
            public Scale Solo { get; set; } = new();
            public Scale Duo { get; set; } = new();
            public Scale Trio { get; set; } = new();
            public Scale Full { get; set; } = new();
        }

        public class Scale
        {
            public float BulletDamage { get; set; } = 1.0f;
            public float DamagePlayer { get; set; } = 1.0f;
            public float HammerDamage { get; set; } = 1.0f;
            public float EnemyWaveCost { get; set; } = 1.0f;
            public float ProgressBioscan { get; set; } = 1.0f;
            public bool enabled { get; set; } = false;
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(BulletWeapon_BulletHit),
            typeof(CP_Bioscan_Core_Master_OnPlayerScanChangedCheckProgress),
            typeof(Dam_PlayerDamageBase_OnIncomingDamage),
            typeof(EnemyCostManager_AddCost),
            typeof(MeleeWeaponFirstPerson_DoAttackDamage)
        };

        public float ScaleBulletDamage(float damage)
        {
            if (!this.Config.internalEnabled) return damage;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (this.Config.Solo.enabled && this.Config.Solo.BulletDamage != 1.0f)
                        damage = damage * this.Config.Solo.BulletDamage;
                    break;
                case 2:
                    if (this.Config.Duo.enabled && this.Config.Duo.BulletDamage != 1.0f)
                        damage = damage * this.Config.Duo.BulletDamage;
                    break;
                case 3:
                    if (this.Config.Trio.enabled && this.Config.Trio.BulletDamage != 1.0f)
                        damage = damage * this.Config.Trio.BulletDamage;
                    break;
                case 4:
                    if (this.Config.Full.enabled && this.Config.Full.BulletDamage != 1.0f)
                        damage = damage * this.Config.Full.BulletDamage;
                    break;
                default:
                    Log.Warning(PLAYER_WARNING);
                    break;
            }
            return damage;
        }

        public void ScaleScanProgress(ref float scanProgress)
        {
            if (!this.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (this.Config.Solo.enabled && this.Config.Solo.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * this.Config.Solo.ProgressBioscan;
                    break;
                case 2:
                    if (this.Config.Duo.enabled && this.Config.Duo.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * this.Config.Duo.ProgressBioscan;
                    break;
                case 3:
                    if (this.Config.Trio.enabled && this.Config.Trio.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * this.Config.Trio.ProgressBioscan;
                    break;
                case 4:
                    if (this.Config.Full.enabled && this.Config.Full.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * this.Config.Full.ProgressBioscan;
                    break;
                default:
                    Log.Warning(PLAYER_WARNING);
                    break;
            }
        }

        public void ScaleDamagePlayer(ref float damage)
        {
            if (!this.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (this.Config.Solo.enabled && this.Config.Solo.DamagePlayer != 1.0f)
                        damage = damage * this.Config.Solo.DamagePlayer;
                    break;
                case 2:
                    if (this.Config.Duo.enabled && this.Config.Duo.DamagePlayer != 1.0f)
                        damage = damage * this.Config.Duo.DamagePlayer;
                    break;
                case 3:
                    if (this.Config.Trio.enabled && this.Config.Trio.DamagePlayer != 1.0f)
                        damage = damage * this.Config.Trio.DamagePlayer;
                    break;
                case 4:
                    if (this.Config.Full.enabled && this.Config.Full.DamagePlayer != 1.0f)
                        damage = damage * this.Config.Full.DamagePlayer;
                    break;
                default:
                    Log.Warning(PLAYER_WARNING);
                    break;
            }
        }

        public void ScaleHammerDamage(float damage)
        {
            if (!this.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (this.Config.Solo.enabled && this.Config.Solo.HammerDamage != 1.0f)
                        damage = damage * this.Config.Solo.HammerDamage;
                    break;
                case 2:
                    if (this.Config.Duo.enabled && this.Config.Duo.HammerDamage != 1.0f)
                        damage = damage * this.Config.Duo.HammerDamage;
                    break;
                case 3:
                    if (this.Config.Trio.enabled && this.Config.Trio.HammerDamage != 1.0f)
                        damage = damage * this.Config.Trio.HammerDamage;
                    break;
                case 4:
                    if (this.Config.Full.enabled && this.Config.Full.HammerDamage != 1.0f)
                        damage = damage * this.Config.Full.HammerDamage;
                    break;
                default:
                    Log.Warning(PLAYER_WARNING);
                    break;
            }
        }

        public void EnemyWaveCost(ref float points)
        {
            if (!this.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (this.Config.Solo.enabled && this.Config.Solo.EnemyWaveCost != 1.0f)
                        points = points * this.Config.Solo.EnemyWaveCost;
                    break;
                case 2:
                    if (this.Config.Duo.enabled && this.Config.Duo.EnemyWaveCost != 1.0f)
                        points = points * this.Config.Duo.EnemyWaveCost;
                    break;
                case 3:
                    if (this.Config.Trio.enabled && this.Config.Trio.EnemyWaveCost != 1.0f)
                        points = points * this.Config.Trio.EnemyWaveCost;
                    break;
                case 4:
                    if (this.Config.Full.enabled && this.Config.Full.EnemyWaveCost != 1.0f)
                        points = points * this.Config.Full.EnemyWaveCost;
                    break;
                default:
                    Log.Warning(PLAYER_WARNING);
                    break;
            }
            Log.Debug($"Adding enemy wave cost of {points} to {EnemyCostManager.Current.m_currentCost} out of {EnemyCostManager.Current.m_allowedTotalCost}");
        }

        const string PLAYER_WARNING = "Abnormal number of players detected in session";
    }
}
