using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using Gear;
using HarmonyLib;
using SNetwork;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(BulletWeapon), nameof(BulletWeapon.BulletHit))]
class BulletWeapon_BulletHit
{
    public static void Prefix(ref Weapon.WeaponHitData weaponRayData)
    {
        if (!ConfigManager.DifficultyScale.Config.internalEnabled) return;
        switch (SNet.SessionHub.PlayersInSession.Count)
        {
            case 1:
                if (ConfigManager.DifficultyScale.Config.Solo.enabled && ConfigManager.DifficultyScale.Config.Solo.BulletDamage != 1.0f)
                    weaponRayData.damage = weaponRayData.damage * ConfigManager.DifficultyScale.Config.Solo.BulletDamage;
                break;
            case 2:
                if (ConfigManager.DifficultyScale.Config.Duo.enabled && ConfigManager.DifficultyScale.Config.Duo.BulletDamage != 1.0f)
                    weaponRayData.damage = weaponRayData.damage * ConfigManager.DifficultyScale.Config.Duo.BulletDamage;
                break;
            case 3:
                if (ConfigManager.DifficultyScale.Config.Trio.enabled && ConfigManager.DifficultyScale.Config.Trio.BulletDamage != 1.0f)
                    weaponRayData.damage = weaponRayData.damage * ConfigManager.DifficultyScale.Config.Trio.BulletDamage;
                break;
            case 4:
                if (ConfigManager.DifficultyScale.Config.Full.enabled && ConfigManager.DifficultyScale.Config.Full.BulletDamage != 1.0f)
                    weaponRayData.damage = weaponRayData.damage * ConfigManager.DifficultyScale.Config.Full.BulletDamage;
                break;
            default:
                Log.Warning("Abnormal number of players detected in session");
                break;
        }
    }
}