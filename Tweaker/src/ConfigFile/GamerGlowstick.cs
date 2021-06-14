//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class GamerGlowstick
//    {
//        public static void Load()
//        {
//            JsonPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, Name);
//            if (File.Exists(JsonPath))
//            {
//                Param = JsonConvert.DeserializeObject<Setting>(File.ReadAllText(JsonPath));
//            }
//            else
//            {
//                Param = new Setting()
//                {
//                    ItemID = 0,
//                    PulseRate = 1f,
//                    Max = new Max()
//                    {
//                        Red = 0.8f,
//                        Green = 0.8f,
//                        Blue = 0.8f
//                    },
//                    Min = new Min()
//                    {
//                        Red = 0.4f,
//                        Green = 0.4f,
//                        Blue = 0.4f
//                    },
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.GamerGlowstick.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public uint ItemID;
//            public float PulseRate;
//            public Max Max;
//            public Min Min;
//            public bool internalEnabled;
//        }
//        public struct Max
//        {
//            public float Red;
//            public float Green;
//            public float Blue;
//        }
//        public struct Min
//        {
//            public float Red;
//            public float Green;
//            public float Blue;
//        }
//    }
//}