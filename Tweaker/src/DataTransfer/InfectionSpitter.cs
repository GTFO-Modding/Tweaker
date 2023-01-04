namespace Dex.Tweaker.DataTransfer;

class InfectionSpitter : JsonConfig
{
    public List<InfectionSpitterConfig> SpitterConfig { get; set; } = new List<InfectionSpitterConfig>() { new InfectionSpitterConfig() };
    public static InfectionSpitterConfig DefaultSpitterConfig { get; set; } = new InfectionSpitterConfig();
}
