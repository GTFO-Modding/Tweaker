using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;
using UnityEngine;
using System.Text;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateExpeditionIconProgression")]
    class CM_PageRundown_New_UpdateExpeditionIconProgression
    {
        public static void Postfix(CM_PageRundown_New __instance)
        {
            if (RundownManager.RundownProgression == null
                || !ConfigManager.RundownLayout.Config.internalEnabled) return;

            var sb = new StringBuilder();
            var empty = true;

            sb.AppendLine("Expedition Icons");

            var index = 0;
            if (ConfigManager.RundownLayout.Config.Tier1 != null)
                foreach (var tier1 in ConfigManager.RundownLayout.Config.Tier1)
                {
                    if (__instance.m_expIconsTier1 == null || __instance.m_expIconsTier1.Count < 1) break;
                    ReplaceIcon(__instance.m_expIconsTier1[index], tier1);
                    index = index + 1;
                }

            index = 0;
            if (ConfigManager.RundownLayout.Config.Tier2 != null)
                foreach (var tier2 in ConfigManager.RundownLayout.Config.Tier2)
                {
                    if (__instance.m_expIconsTier2 == null || __instance.m_expIconsTier2.Count < 1) break;
                    ReplaceIcon(__instance.m_expIconsTier2[index], tier2);
                    index = index + 1;
                }

            index = 0;
            if (ConfigManager.RundownLayout.Config.Tier3 != null)
                foreach (var tier3 in ConfigManager.RundownLayout.Config.Tier3)
                {
                    if (__instance.m_expIconsTier3 == null || __instance.m_expIconsTier3.Count < 1) break;
                    ReplaceIcon(__instance.m_expIconsTier3[index], tier3);
                    index = index + 1;
                }

            index = 0;
            if (ConfigManager.RundownLayout.Config.Tier4 != null)
                foreach (var tier4 in ConfigManager.RundownLayout.Config.Tier4)
                {
                    if (__instance.m_expIconsTier4 == null || __instance.m_expIconsTier4.Count < 1) break;
                    ReplaceIcon(__instance.m_expIconsTier4[index], tier4);
                    index = index + 1;
                }

            index = 0;
            if (ConfigManager.RundownLayout.Config.Tier5 != null)
                foreach (var tier5 in ConfigManager.RundownLayout.Config.Tier5)
                {
                    if (__instance.m_expIconsTier5 == null || __instance.m_expIconsTier5.Count < 1) break;
                    ReplaceIcon(__instance.m_expIconsTier5[index], tier5);
                    index = index + 1;
                }

            if (empty || DebugLogged) return;
            Log.Debug(sb.ToString());
            DebugLogged = true;

            void ReplaceIcon(CM_ExpeditionIcon_New expIcon, DataTransfer.ExpeditionButton tier)
            {
                expIcon.m_decryptErrorText.gameObject.SetActive(true);
                expIcon.m_decryptErrorText.SetText(tier.Decrypt == null ? string.Empty : tier.Decrypt);
                expIcon.SetText(tier.Label);
                expIcon.m_useArtifactHeatText = tier.Heat;
                expIcon.m_statusText.SetText(tier.Status == null ? string.Empty : tier.Status);
                AppendLine($"\t{tier.Label} position:{expIcon.transform.localPosition.x}, {expIcon.transform.localPosition.y}, {expIcon.transform.localPosition.z}");
                AppendLine($"\t{tier.Label} scale:{expIcon.transform.localScale.x}, {expIcon.transform.localScale.y}, {expIcon.transform.localScale.z}");
                expIcon.transform.localScale = Vector3.one * tier.Scale;
                expIcon.transform.localPosition = new Vector3(tier.Position.X, tier.Position.Y, tier.Position.Z);
            }

            void AppendLine(string str)
            {
                empty = false;
                sb.AppendLine(str);
            }
        }
        public static bool DebugLogged { get; set; }
    }
}