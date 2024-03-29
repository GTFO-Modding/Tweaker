﻿using System;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb), "MeleeDamage")]
    class Dam_EnemyDamageLimb_MeleeDamage
    {
        public static void Prefix(ref float dam, Dam_EnemyDamageLimb __instance)
        {
            if (Hammer.Equiped.internalEnabled)
                if (__instance.m_type == eLimbDamageType.Weakspot)
                    dam = dam * Hammer.Equiped.PrecisionDamageMulti;
        }
    }
}