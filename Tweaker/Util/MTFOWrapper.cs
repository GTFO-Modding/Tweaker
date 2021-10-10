using System;
using System.IO;

namespace Dex.Tweaker.Util
{
    class MTFOWrapper
    {
        public static void ValidateCustom(string path)
        {
            path = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            CustomPath = path;
        }
        public static string CustomPath;
        public const string GUID = MTFO.MTFO.GUID;
    }
}
