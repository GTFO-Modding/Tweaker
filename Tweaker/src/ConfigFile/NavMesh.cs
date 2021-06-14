//using System;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class NavMesh
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
//                    agentClimb = 0.5f,
//                    agentHeight = 2f,
//                    agentRadius = 0.25f,
//                    agentSlope = 55f,
//                    minRegionArea = 0f,
//                    overrideTileSize = false,
//                    overrideVoxelSize = false,
//                    tileSize = 768,
//                    voxelSizeDenominator = 3.0f,
//                    useMediumQualityObstacleAvoidance = true,
//                    reduceAgentRadius = true,
//                    internalEnabled = false
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.NavMesh.json";
//        private static string JsonPath { get; set; }
//        public static Settings Param { get; set; }
//        public struct Settings
//        {
//            public float agentClimb;
//            public float agentHeight;
//            public float agentRadius;
//            public float agentSlope;
//            public float minRegionArea;
//            public bool overrideTileSize;
//            public bool overrideVoxelSize;
//            public int tileSize;
//            public float voxelSizeDenominator;
//            public bool useMediumQualityObstacleAvoidance;
//            public bool reduceAgentRadius;
//            public bool internalEnabled;
//        }
//    }
//}
