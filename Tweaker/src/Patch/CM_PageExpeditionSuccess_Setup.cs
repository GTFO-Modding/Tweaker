using CellMenu;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(CM_PageExpeditionSuccess), nameof(CM_PageExpeditionSuccess.Setup))]
class CM_PageExpeditionSuccess_Setup
{
    public static void Postfix(CM_PageExpeditionSuccess __instance)
    {
        if (ConfigManager.PageExpeditionResult.Config.internalEnabled)
            if (ConfigManager.PageExpeditionResult.Config.Success != null)
                __instance.m_header.text = ConfigManager.PageExpeditionResult.Config.Success;
    }
}