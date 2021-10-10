using System;
using System.Reflection;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Util
{
    class Harmony
    {
        public Harmony(string id)
        {
            this.ID = id;
            Instance = new(id);
        }

        class Manager
        {
            public Manager(string id)
            {
                ID = id;
                Instance = new(id);
            }
            public void Patch(Type patchClass)
            {
                this.Instance.PatchAll(patchClass);
            }

            public void Patch(MethodBase original, HarmonyLib.HarmonyMethod prefix, HarmonyLib.HarmonyMethod postfix)
            {
                Instance.Patch(original, prefix, postfix);
            }

            public void Patch(Type original, string method, Type patch, bool prefix = false, bool postfix = false, Type[] arguments = null)
            {
                HarmonyLib.HarmonyMethod harmonyPrefix = prefix ? new(patch, "Prefix", arguments) : null;
                HarmonyLib.HarmonyMethod harmonyPostfix = postfix ? new(patch, "Postfix", arguments) : null;
                this.Instance.Patch(original.GetMethod(method), harmonyPrefix, harmonyPostfix);
            }
            public void Unpatch(Type original, string method, int type = 1)
            {
                this.Instance.Unpatch(original.GetMethod(method), (HarmonyLib.HarmonyPatchType)type, ID);
            }
            public void Unpatch(Type original, string method, HarmonyLib.HarmonyPatchType type = HarmonyLib.HarmonyPatchType.Prefix)
            {
                this.Instance.Unpatch(original.GetMethod(method), type, ID);
            }
            public string ID { get; set; }
            public HarmonyLib.Harmony Instance { get; set; }
        }

        public void Patch(Type patchClass)
        {
            Instance.Patch(patchClass);
        }

        public void Patch(CoreManager config)
        {
            if (config.ServerInteractions.Value)
            {
                Instance.Patch(typeof(DropServerGameSession_ReportLayerProgression));
                Instance.Patch(typeof(DropServerGameSession_ReportSessionResult));
                Instance.Patch(typeof(DropServerManager_GetBoosterImplantPlayerDataAsync));
                Instance.Patch(typeof(DropServerManager_UpdateBoosterImplantPlayerDataAsync));
            }

            if (config.InterfaceFluff.Value)
            {
                Instance.Patch(typeof(CM_StartupScreen_SetText));
            }

            if (config.UseDebug.Value)
            {
                Instance.Patch(typeof(Dam_EnemyDamageLimb_ExplosionDamage));
                Instance.Patch(typeof(Dam_SyncedDamageBase_RegisterDamage));
            }

            if (config.TerminalLocation.Value)
            {
                Instance.Patch(typeof(LG_ComputerTerminalCommandInterpreter_SetupCommands));
            }

            //Decouple this
            Instance.Patch(typeof(CM_PageRundown_New_Update));
            //Decouple nav mesh stuff from objective modifier
            Instance.Patch(typeof(PlayerAgent_UpdateInfectionLocal));
            //Decouple this as too many patches rely on it
            Instance.Patch(typeof(WardenObjective_OnLocalPlayerStartExpedition));

            //Test for terminal stuff
            Instance.Patch(typeof(LG_ComputerTerminal_Setup));
        }

        public string ID { get; private set; }
        private static Manager Instance;
        public static Harmony Current;
    }
}
