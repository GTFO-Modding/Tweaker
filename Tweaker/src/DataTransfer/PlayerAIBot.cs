namespace Dex.Tweaker.DataTransfer;

class PlayerAIBot : JsonConfig
{
    public float PlayerInSightMaxDistance { get; set; } = 15f;
    public float PlayerInSightMinCos { get; set; } = 0.9f;
    public List<uint> RecognizedItemTypes { get; set; } = new List<uint>() { 139, 144, 117, 115, 114, 130, 167, 102, 101, 127, 132 };
    public float SleeperCheckIntervalNeg { get; set; } = 10f;
    public float SleeperCheckIntervalPos { get; set; } = 1.5f;
    public float SleeperCheckMaxDistance { get; set; } = 25f;
    public float SleeperCheckMaxDistanceSQ { get; set; } = 625f;
    public float SleeperCheckResetDistance { get; set; } = 8f;
    public float SleeperCheckResetDistanceSQ { get; set; } = 64f;
    public float TwitchingSleeperCheckDistance { get; set; } = 10f;
    public float TwitchingSleeperCheckDistanceSQ { get; set; } = 100f;
    public RootPlayerBotAction RootPlayerBotAction { get; set; } = new RootPlayerBotAction();
    public PlayerBotActionIdle PlayerBotActionIdle { get; set; } = new PlayerBotActionIdle();
    public PlayerBotActionFollow PlayerBotActionFollow { get; set; } = new PlayerBotActionFollow();
    public PlayerBotActionUseBioscan PlayerBotActionUseBioscan { get; set; } = new PlayerBotActionUseBioscan();
    public PlayerBotActionAttack PlayerBotActionAttack { get; set; } = new PlayerBotActionAttack();
    public PlayerBotActionRevive PlayerBotActionRevive { get; set; } = new PlayerBotActionRevive();
    public PlayerBotActionUseEnemyScanner PlayerBotActionUseEnemyScanner { get; set; } = new PlayerBotActionUseEnemyScanner();
    public PlayerBotActionCollectItem PlayerBotActionCollectItem { get; set; } = new PlayerBotActionCollectItem();
    public PlayerBotActionShareResourcePack PlayerBotActionShareResourcePack { get; set; } = new PlayerBotActionShareResourcePack();
    public PlayerBotActionEvadeProjectile PlayerBotActionEvadeProjectile { get; set; } = new PlayerBotActionEvadeProjectile();
}

class RootPlayerBotAction
{
    public float CollectItemSearchDistance { get; set; } = 15f;
    public float CollectItemStandDistance { get; set; } = 1f;
    public float CombatDistanceMin { get; set; } = 2f;
    public float CombatDistanceMax { get; set; } = 10f;
    public float EnemiesTagDelayA { get; set; } = 6f;
    public float EnemiesTagDelayB { get; set; } = 4f;
    public float FlashlightOnDelay { get; set; } = 1.5f;
    public float FollowLeaderMaxDistance { get; set; } = 10f;
    public float FollowLeaderRadius { get; set; } = 7f;
    public float GateScanSearchDistance { get; set; } = 8f;
    public float GateScanStandDistanceA { get; set; } = 1f;
    public float GateScanStandDistanceB { get; set; } = 3f;
    public float HighlightSearchDistance { get; set; } = 8f;
    public float HighlightStandDistance { get; set; } = 1.5f;
}

class PlayerBotActionIdle
{
    public float EquipWeaponDelay { get; set; } = 6f;
    public float PrioFreezeForTwitcher { get; set; } = 13f;
    public float Prio { get; set; } = 1f;
}

class PlayerBotActionFollow
{
    public float SearchRadiusMul { get; set; } = 0.8f;
    public float VerifyRadiusMul { get; set; } = 1f;
}

class PlayerBotActionUseBioscan
{
    public float SearchRadiusMul { get; set; } = 0.8f;
    public float VerifyCurrentPositionRadiusMul { get; set; } = 0.9f;
}

class PlayerBotActionAttack
{
    public float MeleeReach { get; set; } = 2f;
    public float OptimalBulletRangeA { get; set; } = 2f;
    public float OptimalBulletRangeB { get; set; } = 10f;
    public float OptimalMeleeRangeA { get; set; } = 0.75f;
    public float OptimalMeleeRangeB { get; set; } = 5f;
}

class PlayerBotActionRevive
{
    public float ApproachRadius { get; set; } = 0.8f;
    public float TravelHaste { get; set; } = 0.9f;
    public float VerifyRadiusMul { get; set; } = 1.15f;
}

class PlayerBotActionUseEnemyScanner
{
    public float ApproachRadius { get; set; } = 0.8f;
    public int NrScanAngles { get; set; } = 10;
    public float ScanDurationPerAngle { get; set; } = 0.4f;
    public float VerifyRadiusMul { get; set; } = 1.2f;
}

class PlayerBotActionCollectItem
{
    public float Range { get; set; } = 1.5f;
    public float TransferDuration { get; set; } = 1f;
}

class PlayerBotActionShareResourcePack
{
    public float ApproachRadius { get; set; } = 1.1f;
    public float Duration { get; set; } = 1.5f;
    public float VerifyRadiusMul { get; set; } = 1.15f;
}

class PlayerBotActionEvadeProjectile
{
    public float EvasionStartETA { get; set; } = 0.25f;
    public float lookStartETA { get; set; } = 1f;
    public float SideStepDistance { get; set; } = 2f;
}