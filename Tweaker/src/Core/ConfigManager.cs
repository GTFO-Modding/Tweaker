using BepInEx.Configuration;
using Dex.Tweaker.Util;

namespace Dex.Tweaker.Core;

class ConfigManager
{
    public static void LoadJson()
    {
        var customPath = Path.Combine(MTFOInfo.CustomPath, "Tweaker");
        if(!Directory.Exists(customPath))
        {
            Directory.CreateDirectory(customPath);
        }

        //Rewrites go below
        BioTracker = new();
        DifficultyScale = new();
        ElevatorCargo = new();
        FoamLauncher = new();
        HackDoorPuzzle = new();
        Hammer = new();
        Mine = new();
        ObjectiveModifier = new();
        PageExpeditionResult = new();
        PlayerAIBot = new();
        PlayerModifier = new();
        ResourcePack = new();
        RundownLayout = new();
        WeakDoorDamage = new();
    }
    public static Config.BioTracker BioTracker { get; private set; }
    public static Config.DifficultyScale DifficultyScale { get; private set; }
    public static Config.ElevatorCargo ElevatorCargo { get; private set; }
    public static Config.FoamLauncher FoamLauncher { get; private set; }
    public static Config.HackDoorPuzzle HackDoorPuzzle { get; private set; }
    public static Config.Hammer Hammer { get; private set; }
    public static Config.InfectionSpitter InfectionSpitter { get; private set; }
    public static Config.Mine Mine { get; private set; }
    public static Config.ObjectiveModifier ObjectiveModifier { get; private set; }
    public static Config.PageExpeditionResult PageExpeditionResult { get; private set; }
    public static Config.PlayerAIBot PlayerAIBot { get; private set; }
    public static Config.PlayerModifier PlayerModifier { get; private set; }
    public static Config.ResourcePack ResourcePack { get; private set; }
    public static Config.RundownLayout RundownLayout { get; private set; }
    public static Config.WeakDoorDamage WeakDoorDamage { get; private set; }
    public static ConfigEntry<bool> UseDebug { get; set; }
}