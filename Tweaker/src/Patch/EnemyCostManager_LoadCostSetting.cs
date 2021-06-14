//using System;
//using Dex.Tweaker.Util;
//using HarmonyLib;

//namespace Dex.Tweaker.Patch
//{
//    [HarmonyPatch(typeof(EnemyCostManager), "LoadCostSetting", typeof(eDifficulty))]
//    public class EnemyCostManager_LoadCostSetting
//    {
//        public static void Postfix(eDifficulty settingType)
//        {
//            var output = $"Loading cost settings for: EnemyCost_{settingType}";
//            for (int i = 0; i < EnemyCostManager.Current.m_enemyTypeCosts.Count; i++)
//                output = $"{output}\n\t{(eEnemyType)i}:{EnemyCostManager.Current.m_enemyTypeCosts[i]}";
//            Log.Debug(output);
//        }
//    }
//}
