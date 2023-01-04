using BepInEx;
using BepInEx.Unity.IL2CPP;
using Dex.Tweaker.Core;
using Dex.Tweaker.Patch;
using HarmonyLib;

namespace Dex.Tweaker;

[BepInPlugin("com.Dex.Tweaker", "Dex.Tweaker", "1.10.0")]
[BepInDependency(Util.MTFOInfo.GUID, BepInDependency.DependencyFlags.HardDependency)]
[BepInProcess("GTFO.exe")]
class Plugin : BasePlugin
{
    public override void Load()
    {
        Harmony = new("com.Dex.Tweaker");
        
        Util.Log.Source = Log;

        ConfigManager.UseDebug = Config.Bind("Logging", "Debug", false, "Use debug log messages?");
        ConfigManager.LoadJson();
        
        //Decouple this as too many patches rely on it
        Harmony.PatchAll(typeof(WardenObjective_OnLocalPlayerStartExpedition));
    }

    public static Harmony Harmony { get; set; }
}