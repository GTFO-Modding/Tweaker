namespace Dex.Tweaker.DataTransfer;

class BioTracker : JsonConfig
{
    public float scanConeDotMin { get; set; } = 0.85f;
    public float maxScanWorldRadius { get; set; } = 70f;
    public float localObjRadius { get; set; } = 0.15f;
    public float enemyObjMinScale { get; set; } = 0.25f;
    public int maxObjs { get; set; } = 20;
    public int maxCourseNodeDistance { get; set; } = 3;
    public float scanDelay { get; set; } = 1.5f;
    public float pulseDuration { get; set; } = 0.5f;
    public float posDelay { get; set; } = 0.85f;
    public float tagDuration { get; set; } = 1f;
    public float rechargeDuration { get; set; } = 8.5f;
    public uint ItemID { get; set; } = 28U;
    public string name { get; set; } = "Default";
}