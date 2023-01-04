using CellMenu;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using System.Text;
using UnityEngine;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(CM_PageRundown_New), nameof(CM_PageRundown_New.UpdateExpeditionIconProgression))]
class CM_PageRundown_New_UpdateExpeditionIconProgression
{
    public static void Postfix(CM_PageRundown_New __instance)
    {
        if (RundownManager.RundownProgression == null
            || !ConfigManager.RundownLayout.Config.internalEnabled) return;

        var logOutput = new StringBuilder();
        var emptyLog = true;
        var index = 0;
        var format = " {0,8} |";
        var label = new StringBuilder();
        var scale = new StringBuilder();
        var posX = new StringBuilder();
        var posY = new StringBuilder();
        var posZ = new StringBuilder();
        label.Append(string.Format(format, "Label"));
        scale.Append(string.Format(format, "Scale"));
        posX.Append(string.Format(format, "PosX"));
        posY.Append(string.Format(format, "PosY"));
        posZ.Append(string.Format(format, "PosZ"));

        void ReplaceIcon(CM_ExpeditionIcon_New expIcon, DataTransfer.ExpeditionButton tier)
        {
            expIcon.m_decryptErrorText.gameObject.SetActive(true);
            expIcon.m_decryptErrorText.SetText(tier.Decrypt == null ? string.Empty : tier.Decrypt);
            expIcon.SetText(tier.Label);
            expIcon.m_useArtifactHeatText = tier.Heat;
            expIcon.m_statusText.SetText(tier.Status == null ? string.Empty : tier.Status);
            emptyLog = false;
            label.Append(string.Format(format, tier.Label));
            scale.Append(string.Format(format, expIcon.transform.localScale.x));
            posX.Append(string.Format(format, expIcon.transform.localPosition.x));
            posY.Append(string.Format(format, expIcon.transform.localPosition.y));
            posZ.Append(string.Format(format, expIcon.transform.localPosition.z));
            expIcon.transform.localScale = new Vector3(tier.Scale, tier.Scale, tier.Scale);
            expIcon.transform.localPosition = new Vector3(tier.Position.X, tier.Position.Y, tier.Position.Z);
            index = index + 1;
        }

        if (ConfigManager.RundownLayout.Config.Tier1 != null)
            foreach (var tier1 in ConfigManager.RundownLayout.Config.Tier1)
            {
                if (__instance.m_expIconsTier1 == null || __instance.m_expIconsTier1.Count < 1) break;
                ReplaceIcon(__instance.m_expIconsTier1[index], tier1);
            }

        index = 0;
        if (ConfigManager.RundownLayout.Config.Tier2 != null)
            foreach (var tier2 in ConfigManager.RundownLayout.Config.Tier2)
            {
                if (__instance.m_expIconsTier2 == null || __instance.m_expIconsTier2.Count < 1) break;
                ReplaceIcon(__instance.m_expIconsTier2[index], tier2);
            }

        index = 0;
        if (ConfigManager.RundownLayout.Config.Tier3 != null)
            foreach (var tier3 in ConfigManager.RundownLayout.Config.Tier3)
            {
                if (__instance.m_expIconsTier3 == null || __instance.m_expIconsTier3.Count < 1) break;
                ReplaceIcon(__instance.m_expIconsTier3[index], tier3);
            }

        index = 0;
        if (ConfigManager.RundownLayout.Config.Tier4 != null)
            foreach (var tier4 in ConfigManager.RundownLayout.Config.Tier4)
            {
                if (__instance.m_expIconsTier4 == null || __instance.m_expIconsTier4.Count < 1) break;
                ReplaceIcon(__instance.m_expIconsTier4[index], tier4);
            }

        index = 0;
        if (ConfigManager.RundownLayout.Config.Tier5 != null)
            foreach (var tier5 in ConfigManager.RundownLayout.Config.Tier5)
            {
                if (__instance.m_expIconsTier5 == null || __instance.m_expIconsTier5.Count < 1) break;
                ReplaceIcon(__instance.m_expIconsTier5[index], tier5);
            }

        if (emptyLog || DebugLogged) return;
        logOutput.AppendLine("Expedition Icons");
        logOutput.AppendLine(label.ToString());
        logOutput.AppendLine(scale.ToString());
        logOutput.AppendLine(posX.ToString());
        logOutput.AppendLine(posY.ToString());
        logOutput.AppendLine(posZ.ToString());
        Log.Debug(logOutput.ToString());
        DebugLogged = true;
    }
    public static bool DebugLogged { get; set; }
}