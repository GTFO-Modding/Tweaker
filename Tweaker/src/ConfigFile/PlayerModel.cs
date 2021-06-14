//using System;
//using System.Collections.Generic;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class PlayerModel
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
//                    localScale = 1.1f,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.PlayerModel.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public float localScale;
//            public bool internalEnabled;
//        }
//    }
//}
