using System;
using MTFO.Managers;

namespace Dex.Tweaker.Util
{
    class MTFOInfo
    {
        public static string CustomPath => ConfigManager.CustomPath;
        public const string GUID = MTFO.MTFO.GUID;
    }
}
