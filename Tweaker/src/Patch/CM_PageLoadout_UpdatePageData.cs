using System.Text;
using Dex.Tweaker.Core;
using HarmonyLib;
using CellMenu;
using TMPro;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageLoadout), "UpdatePageData")]
    class CM_PageLoadout_UpdatePageData
    {
        public static void Prefix(CM_PageLoadout __instance)
        {
            ObjectiveModifier.Modifier = null;
        }

        //TODO add config file to allow use of spinning player models
        //[HarmonyPatch(typeof(CM_PageLoadout), "Update")]
        //public static void Postfix(CM_PageLoadout __instance)
        //{
        //    if (__instance.m_playerLobbyBars == null) return;
        //    if (timeEular <= Time.deltaTime)
        //    {
        //        currEular = 0;
        //        timeEular += 16f;
        //    }
        //    else
        //    {
        //        currEular = Mathf.Lerp(currEular, 360, Time.deltaTime / timeEular);
        //        timeEular -= Time.deltaTime;
        //    }
        //    index = 0;
        //    while(index < __instance.m_playerLobbyBars.Count)
        //    {
        //        if (__instance.m_playerLobbyBars[index].m_playerModel != null)
        //        {
        //            __instance.m_playerLobbyBars[index].m_playerModel.transform.localEulerAngles = new Vector3(0, currEular, 0);
        //        }
        //        index += 1;
        //    }
        //}
        //static int index { get; set; }
        //static float timeEular { get; set; }
        //static float currEular { get; set; }
    }
}