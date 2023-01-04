using Dex.Tweaker.Util;
using System;
namespace Dex.Tweaker.Core;

class InfectionSpitter
{
    public static void Load()
    {
        if (!ConfigManager.InfectionSpitter.Config.internalEnabled || IsSetup) return;

        foreach (var spitterConfig in ConfigManager.InfectionSpitter.Config.SpitterConfig)
        {
            if (spitterConfig.internalEnabled) SpitterModifiers.Add(spitterConfig.LevelLayoutID, spitterConfig);
        }
        IsSetup = true;
    }
    public static Dictionary<uint, DataTransfer.InfectionSpitterConfig> SpitterModifiers { get; private set; } = new Dictionary<uint, DataTransfer.InfectionSpitterConfig>();
    public static bool IsSetup { get; set; } = false;
}
