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
            __instance.m_discordButton.OnBtnPressCallback = Discord.callback;
            __instance.m_discordButton.SetText(Discord.name);
            var sb = new StringBuilder();
            sb.AppendLine("Do not play modded content on the official GTFO server or online matchmake lobbies.");
            sb.AppendLine("\nFeel free to join the unofficial discord server linked below and ask people to play.");

            //TODO utilize this method to lock out player in vanilla instance
            __instance.m_movingContentHolder.Find("ShareServerId/ShareText").gameObject.GetComponent<TextMeshPro>()
                .SetText(sb.ToString());
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