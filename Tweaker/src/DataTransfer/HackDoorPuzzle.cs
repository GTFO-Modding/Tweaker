using System;
using AK;
using UnityEngine;

namespace Dex.Tweaker.DataTransfer
{
    class HackDoorPuzzle
    {
        public uint ChainedPuzzleToEnterID { get; set; } = 84U;
        public uint WaveSettingsID { get; set; } = 3U;
        public uint WavePopulationDataID { get; set; } = 1U;
        public uint SoundEventID { get; set; } = EVENTS.HACKING_PUZZLE_LOCK_ALARM;
        public uint SoundAlarmID { get; set; } = EVENTS.DOOR_ALARM;
        public bool SetInteractionMessage { get; set; } = true;
        public string name { get; set; } = "Default";
        public bool internalEnabled { get; set; } = false;
    }
}
