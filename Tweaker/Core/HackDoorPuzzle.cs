using System;
using Dex.Tweaker.Util;
using AK;
using ChainedPuzzles;
using LevelGeneration;
using AIGraph;
using SNetwork;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Core
{
    class HackDoorPuzzle : ConfigBaseMultiple<HackDoorPuzzle.Data>
    {
        public class Data : DataBase
        {
            public uint ChainedPuzzleToEnterID { get; set; } = 84U;
            public uint WaveSettingsID { get; set; } = 3U;
            public uint WavePopulationDataID { get; set; } = 1U;
            public uint SoundEventID { get; set; } = EVENTS.HACKING_PUZZLE_LOCK_ALARM;
            public uint SoundAlarmID { get; set; } = EVENTS.DOOR_ALARM;
            public bool SetInteractionMessage { get; set; } = true;
            public string name { get; set; } = "Default";
        }
        public override Type[] PatchClasses => new[]
        {
            typeof(LG_SecurityDoor_Locks_SetupForChainedPuzzle)
        };

        public void OnSetup(ref ChainedPuzzleInstance puzzleToOpen, LG_SecurityDoor_Locks instance)
        {
            Log.Debug($"Security door chained puzzle id:{puzzleToOpen.Data.persistentID} name:{puzzleToOpen.Data.PublicAlarmName}");
            var isUsable = false;
            var currentPuzzle = 0;
            for (int i = 0; i < this.Config.Length; ++i)
            {
                if (this.Config[i].internalEnabled
                && this.Config[i].ChainedPuzzleToEnterID == puzzleToOpen.Data.persistentID)
                {
                    currentPuzzle = i;
                    isUsable = true;
                }
            }
            if (!isUsable) return;
            instance.m_intOpenDoor.SetActive(false); // Prevent the chained puzzle from being triggered
            instance.m_intHack.SetActive(true);
            if (this.Config[currentPuzzle].SetInteractionMessage)
                instance.m_intOpenDoor.InteractionMessage = instance.m_intHack.InteractionMessage; //possibly add a config to not override the interaction message?
            var hackable = instance.gameObject.AddComponent<LG_GenericHackable>(); //set up a generic hackable since the security door has no miss event
            var sound = instance.m_door.m_sound;
            hackable.add_OnHackSuccess(instance.OnPuzzleHackIntroSolved); //add back the original success of starting the alarm
            hackable.add_OnHackSuccess((Action)(() => { sound.Stop(); })); //stop the alarm sound
            hackable.add_OnHackingMiss((Action<AIG_CourseNode>)(node =>
            {
                var hackFailedAlarm = sound.Post(this.Config[currentPuzzle].SoundEventID);
                var hackFailedEvent = sound.Post(this.Config[currentPuzzle].SoundAlarmID);
                //Figure out the coroutine event? is it even necessary?
                //CoroutineManager.StartCoroutine(this.TamperingWarning(), (Action) null);
                if (!SNet.IsMaster) return;
                Mastermind.Current.TriggerSurvivalWave(
                    refNode: node,
                    settingsID: this.Config[currentPuzzle].WaveSettingsID,
                    populationDataID: this.Config[currentPuzzle].WavePopulationDataID,
                    eventID: out var _
                );
                Log.Debug("Hack missed on zone door!");
            }));
            hackable.Setup(); //required to make use of the component we set up
            instance.m_intHack.Hackable = hackable.Cast<iHackable>(); //replace the hackable object with our own
            Log.Debug($"Added hack lock to zone door with chained puzzle id {puzzleToOpen.Data.persistentID}");
        }
    }
}
