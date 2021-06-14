//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class ObjectiveModifier
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
//                    DataBlockId = 34,
//                    startTime = 10f,
//                    infection = new Infection()
//                    {
//                        amount = 0.01f,
//                        rateMax = 1.5f,
//                        rateMin = 1.0f
//                    },
//                    instantKill = false,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.ObjectiveModifier.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public uint DataBlockId;
//            public float startTime;
//            public Infection infection;
//            public bool instantKill;
//            public bool internalEnabled;
//        }
//        public struct Infection
//        {
//            public float amount;
//            public float rateMax;
//            public float rateMin;
//        }
//    }
//}