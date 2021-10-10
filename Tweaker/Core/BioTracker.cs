using System;
using Dex.Tweaker.Util;
using Dex.Tweaker.Patch;
using Gear;
using System.Text;

namespace Dex.Tweaker.Core
{
    class BioTracker : ConfigBaseMultiple<BioTracker.Data>
    {
        public class Data : DataBase
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
        public override Type[] PatchClasses => new[]
        {
            typeof(EnemyScanner_Setup)
        };

        public void Setup(uint persistentID, EnemyScanner instance)
        {
            object[] information =
            {
                instance.m_scanConeDotMin,
                instance.m_maxScanWorldRadius,
                instance.m_localObjRadius,
                instance.m_enemyObjMinScale,
                instance.m_maxObjs,
                instance.m_maxCourseNodeDistance,
                instance.m_scanDelay,
                instance.m_pulseDuration,
                instance.m_posDelay,
                instance.m_tagDuration,
                instance.m_rechargeDuration
            };

            var logOutput = new StringBuilder();
            var format = " {0,21}: {1}";

            logOutput.AppendLine("Enemyscanner Setup");
            foreach (var info in information) logOutput.AppendLine(string.Format(format, nameof(info), info));
            foreach (var config in this.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != persistentID)
                    continue;
                information[ 0] = config.scanConeDotMin;
                information[ 1] = config.maxScanWorldRadius;
                information[ 2] = config.localObjRadius;
                information[ 3] = config.enemyObjMinScale;
                information[ 4] = config.maxObjs;
                information[ 5] = config.maxCourseNodeDistance;
                information[ 6] = config.scanDelay;
                information[ 7] = config.pulseDuration;
                information[ 8] = config.posDelay;
                information[ 9] = config.tagDuration;
                information[10] = config.rechargeDuration;
                logOutput.AppendLine($"Loaded {config.name}[{config.ItemID}]");
                break;
            }
            //m_showingNoTargetsTimer is set in UpdateTagProgress
            Log.Debug(logOutput.ToString());
        }
    }
}
