using System;
using System.Text;
using System.Text.Json.Serialization;
using Dex.Tweaker.Util;
using CellMenu;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Core
{
    class RundownLayout : ConfigBaseSingle<RundownLayout.Data>
    {
        public class Data : DataBase
        {
            public ExpeditionButton[] Tier1 { get; set; } = new[]
{
            new ExpeditionButton("A1", 1.666667f, -450f,    0, 0),
            new ExpeditionButton("A2", 1.666667f,     0, -270, 0),
            new ExpeditionButton("A3", 1.666667f,  450f,    0, 0)
};
            public ExpeditionButton[] Tier2 { get; set; } = new[]
            {
            new ExpeditionButton("B1", 1.428571f, -525,    0, 0),
            new ExpeditionButton("B2", 1.428571f, -175, -210, 0),
            new ExpeditionButton("B3", 1.428571f,  175, -210, 0),
            new ExpeditionButton("B4", 1.428571f,  525,    0, 0)
            };
            public ExpeditionButton[] Tier3 { get; set; } = new[]
            {
            new ExpeditionButton("C1", 1.818182f, -412.5f,       0, 0),
            new ExpeditionButton("C2", 1.818182f,       0, -247.5f, 0),
            new ExpeditionButton("C3", 1.818182f,  412.5f,       0, 0)
            };
            public ExpeditionButton[] Tier4 { get; set; } = new[]
            {
            new ExpeditionButton("D1", 2.5f, -300, 0, 0),
            new ExpeditionButton("D2", 2.5f,  300, 0, 0)
            };
            public ExpeditionButton[] Tier5 { get; set; } = new[]
            {
            new ExpeditionButton("E1", 10f, -75, 0, 0)
            };
            public bool HideProgression { get; set; } = true;
            public bool HideTiers { get; set; } = true;
        }

        public class ExpeditionButton
        {
            public ExpeditionButton() { }
            public ExpeditionButton(string label, float scale, float x, float y, float z, string decrypt = null, bool heat = false, string status = null)
            {
                Decrypt = decrypt;
                Label = label;
                Heat = heat;
                Status = status;
                Scale = scale;
                Position = new(x, y, z);
            }
            public string Decrypt { get; set; }
            public string Label { get; set; }
            public bool Heat { get; set; }
            public string Status { get; set; }
            public float Scale { get; set; }
            public Vector3 Position { get; set; }

            [JsonIgnore] private float x;
            [JsonIgnore] private float y;
            [JsonIgnore] private float z;
        }
        
        class LogOutput
        {
            public LogOutput(string format)
            {
                this.Empty = true;
                this.Result = new();
                this.Format = format;
                this.Label = new();
                this.Scale = new();
                this.PosX = new();
                this.PosY = new();
                this.PosZ = new();
                this.Append("Label", "Scale", "PosX", "PosY", "PosZ");
            }

            public void Append(object label, object scale, object posX, object posY, object posZ)
            {

                this.Label.Append(string.Format(this.Format, label));
                this.Scale.Append(string.Format(this.Format, scale));
                this.PosX.Append(string.Format(this.Format, posX));
                this.PosY.Append(string.Format(this.Format, posY));
                this.PosZ.Append(string.Format(this.Format, posZ));
            }

            public void ShowResult(string title)
            {
                if (this.Empty || Logged) return;
                this.Result.AppendLine(title);
                this.Result.AppendLine(this.Label.ToString());
                this.Result.AppendLine(this.Scale.ToString());
                this.Result.AppendLine(this.PosX.ToString());
                this.Result.AppendLine(this.PosY.ToString());
                this.Result.AppendLine(this.PosZ.ToString());
                Log.Debug(this.Result.ToString());
                Logged = true;
            }

            public static bool Logged;
            public bool Empty;
            internal StringBuilder Result;
            internal string Format;
            internal StringBuilder Label;
            internal StringBuilder Scale;
            internal StringBuilder PosX;
            internal StringBuilder PosY;
            internal StringBuilder PosZ;
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(CM_PageRundown_New_UpdateExpeditionIconProgression)
        };

        public void ModifyUpdate(CM_PageRundown_New instance)
        {
            if (!this.Config.internalEnabled) return;

            if (this.Config.HideProgression)
                instance.m_tierMarkerSectorSummary.SetVisible(false);

            if (!this.Config.HideTiers) return;

            instance.m_tierMarker1.SetVisible(false);
            instance.m_tierMarker2.SetVisible(false);
            instance.m_tierMarker3.SetVisible(false);
            instance.m_tierMarker4.SetVisible(false);
            instance.m_tierMarker5.SetVisible(false);
        }

        public void ModifyIcons(CM_PageRundown_New instance)
        {
            if (RundownManager.RundownProgression == null
            || !this.Config.internalEnabled) return;

            var index = 0;
            var logOutput = new LogOutput(" {0,8} |");

            void ReplaceIcon(CM_ExpeditionIcon_New expIcon, ExpeditionButton tier)
            {
                expIcon.m_decryptErrorText.gameObject.SetActive(true);
                expIcon.m_decryptErrorText.SetText(tier.Decrypt == null ? string.Empty : tier.Decrypt);
                expIcon.SetText(tier.Label);
                expIcon.m_useArtifactHeatText = tier.Heat;
                expIcon.m_statusText.SetText(tier.Status == null ? string.Empty : tier.Status);
                if (!LogOutput.Logged)
                {
                    logOutput.Append(
                        tier.Label,
                        expIcon.transform.localScale.x,
                        expIcon.transform.localPosition.x,
                        expIcon.transform.localPosition.y,
                        expIcon.transform.localPosition.z
                    );
                    logOutput.Empty = false;
                }
                expIcon.transform.localScale.Set(tier.Scale, tier.Scale, tier.Scale);
                expIcon.transform.localPosition.Set(tier.Position.X, tier.Position.Y, tier.Position.Z);
                index = index + 1;
            }

            if (this.Config.Tier1 != null)
                foreach (var tier1 in this.Config.Tier1)
                {
                    if (instance.m_expIconsTier1 == null || instance.m_expIconsTier1.Count < 1) break;
                    ReplaceIcon(instance.m_expIconsTier1[index], tier1);
                }

            index = 0;
            if (this.Config.Tier2 != null)
                foreach (var tier2 in this.Config.Tier2)
                {
                    if (instance.m_expIconsTier2 == null || instance.m_expIconsTier2.Count < 1) break;
                    ReplaceIcon(instance.m_expIconsTier2[index], tier2);
                }

            index = 0;
            if (this.Config.Tier3 != null)
                foreach (var tier3 in this.Config.Tier3)
                {
                    if (instance.m_expIconsTier3 == null || instance.m_expIconsTier3.Count < 1) break;
                    ReplaceIcon(instance.m_expIconsTier3[index], tier3);
                }

            index = 0;
            if (this.Config.Tier4 != null)
                foreach (var tier4 in this.Config.Tier4)
                {
                    if (instance.m_expIconsTier4 == null || instance.m_expIconsTier4.Count < 1) break;
                    ReplaceIcon(instance.m_expIconsTier4[index], tier4);
                }

            index = 0;
            if (this.Config.Tier5 != null)
                foreach (var tier5 in this.Config.Tier5)
                {
                    if (instance.m_expIconsTier5 == null || instance.m_expIconsTier5.Count < 1) break;
                    ReplaceIcon(instance.m_expIconsTier5[index], tier5);
                }

            logOutput.ShowResult("Expedition Icons");
        }
    }
}
