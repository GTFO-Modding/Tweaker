using System;
using Dex.Tweaker.Core;
using BepInEx.Configuration;
using UnityEngine;

namespace Dex.Tweaker.Util
{
    class CoreManager
    {
        public CoreManager(ConfigFile config)
        {
            this.UseDebugNavMesh = config.Bind("Debug Nav Mesh", "Enable", false, "Show where enemies can walk?");
            this.DebugNavMeshToggle = config.Bind("Debug Nav Mesh", "Toggle visibility", KeyCode.F11, "Input key to toggle visibility of the debug nav mesh");
            this.UseDebugNavMesh = config.Bind("Debug Nav Mesh", "Enable", false, "Show where enemies can walk?");
            this.DebugNavMeshToggle = config.Bind("Debug Nav Mesh", "Toggle visibility", KeyCode.F11, "Input key to toggle visibility of the debug nav mesh");
            this.DebugNavMeshUp = config.Bind("Debug Nav Mesh", "Move up", KeyCode.PageUp, "Input key to move debug nav mesh up");
            this.DebugNavMeshDown = config.Bind("Debug Nav Mesh", "Move down", KeyCode.PageDown, "Input key to move debug nav mesh down");
            this.DebugNavMeshReset = config.Bind("Debug Nav Mesh", "Reset position", KeyCode.End, "Input key to reset debug nav mesh position");
            this.UseDebug = config.Bind("Logging", "Debug", false, "Use debug log messages?");
            this.ServerInteractions = config.Bind("Client Patch", "Official Server Interactions", false, "This will disable analytics on game event reporting, most drop server interactions and steam from setting friend data");
            this.InterfaceFluff = config.Bind("Client Patch", "General UI changes", false, "This will enable various ui changes such as the watermark and signature");
            this.TerminalLocation = config.Bind("Client Patch", "Terminal zone location", false, "This will show the current location of a terminal on the screen. It may require all clients to have it enabled otherwise issues may occur.");
        }

        public void LoadJson()
        {
            MTFOWrapper.ValidateCustom("Tweaker");

            //Rewrites go below
            BioTracker = new();
            DifficultyScale = new();
            ElevatorCargo = new();
            FoamLauncher = new();
            GamerGlowstick = new();
            HackDoorPuzzle = new();
            Hammer = new();
            Mine = new();
            NavMesh = new();
            ObjectiveModifier = new();
            PageExpeditionResult = new();
            PlayerModifier = new();
            ResourcePack = new();
            RundownLayout = new();
        }

        public BioTracker BioTracker { get; private set; }
        public DifficultyScale DifficultyScale { get; private set; }
        public ElevatorCargo ElevatorCargo { get; private set; }
        public FoamLauncher FoamLauncher { get; private set; }
        public GamerGlowstick GamerGlowstick { get; private set; }
        public HackDoorPuzzle HackDoorPuzzle { get; private set; }
        public Hammer Hammer { get; private set; }
        public Mine Mine { get; private set; }
        public NavMesh NavMesh { get; private set; }
        public ObjectiveModifier ObjectiveModifier { get; private set; }
        public PageExpeditionResult PageExpeditionResult { get; private set; }
        public PlayerModifier PlayerModifier { get; private set; }
        public ResourcePack ResourcePack { get; private set; }
        public RundownLayout RundownLayout { get; private set; }
        public ConfigEntry<bool> UseDebugNavMesh { get; private set; }
        public ConfigEntry<KeyCode> DebugNavMeshToggle { get; private set; }
        public ConfigEntry<KeyCode> DebugNavMeshUp { get; private set; }
        public ConfigEntry<KeyCode> DebugNavMeshDown { get; private set; }
        public ConfigEntry<KeyCode> DebugNavMeshReset { get; private set; }
        public ConfigEntry<bool> UseDebug { get; private set; }
        public ConfigEntry<bool> ServerInteractions { get; private set; }
        public ConfigEntry<bool> InterfaceFluff { get; private set; }
        public ConfigEntry<bool> TerminalLocation { get; private set; }

        public static CoreManager Current;
    }
}