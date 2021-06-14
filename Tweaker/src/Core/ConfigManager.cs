using System;
using System.IO;
using BepInEx.Configuration;
using UnityEngine;

namespace Dex.Tweaker.Core
{
    class ConfigManager
    {
        public static void LoadJson()
        {
            var customPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, "Tweaker");
            if(!Directory.Exists(customPath))
            {
                Directory.CreateDirectory(customPath);
            }

            //Rewrites go below
            BioTracker = new Config.BioTracker();
            DifficultyScale = new Config.DifficultyScale();
            ElevatorCargo = new Config.ElevatorCargo();
            FoamLauncher = new Config.FoamLauncher();
            GamerGlowstick = new Config.GamerGlowstick();
            HackDoorPuzzle = new Config.HackDoorPuzzle();
            Hammer = new Config.Hammer();
            Mine = new Config.Mine();
            NavMesh = new Config.NavMesh();
            ObjectiveModifier = new Config.ObjectiveModifier();
            PageExpeditionResult = new Config.PageExpeditionResult();
            PlayerModifier = new Config.PlayerModifier();
            ResourcePack = new Config.ResourcePack();
            RundownLayout = new Config.RundownLayout();
        }
        public static Config.BioTracker BioTracker { get; private set; }
        public static Config.DifficultyScale DifficultyScale { get; private set; }
        public static Config.ElevatorCargo ElevatorCargo { get; private set; }
        public static Config.FoamLauncher FoamLauncher { get; private set; }
        public static Config.GamerGlowstick GamerGlowstick { get; private set; }
        public static Config.HackDoorPuzzle HackDoorPuzzle { get; private set; }
        public static Config.Hammer Hammer { get; private set; }
        public static Config.Mine Mine { get; private set; }
        public static Config.NavMesh NavMesh { get; private set; }
        public static Config.ObjectiveModifier ObjectiveModifier { get; private set; }
        public static Config.PageExpeditionResult PageExpeditionResult { get; private set; }
        public static Config.PlayerModifier PlayerModifier { get; private set; }
        public static Config.ResourcePack ResourcePack { get; private set; }
        public static Config.RundownLayout RundownLayout { get; private set; }
        public static ConfigEntry<bool> UseDebugNavMesh { get; set; }
        public static ConfigEntry<KeyCode> DebugNavMeshToggle { get; set; }
        public static ConfigEntry<KeyCode> DebugNavMeshUp { get; set; }
        public static ConfigEntry<KeyCode> DebugNavMeshDown { get; set; }
        public static ConfigEntry<KeyCode> DebugNavMeshReset { get; set; }
        public static ConfigEntry<bool> UseDebug { get; set; }
    }
}