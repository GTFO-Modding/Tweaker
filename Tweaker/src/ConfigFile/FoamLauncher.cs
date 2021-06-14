//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class FoamLauncher
//    {
//        public static void Load()
//        {
//            JsonPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, Name);
//            if (File.Exists(JsonPath))
//            {
//                Param = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(JsonPath));
//            }
//            else
//            {
//                Param = new Settings()
//                {
//                    timeToMaxPressure = 2.5f,
//                    timeToDepleatePressure = 0.8f,
//                    pressureProgressToFire = 0.075f,
//                    meterAngPressure = new MinMax()
//                    {
//                        min = 112f,
//                        max = -108f
//                    },
//                    fireDelay = new MinMax()
//                    {
//                        min = 0.2f,
//                        max = 2f
//                    },
//                    forceSize = new MinMax()
//                    {
//                        min = 14f,
//                        max = 16f
//                    },
//                    spread = new MinMax()
//                    {
//                        min = 1f,
//                        max = 7f
//                    },
//                    burstShots = new MinMaxInt()
//                    {
//                        min = 1,
//                        max = 12
//                    },
//                    burstShotDelay = 0.08f,
//                    noiseScaleTarget = 0.005f,
//                    noiseIntensity = 15f,
//                    meterShakeAng = 8f,
//                    syncTimeout = 2f,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.FoamLauncher.json";
//        private static string JsonPath { get; set; }
//        public static Settings Param { get; set; }
//        public struct Settings
//        {
//            public float timeToMaxPressure;
//            public float timeToDepleatePressure;
//            public float pressureProgressToFire;
//            public MinMax meterAngPressure;
//            public MinMax fireDelay;
//            public MinMax forceSize;
//            public MinMax spread;
//            public MinMaxInt burstShots;
//            public float burstShotDelay;
//            public float noiseScaleTarget;
//            public float noiseIntensity;
//            public float meterShakeAng;
//            public float syncTimeout;
//            public bool internalEnabled;
//        }

//        public struct MinMax
//        {
//            public float min;
//            public float max;
//        }
//        public struct MinMaxInt
//        {
//            public int min;
//            public int max;
//        }
//    }
//}
