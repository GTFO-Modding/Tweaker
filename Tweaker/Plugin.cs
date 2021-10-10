using System;
using BepInEx;
using BepInEx.IL2CPP;
using Dex.Tweaker.Util;

namespace Dex.Tweaker
{
    [BepInPlugin("com.Dex.Tweaker", "Dex.Tweaker", "2.0.0")]
    [BepInDependency(MTFOWrapper.GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("GTFO.exe")]
    class Plugin : BasePlugin
    {
        public override void Load()
        {
            if (Globals.Global.RundownIdToLoad > 1)
            {
                base.Log.LogWarning("Edit the data blocks to load rundown id 1 for tweaker to work");
                base.Unload();
                return;
            }
            Util.Log.Source = base.Log;
            CoreManager.Current = new(base.Config);
            CoreManager.Current.LoadJson();
            Harmony.Current = new("com.Dex.Tweaker");
            Harmony.Current.Patch(CoreManager.Current);
        }
    }
}