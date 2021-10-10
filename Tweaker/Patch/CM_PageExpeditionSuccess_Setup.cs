using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageExpeditionSuccess), "Setup")]
    class CM_PageExpeditionSuccess_Setup
    {
        public static void Postfix(CM_PageExpeditionSuccess __instance)
        {
            CoreManager.Current.PageExpeditionResult.ModifySuccess(__instance.m_header.text);
        }
    }
}