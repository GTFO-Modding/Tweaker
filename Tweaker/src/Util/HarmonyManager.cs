using System;
using HarmonyLib;

namespace Dex.Tweaker.Util
{
    class HarmonyManager
    {
        public HarmonyManager(string id)
        {
            ID = id;
            Instance = new Harmony(id);
        }
        public void Patch(Type original, string method, Type patch, bool prefix = false, bool postfix = false, Type[] arguments = null)
        {
            var harmonyPrefix = prefix ? new HarmonyMethod(patch, "Prefix", arguments) : null;
            var harmonyPostfix = postfix ? new HarmonyMethod(patch, "Postfix", arguments) : null;
            this.Instance.Patch(original.GetMethod(method), harmonyPrefix, harmonyPostfix);
        }
        public void Unpatch(Type original, string method, int type = 1)
        {
            this.Instance.Unpatch(original.GetMethod(method), (HarmonyPatchType)type, ID);
        }
        public void Unpatch(Type original, string method, HarmonyPatchType type = HarmonyPatchType.Prefix)
        {
            this.Instance.Unpatch(original.GetMethod(method), type, ID);
        }
        public string ID { get; set; }
        public Harmony Instance { get; set; }
    }
}
