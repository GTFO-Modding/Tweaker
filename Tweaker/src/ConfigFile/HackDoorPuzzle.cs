//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class HackDoorPuzzle
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
//                    ChainedPuzzleToEnter = new uint[1] { 84U },
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.HackDoorPuzzle.json";
//        private static string JsonPath { get; set; }
//        public static Settings Param { get; set; }
//        public struct Settings
//        {
//            public uint[] ChainedPuzzleToEnter;
//            public bool internalEnabled;
//        }
//    }
//}
