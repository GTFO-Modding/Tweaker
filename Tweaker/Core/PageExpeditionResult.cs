using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;

namespace Dex.Tweaker.Core
{
    class PageExpeditionResult : ConfigBaseSingle<PageExpeditionResult.Data>
    {
        public class Data : DataBase
        {
            public string Fail { get; set; } = "EXPEDITION FAILED";
            public string Success { get; set; } = "EXPEDITION SUCCESS";
        }
        public override Type[] PatchClasses => new[]
        {
            typeof(CM_PageExpeditionFail_Setup),
            typeof(CM_PageExpeditionSuccess_Setup)
        };

        public void ModifyFail(string text)
        {
            if (this.Config.internalEnabled)
                if (this.Config.Fail != null)
                    text = this.Config.Fail;
        }

        public void ModifySuccess(string text)
        {
            if (this.Config.internalEnabled)
                if (this.Config.Success != null)
                    text = this.Config.Success;
        }
    }
}
