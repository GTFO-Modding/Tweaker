using AK;
using Player;
using UnityEngine;

namespace Dex.Tweaker.Core;

using Random = UnityEngine.Random;

class ObjectiveModifier
{
    public static void Load()
    {
        foreach (var modifier in ConfigManager.ObjectiveModifier.Config)
        {
            if (!modifier.internalEnabled) continue;
            Modifier = modifier.DataBlockId == RundownManager.ActiveExpedition.MainLayerData.ObjectiveData.DataBlockId ? modifier : null;
            if (Modifier != null)
            {
                InfectionTime = 0f;
                InfectionCurrent = 0f;
                InfectionTarget = 0f;
                TimeLevelStart = Time;
                TimeLimit = TimeLevelStart + modifier.TimeLimit;
                Modifier = modifier;
                break;
            }
        }
        ResourcePack.Load();
    }
    public static void Update(PlayerAgent playerAgent)
    {
        if (Modifier == null) return;
        if (Time <= TimeLimit) return;
        if (Modifier.ExplodePlayer)
        {
            playerAgent.Damage.ExplosionDamage(playerAgent.PlayerData.health, playerAgent.Position, Vector3.one * 100f);
            ulong _ = CellSound.Post(EVENTS.STICKYMINEEXPLODE, playerAgent.Position);
            Modifier = null; // Remove the modifier since the level is done
            return;
        }
        if (!Modifier.Infection.Enabled) return;
        if (InfectionTime <= TimeDelta)
        { // Update infection target based on config amount and a random config rate; sync network and map data
            InfectionCurrent = InfectionTarget;
            InfectionTarget = playerAgent.Damage.Infection + Modifier.Infection.Amount;
            InfectionTime = Random.Range(Modifier.Infection.Rate.Min, Modifier.Infection.Rate.Max);
            if (InfectionCurrent == 0) return;
            playerAgent.Damage.ModifyInfection(new pInfection()
            {
                amount = InfectionCurrent,
                mode = pInfectionMode.Set
            }, true, true);
        }
        else
        { // Smoothly update local infection using supplied target and time based on frame delta
            InfectionCurrent = Mathf.Lerp(playerAgent.Damage.Infection, InfectionTarget, TimeDelta / InfectionTime);
            InfectionTime -= TimeDelta;
            playerAgent.Damage.ModifyInfection(new pInfection()
            {
                amount = InfectionCurrent,
                mode = pInfectionMode.Set
            }, false, false);
        }
    }


    public static DataTransfer.ObjectiveModifier Modifier { get; set; }
    public static bool Enabled { get; set; }
    public static float Time { get => Clock.Time; }
    public static float TimeDelta { get => UnityEngine.Time.deltaTime; }
    public static float TimeLevelStart { get; set; }
    public static float TimeLimit { get; set; }
    public static float InfectionCurrent { get; set; }
    public static float InfectionTarget { get; set; }
    public static float InfectionTime { get; set; }
}