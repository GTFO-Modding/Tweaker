using System;

namespace Dex.Tweaker.DataTransfer
{
    class PageExpeditionResult
    {
        public string Fail { get; set; } = "EXPEDITION FAILED";
        public string Success { get; set; } = "EXPEDITION SUCCESS";
        public bool internalEnabled { get; set; } = false;
    }
}
