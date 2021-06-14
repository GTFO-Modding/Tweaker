//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class BioTracker
//    {
//        public static void Load()
//        {
//            JsonPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, Name);
//            if(File.Exists(JsonPath))
//            {
//                Param = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(JsonPath));
//            }
//            else
//            {
//                Param = new Settings()
//                {
//                    scanConeDotMin = 0.85f,
//                    maxScanWorldRadius = 70f,
//                    localObjRadius = 0.15f,
//                    enemyObjMinScale = 0.25f,
//                    maxObjs = 20,
//                    maxCourseNodeDistance = 3,
//                    scanDelay = 1.5f,
//                    pulseDuration = 0.5f,
//                    posDelay = 0.85f,
//                    tagDuration = 1f,
//                    rechargeDuration = 8.5f,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.BioTracker.json";
//        private static string JsonPath { get; set; }
//        public static Settings Param { get; set; }
//        public struct Settings
//        {
//            public float scanConeDotMin;
//            public float maxScanWorldRadius;
//            public float localObjRadius;
//            public float enemyObjMinScale;
//            public int maxObjs;
//            public int maxCourseNodeDistance;
//            public float scanDelay;
//            public float pulseDuration;
//            public float posDelay;
//            public float tagDuration;
//            public float rechargeDuration;
//            public bool internalEnabled;
//        }
//    }
//}
