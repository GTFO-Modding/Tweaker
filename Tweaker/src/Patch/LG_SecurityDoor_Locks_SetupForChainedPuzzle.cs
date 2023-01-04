using AIGraph;
using ChainedPuzzles;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using LevelGeneration;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(LG_SecurityDoor_Locks), nameof(LG_SecurityDoor_Locks.SetupForChainedPuzzle))]
class LG_SecurityDoor_Locks_SetupForChainedPuzzle
{
    public static void Postfix(ref ChainedPuzzleInstance puzzleToOpen, LG_SecurityDoor_Locks __instance)
    {
        Log.Debug($"Security door chained puzzle id:{puzzleToOpen.Data.persistentID} name:{puzzleToOpen.Data.PublicAlarmName}");
        var isUsable = false;
        var currentPuzzle = 0;
        for (int i = 0; i < ConfigManager.HackDoorPuzzle.Config.Length; ++i)
        {
            if (ConfigManager.HackDoorPuzzle.Config[i].internalEnabled
                && ConfigManager.HackDoorPuzzle.Config[i].ChainedPuzzleToEnterID == puzzleToOpen.Data.persistentID)
            {
                currentPuzzle = i;
                isUsable = true;
            }
        }
        if (!isUsable) return;
        __instance.m_intOpenDoor.SetActive(false); // Prevent the chained puzzle from being triggered
        __instance.m_intHack.SetActive(true);
        if (ConfigManager.HackDoorPuzzle.Config[currentPuzzle].SetInteractionMessage)
            __instance.m_intOpenDoor.InteractionMessage = __instance.m_intHack.InteractionMessage; //possibly add a config to not override the interaction message?
        var hackable = __instance.gameObject.AddComponent<LG_GenericHackable>(); //set up a generic hackable since the security door has no miss event
        var sound = new CellSoundPlayer(__instance.transform.position);
        hackable.add_OnHackSuccess(__instance.OnPuzzleHackIntroSolved); //add back the original success of starting the alarm
        hackable.add_OnHackSuccess((Action)(()=>{sound.Stop();})); //stop the alarm sound
        hackable.add_OnHackingMiss((Action<AIG_CourseNode>)(node =>
        {
            var hackFailedAlarm = sound.Post(ConfigManager.HackDoorPuzzle.Config[currentPuzzle].SoundEventID);
            var hackFailedEvent = sound.Post(ConfigManager.HackDoorPuzzle.Config[currentPuzzle].SoundAlarmID);
            //Figure out the coroutine event? is it even necessary?
            //CoroutineManager.StartCoroutine(this.TamperingWarning(), (Action) null);
            if (!SNetwork.SNet.IsMaster) return;
            Mastermind.Current.TriggerSurvivalWave(
                refNode: node,
                settingsID: ConfigManager.HackDoorPuzzle.Config[currentPuzzle].WaveSettingsID,
                populationDataID: ConfigManager.HackDoorPuzzle.Config[currentPuzzle].WavePopulationDataID,
                eventID: out var _
            );
            Log.Debug("Hack missed on zone door!");
        }));
        hackable.Setup(); //required to make use of the component we set up
        __instance.m_intHack.Hackable = hackable.Cast<iHackable>(); //replace the hackable object with our own
        Log.Debug($"Added hack lock to zone door with chained puzzle id {puzzleToOpen.Data.persistentID}");
    }
}
