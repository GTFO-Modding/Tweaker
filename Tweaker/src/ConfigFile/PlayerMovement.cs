//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class PlayerMovement
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
//                    slideForceScale = 1f,
//                    evadeSpeed = 3f,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.PlayerMovement.json";
//        private static string JsonPath { get; set; }
//        public static Settings Param { get; set; }
//        public struct Settings
//        {
//            public float slideForceScale;
//            public float evadeSpeed;
//            public bool internalEnabled;
//        }
//    }
//}
