using Dex.Tweaker.DataTransfer;
using HarmonyLib;
using UnityEngine;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(WardenObjectiveManager), nameof(WardenObjectiveManager.OnLocalPlayerStartExpedition))]
class WardenObjectiveManager_OnLocalPlayerStartExpedition_3
{
    public static void Postfix()
    {
        Core.InfectionSpitter.Load();

        if (!Core.InfectionSpitter.SpitterModifiers.TryGetValue(RundownManager.ActiveExpedition.LevelLayoutData, out var config))
        {
            SetValues(DataTransfer.InfectionSpitter.DefaultSpitterConfig);
        }
        else
        {
            SetValues(config);
        }
    }

    public static void SetValues(InfectionSpitterConfig config)
    {
        InfectionSpitter.s_dangerColor = new Color(config.DangerColor.X, config.DangerColor.Y, config.DangerColor.Z);
        InfectionSpitter.s_glowColor = new Color(config.GlowColor.X, config.GlowColor.Y, config.GlowColor.Z);
        InfectionSpitter.s_startGlowColor = new Color(config.StartGlowColor.X, config.StartGlowColor.Y, config.StartGlowColor.Z);
        InfectionSpitter.s_retractedMinScale = new UnityEngine.Vector3(config.RetractedMinScale.X, config.RetractedMinScale.Y, config.RetractedMinScale.Z);

        foreach(var spitter in InfectionSpitter.s_allSpitters)
        {
            spitter.m_scaleOrg *= config.ScaleMulti;
            spitter.transform.localScale *= config.ScaleMulti;
            spitter.m_retractSpeed *= config.RetractSpeedMulti;
            spitter.m_expandSpeed *= config.ExpandSpeedMulti;
            spitter.m_lightRetractSpeed *= config.LightRetractSpeedMulti;
        }
    }
}
