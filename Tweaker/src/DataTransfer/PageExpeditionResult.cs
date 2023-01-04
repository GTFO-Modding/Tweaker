namespace Dex.Tweaker.DataTransfer;

class PageExpeditionResult : JsonConfig
{
    public string Fail { get; set; } = "EXPEDITION FAILED";
    public string Success { get; set; } = "EXPEDITION SUCCESS";
}
