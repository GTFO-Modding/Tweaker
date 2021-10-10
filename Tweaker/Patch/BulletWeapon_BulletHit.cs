using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(BulletWeapon), "BulletHit")]
    class BulletWeapon_BulletHit
    {
        public static void Prefix(ref Weapon.WeaponHitData weaponRayData)
        {
            weaponRayData.damage = CoreManager.Current.DifficultyScale.ScaleBulletDamage(weaponRayData.damage);
        }
    }
}