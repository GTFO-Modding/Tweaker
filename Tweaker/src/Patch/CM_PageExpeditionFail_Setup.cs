﻿using CellMenu;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(CM_PageExpeditionFail), nameof(CM_PageExpeditionFail.Setup))]
class CM_PageExpeditionFail_Setup
{
    public static void Postfix(CM_PageExpeditionFail __instance)
    {
        if (ConfigManager.PageExpeditionResult.Config.internalEnabled)
            if (ConfigManager.PageExpeditionResult.Config.Fail != null)
                __instance.m_missionFailed_text.text = ConfigManager.PageExpeditionResult.Config.Fail;
    }
}