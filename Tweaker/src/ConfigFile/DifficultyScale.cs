//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class DifficultyScale
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
//                    solo = new Scale()
//                    {
//                        bulletDamage = 1.0f,
//                        damagePlayer = 1.0f,
//                        hammerDamage = 1.0f,
//                        progressBioscan = 1.0f,
//                        enabled = false
//                    },
//                    duo = new Scale()
//                    {
//                        bulletDamage = 1.0f,
//                        damagePlayer = 1.0f,
//                        hammerDamage = 1.0f,
//                        progressBioscan = 1.0f,
//                        enabled = false
//                    },
//                    trio = new Scale()
//                    {
//                        bulletDamage = 1.0f,
//                        damagePlayer = 1.0f,
//                        hammerDamage = 1.0f,
//                        progressBioscan = 1.0f,
//                        enabled = false
//                    },
//                    full = new Scale()
//                    {
//                        bulletDamage = 1.0f,
//                        damagePlayer = 1.0f,
//                        hammerDamage = 1.0f,
//                        progressBioscan = 1.0f,
//                        enabled = false
//                    },
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.DifficultyScale.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public Scale solo;
//            public Scale duo;
//            public Scale trio;
//            public Scale full;
//            public bool internalEnabled;
//        }

//        public struct Scale
//        {
//            public float bulletDamage;
//            public float damagePlayer;
//            public float hammerDamage;
//            public float progressBioscan;
//            public bool enabled;
//        }
//    }
//}