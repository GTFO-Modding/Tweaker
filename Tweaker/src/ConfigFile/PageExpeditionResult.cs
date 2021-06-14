//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class PageExpeditionResult
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
//                    fail = "EXPEDITION FAILED",
//                    success = "EXPEDITION SUCCESS",
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.PageExpeditionResult.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public string fail;
//            public string success;
//            public bool internalEnabled;
//        }
//    }
//}
