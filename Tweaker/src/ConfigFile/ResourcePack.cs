//using System;
//using System.Collections.Generic;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class ResourcePack
//    {
//        public static void Load()
//        {
//            path = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, name);
//            if (File.Exists(path))
//            {
//                param = JsonConvert.DeserializeObject<List<Param>>(File.ReadAllText(path));
//            }
//            else
//            {
//                param = new List<Param>();
//                param.Add(new Param()
//                {
//                    DataBlockId = 34U,
//                    ammoStandardRel = 0.2f,
//                    ammoSpecialRel = 0.2f,
//                    ammoClassRel = 0.2f,
//                    healthAmountRel = 0.2f,
//                    name = "Default",
//                    internalEnabled = false
//                });
//                File.WriteAllText(path, JsonConvert.SerializeObject(param, Formatting.Indented));
//            }
//        }
//        private static string name { get; } = "Tweaker.ResourcePack.json";
//        private static string path { get; set; }
//        public static List<Param> param { get; set; }
//        public struct Param
//        {
//            public uint DataBlockId;
//            public float ammoStandardRel;
//            public float ammoSpecialRel;
//            public float ammoClassRel;
//            public float healthAmountRel;
//            public string name;
//            public bool internalEnabled;
//        }
//    }
//}