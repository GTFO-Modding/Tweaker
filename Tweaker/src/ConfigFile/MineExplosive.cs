//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class MineExplosive
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
//                    delay = 0.25f,
//                    radius = 2.5f,
//                    distance = new MinMax()
//                    {
//                        Max = 15f,
//                        Min = 3f
//                    },
//                    damage = new MinMax()
//                    {
//                        Max = 35f,
//                        Min = 15f
//                    },
//                    force = 1000f,
//                    explosionDelay = 0.25f,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.MineExplosive.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public float delay;
//            public float radius;
//            public MinMax distance;
//            public MinMax damage;
//            public float force;
//            public float explosionDelay;
//            public bool internalEnabled;
//        }
//    }
//}
