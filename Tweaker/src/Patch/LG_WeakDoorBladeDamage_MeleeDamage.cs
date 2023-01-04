using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using LevelGeneration;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(LG_WeakDoorBladeDamage), nameof(LG_WeakDoorBladeDamage.MeleeDamage))]
class LG_WeakDoorBladeDamage_MeleeDamage
{
    public static void Prefix(ref float dam, float environmentMulti)
    {
        damageMem = dam * environmentMulti * ConfigManager.WeakDoorDamage.Config.MeleeDamageMultiplier;
        Log.Debug($"WeakDoor MeleeDamage:\n{dam} Damage\n{environmentMulti} EnvironmentMulti\n{ConfigManager.WeakDoorDamage.Config.MeleeDamageMultiplier} WeakDoor MeleeDamageMultiplier\nresult of {damageMem} damage recorded");
    }

    public static void Postfix(ref float dam, float environmentMulti)
    {
        damageMem = 0;
    }

    public static float damageMem;
}