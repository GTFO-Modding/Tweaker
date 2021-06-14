//using System;
//using System.IO;
//using System.Collections.Generic;
//using MTFO.Managers;
//using Newtonsoft.Json;
//using UnityEngine;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class ExpeditionButton
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
//                    Tier1 = new Tier()
//                    {
//                        bottomText = new string[] { null, null },
//                        scale = new float[] { 1f, 1f },
//                        position = new float[,]
//                        {
//                            { -375f, 0f, 0f },
//                            {  375f, 0f, 0f }
//                        }
//                    },
//                    Tier2 = new Tier()
//                    {
//                        bottomText = new string[] { null, null, null },
//                        scale = new float[] { 1f, 1f, 1f },
//                        position = new float[,]
//                        {
//                            { -525f,    0f, 0f },
//                            {    0f, -315f, 0f },
//                            {  525f,    0f, 0f }
//                        }
//                    },
//                    Tier3 = new Tier()
//                    {
//                        bottomText = new string[] { null, null },
//                        scale = new float[] { 1f, 1f },
//                        position = new float[,]
//                        {
//                            { -412.5f, 0f, 0f },
//                            {  412.5f, 0f, 0f }
//                        }
//                    },
//                    Tier4 = new Tier()
//                    {
//                        bottomText = new string[] { null },
//                        scale = new float[] { 1f },
//                        position = new float[,]
//                        {
//                            { -75f, 0f, 0f }
//                        }
//                    },
//                    Tier5 = new Tier()
//                    {
//                        bottomText = new string[] { },
//                        scale = new float[] { },
//                        position = new float[,] { }
//                    },
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.ExpeditionButton.json";
//        private static string JsonPath { get; set; }
//        public static Setting Param { get; set; }
//        public struct Setting
//        {
//            public Tier Tier1;
//            public Tier Tier2;
//            public Tier Tier3;
//            public Tier Tier4;
//            public Tier Tier5;
//            public bool internalEnabled;
//        }

//        public struct Tier
//        {
//            public string[] bottomText;
//            public float[] scale;
//            public float[,] position;
//        }
//    }
//}
