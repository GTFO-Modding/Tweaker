using Dex.Tweaker.Core;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(WardenObjectiveManager), nameof(WardenObjectiveManager.OnLocalPlayerStartExpedition))]
class WardenObjectiveManager_OnLocalPlayerStartExpedition_2
{
    public static void Postfix()
    {
        if (!ConfigManager.PlayerAIBot.Config.internalEnabled) return;

        PlayerAIBot.s_playerInSightMaxDistance = ConfigManager.PlayerAIBot.Config.PlayerInSightMaxDistance;
        PlayerAIBot.s_playerInSightMinCos = ConfigManager.PlayerAIBot.Config.PlayerInSightMinCos;

        PlayerAIBot.s_recognisedItemTypes.Clear();
        foreach (var item in ConfigManager.PlayerAIBot.Config.RecognizedItemTypes) PlayerAIBot.s_recognisedItemTypes.Add(item);

        PlayerAIBot.s_sleeperCheckIntervalNeg = ConfigManager.PlayerAIBot.Config.SleeperCheckIntervalNeg;
        PlayerAIBot.s_sleeperCheckIntervalPos = ConfigManager.PlayerAIBot.Config.SleeperCheckIntervalPos;
        PlayerAIBot.s_sleeperCheckMaxDistance = ConfigManager.PlayerAIBot.Config.SleeperCheckMaxDistance;
        PlayerAIBot.s_sleeperCheckMaxDistanceSQ = ConfigManager.PlayerAIBot.Config.SleeperCheckMaxDistanceSQ;
        PlayerAIBot.s_sleeperCheckResetDistance = ConfigManager.PlayerAIBot.Config.SleeperCheckResetDistance;
        PlayerAIBot.s_sleeperCheckResetDistanceSQ = ConfigManager.PlayerAIBot.Config.SleeperCheckResetDistanceSQ;
        PlayerAIBot.s_twitchingSleeperCheckDistance = ConfigManager.PlayerAIBot.Config.TwitchingSleeperCheckDistance;
        PlayerAIBot.s_twitchingSleeperCheckDistanceSQ = ConfigManager.PlayerAIBot.Config.TwitchingSleeperCheckDistanceSQ;

        RootPlayerBotAction.s_collectItemSearchDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.CollectItemSearchDistance;
        RootPlayerBotAction.s_collectItemStandDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.CollectItemStandDistance;
        RootPlayerBotAction.s_combatDistanceMinMax[0] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.CombatDistanceMin;
        RootPlayerBotAction.s_combatDistanceMinMax[1] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.CombatDistanceMax;
        RootPlayerBotAction.s_enemiesTagDelay[0] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.EnemiesTagDelayA;
        RootPlayerBotAction.s_enemiesTagDelay[1] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.EnemiesTagDelayB;
        RootPlayerBotAction.s_flashlightOnDelay = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.FlashlightOnDelay;
        RootPlayerBotAction.s_followLeaderMaxDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.FollowLeaderMaxDistance;
        RootPlayerBotAction.s_followLeaderRadius = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.FollowLeaderRadius;
        RootPlayerBotAction.s_gateScanSearchDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.GateScanSearchDistance;
        RootPlayerBotAction.s_gateScanStandDistance[0] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.GateScanStandDistanceA;
        RootPlayerBotAction.s_gateScanStandDistance[1] = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.GateScanStandDistanceB;
        RootPlayerBotAction.s_highlightSearchDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.HighlightSearchDistance;
        RootPlayerBotAction.s_highlightStandDistance = ConfigManager.PlayerAIBot.Config.RootPlayerBotAction.HighlightStandDistance;

        PlayerBotActionFollow.s_SearchRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionFollow.SearchRadiusMul;
        PlayerBotActionFollow.s_VerifyRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionFollow.VerifyRadiusMul;

        PlayerBotActionIdle.s_equipWeaponDelay = ConfigManager.PlayerAIBot.Config.PlayerBotActionIdle.EquipWeaponDelay;

        PlayerBotActionUseBioscan.s_SearchRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseBioscan.SearchRadiusMul;
        PlayerBotActionUseBioscan.s_VerifyCurrentPositionRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseBioscan.VerifyCurrentPositionRadiusMul;

        PlayerBotActionAttack.s_meleeReach = ConfigManager.PlayerAIBot.Config.PlayerBotActionAttack.MeleeReach;
        PlayerBotActionAttack.s_optimalBulletRange[0] = ConfigManager.PlayerAIBot.Config.PlayerBotActionAttack.OptimalBulletRangeA;
        PlayerBotActionAttack.s_optimalBulletRange[1] = ConfigManager.PlayerAIBot.Config.PlayerBotActionAttack.OptimalBulletRangeB;
        PlayerBotActionAttack.s_optimalMeleeRange[0] = ConfigManager.PlayerAIBot.Config.PlayerBotActionAttack.OptimalMeleeRangeA;
        PlayerBotActionAttack.s_optimalMeleeRange[1] = ConfigManager.PlayerAIBot.Config.PlayerBotActionAttack.OptimalMeleeRangeB;

        PlayerBotActionRevive.s_ApproachRadius = ConfigManager.PlayerAIBot.Config.PlayerBotActionRevive.ApproachRadius;
        PlayerBotActionRevive.s_TravelHaste = ConfigManager.PlayerAIBot.Config.PlayerBotActionRevive.TravelHaste;
        PlayerBotActionRevive.s_VerifyRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionRevive.VerifyRadiusMul;

        PlayerBotActionUseEnemyScanner.s_ApproachRadius = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseEnemyScanner.ApproachRadius;
        PlayerBotActionUseEnemyScanner.s_nrScanAngles = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseEnemyScanner.NrScanAngles;
        PlayerBotActionUseEnemyScanner.s_scanDurationPerAngle = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseEnemyScanner.ScanDurationPerAngle;
        PlayerBotActionUseEnemyScanner.s_VerifyRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionUseEnemyScanner.VerifyRadiusMul;

        PlayerBotActionCollectItem.s_range = ConfigManager.PlayerAIBot.Config.PlayerBotActionCollectItem.Range;
        PlayerBotActionCollectItem.s_transferDuration = ConfigManager.PlayerAIBot.Config.PlayerBotActionCollectItem.TransferDuration;

        PlayerBotActionShareResourcePack.s_ApproachRadius = ConfigManager.PlayerAIBot.Config.PlayerBotActionShareResourcePack.ApproachRadius;
        PlayerBotActionShareResourcePack.s_duration = ConfigManager.PlayerAIBot.Config.PlayerBotActionShareResourcePack.Duration;
        PlayerBotActionShareResourcePack.s_VerifyRadiusMul = ConfigManager.PlayerAIBot.Config.PlayerBotActionShareResourcePack.VerifyRadiusMul;

        PlayerBotActionEvadeProjectile.s_evasionStartETA = ConfigManager.PlayerAIBot.Config.PlayerBotActionEvadeProjectile.EvasionStartETA;
        PlayerBotActionEvadeProjectile.s_lookStartETA = ConfigManager.PlayerAIBot.Config.PlayerBotActionEvadeProjectile.lookStartETA;
        PlayerBotActionEvadeProjectile.s_sideStepDistance = ConfigManager.PlayerAIBot.Config.PlayerBotActionEvadeProjectile.SideStepDistance;
    }
}