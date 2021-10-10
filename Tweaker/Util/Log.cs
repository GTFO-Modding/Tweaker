using System;
using BepInEx.Logging;
using Dex.Tweaker.Core;

namespace Dex.Tweaker.Util
{
    class Log
    {
        public static void Message(object input) => Source.LogMessage(input);
        public static void Info(object input) => Source.LogInfo(input);
        public static void Debug(object input) { if (CoreManager.Current.UseDebug.Value) Source.LogDebug(input); }
        public static void Warning(object input) => Source.LogWarning(input);
        public static void Error(object input) => Source.LogError(input);
        public static void Fatal(object input) => Source.LogFatal(input);
        public static ManualLogSource Source { get; set; }
    }
}
