//using System;
//using System.IO;
//using System.Collections.Generic;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class ElevatorCargo
//    {
//        public static void Load()
//        {
//            JsonPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, Name);
//            if (File.Exists(JsonPath))
//            {
//                Param = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(JsonPath));
//            }
//            else
//            {
//                Param = new List<Setting>
//                {
//                    new Setting()
//                    {
//                        DataBlockId = 34U,
//                        ItemID = new uint[] { 133U },
//                        name = "Fog Turbine",
//                        internalEnabled = false
//                    }
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.ElevatorCargo.json";
//        private static string JsonPath { get; set; }
//        public static List<Setting> Param { get; set; }
//        public struct Setting
//        {
//            public uint DataBlockId;
//            public uint[] ItemID;
//            public string name;
//            public bool internalEnabled;
//        }
//    }
//}
