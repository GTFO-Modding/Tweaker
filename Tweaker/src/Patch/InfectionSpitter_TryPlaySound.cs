using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(InfectionSpitter), nameof(InfectionSpitter.TryPlaySound))]
class InfectionSpitter_TryPlaySound
{
    public static void Prefix(ref uint id)
    {
        if (!Core.InfectionSpitter.SpitterModifiers.TryGetValue(RundownManager.ActiveExpedition.LevelLayoutData, out var config)) return;

        switch (id)
        {
            case 3688585605: id = config.SoundEventPreSpit; break;
            case 443010049: id = config.SoundEventFoamed; break;
            case 1800579437: id = config.SoundEventScared; break;
            case 1580085442: id = config.SoundEventPrimed; break;
            case 483235199: id = config.SoundEventOut; break;
            case 1548233641: id = config.SoundEventPurrLoop; break;
            case 600057560: id = config.SoundEventIn; break;
            case 3829473415: id = config.SoundEventPurrStop; break;
            case 3124402583: id = config.SoundEventSpit; break;
            case 990281653: id = config.SoundEventReleasedFromFoam; break;
        }
    }
}
