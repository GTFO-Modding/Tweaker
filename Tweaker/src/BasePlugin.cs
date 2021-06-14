using System;
using Dex.Tweaker.Patch;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using Dex.Tweaker.PluginDependency;

namespace Dex.Tweaker
{
    [BepInPlugin("com.Dex.Tweaker", "Dex.Tweaker", "1.6.0")]
    [BepInProcess("GTFO.exe")]
    [BepInDependency(MTFO.GUID, BepInDependency.DependencyFlags.HardDependency)]
    class BasePlugin : BepInEx.IL2CPP.BasePlugin
    {
        public override void Load()
        {
            Instance = new Harmony("com.Dex.Tweaker");
            Util.Log.Source = base.Log;
            Core.ConfigManager.UseDebugNavMesh = Config.Bind(new ConfigDefinition("Debug Nav Mesh", "Enable"), false, new ConfigDescription("Show where enemies can walk?"));
            Core.ConfigManager.DebugNavMeshToggle = Config.Bind(new ConfigDefinition("Debug Nav Mesh", "Toggle visibility"), KeyCode.F11, new ConfigDescription("Input key to toggle visibility of the debug nav mesh"));
            Core.ConfigManager.DebugNavMeshUp = Config.Bind(new ConfigDefinition("Debug Nav Mesh", "Move up"), KeyCode.PageUp, new ConfigDescription("Input key to move debug nav mesh up"));
            Core.ConfigManager.DebugNavMeshDown = Config.Bind(new ConfigDefinition("Debug Nav Mesh", "Move down"), KeyCode.PageDown, new ConfigDescription("Input key to move debug nav mesh down"));
            Core.ConfigManager.DebugNavMeshReset = Config.Bind(new ConfigDefinition("Debug Nav Mesh", "Reset position"), KeyCode.End, new ConfigDescription("Input key to reset debug nav mesh position"));
            Core.ConfigManager.UseDebug = Config.Bind(new ConfigDefinition("Logging", "Debug"), false, new ConfigDescription("Use debug log messages?"));
            Core.ConfigManager.LoadJson();

            var serverInteractions = Config.Bind(new ConfigDefinition("Client Patch", "Official Server Interactions"), false, new ConfigDescription("This will disable analytics on game event reporting, most drop server interactions and steam from setting friend data"));
            if (serverInteractions.Value)
            {
                Instance.PatchAll(typeof(DropServerGameSession_ReportLayerProgression));
                Instance.PatchAll(typeof(DropServerGameSession_ReportSessionResult));
                Instance.PatchAll(typeof(DropServerManager_GetBoosterImplantPlayerDataAsync));
                Instance.PatchAll(typeof(DropServerManager_UpdateBoosterImplantPlayerDataAsync));
            }

            var interfaceFluff = Config.Bind(new ConfigDefinition("Client Patch", "General UI changes"), false, new ConfigDescription("This will enable various ui changes such as the watermark and signature"));
            if (interfaceFluff.Value)
            {
                Instance.PatchAll(typeof(CM_PageIntro_Update));
                Instance.PatchAll(typeof(CM_PageLoadout_UpdatePageData));
                Instance.PatchAll(typeof(CM_StartupScreen_SetText));
                Instance.PatchAll(typeof(PUI_Watermark_UpdateWatermark));
            }

            if (Core.ConfigManager.UseDebug.Value)
            {
                Instance.PatchAll(typeof(Dam_EnemyDamageLimb_ExplosionDamage));
                Instance.PatchAll(typeof(Dam_SyncedDamageBase_RegisterDamage));
            }

            var terminalLocation = Config.Bind(new ConfigDefinition("Client Patch", "Terminal zone location"), false, new ConfigDescription("This will show the current location of a terminal on the screen. It may require all clients to have it enabled otherwise issues may occur."));
            if (terminalLocation.Value)
                Instance.PatchAll(typeof(LG_ComputerTerminalCommandInterpreter_SetupCommands));

            //Decouple this
            Instance.PatchAll(typeof(CM_PageRundown_New_Update));
            //Decouple nav mesh stuff from objective modifier
            Instance.PatchAll(typeof(PlayerAgent_UpdateInfectionLocal));
            //Decouple this as too many patches rely on it
            Instance.PatchAll(typeof(WardenObjective_OnLocalPlayerStartExpedition));
        }

        public static Harmony Instance { get; set; }
    }
}