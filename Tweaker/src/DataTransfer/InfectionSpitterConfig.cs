namespace Dex.Tweaker.DataTransfer;

class InfectionSpitterConfig : JsonConfig
{
    public uint LevelLayoutID { get; set; } = 0;

    public Vector3 GlowColor { get; set; } = new Vector3(0.05f, 0.5f, 0.375f);
    public Vector3 DangerColor { get; set; } = new Vector3(0.2f, 0.1f, 0f);
    public Vector3 StartGlowColor { get; set; } = new Vector3(0.03f, 0.3f, 0.225f);
    public Vector3 RetractedMinScale { get; set; } = new Vector3(0.8f, 0.7f, 0.8f);

    public float ScaleMulti { get; set; } = 1f;
    public float ExpandSpeedMulti { get; set; } = 1f;
    public float RetractSpeedMulti { get; set; } = 1f;
    public float LightRetractSpeedMulti { get; set; } = 1f;

    public uint SoundEventPreSpit { get; set; } = 3688585605;
    public uint SoundEventFoamed { get; set; } = 443010049;
    public uint SoundEventScared { get; set; } = 1800579437;
    public uint SoundEventPrimed { get; set; } = 1580085442;
    public uint SoundEventOut { get; set; } = 483235199;
    public uint SoundEventPurrLoop { get; set; } = 1548233641;
    public uint SoundEventIn { get; set; } = 600057560;
    public uint SoundEventPurrStop { get; set; } = 3829473415;
    public uint SoundEventSpit { get; set; } = 3124402583;
    public uint SoundEventReleasedFromFoam { get; set; } = 990281653;
}
