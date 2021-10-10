using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageExpeditionFail), "Setup")]
    class CM_PageExpeditionFail_Setup
    {
        public static void Postfix(CM_PageExpeditionFail __instance)
        {
            CoreManager.Current.PageExpeditionResult.ModifyFail(__instance.m_missionFailed_text.text);
        }
    }
}