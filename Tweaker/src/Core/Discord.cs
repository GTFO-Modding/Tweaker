using System;
using UnityEngine;

namespace Dex.Tweaker.Core
{
    class Discord
    {
        public static string name { get; } = "Mod Server";
        private static string url { get; } = "https://discord.com/invite/rRMPtv4FAh";
        public static Action<int> callback { get; } = (id) => Application.OpenURL(url);
    }
}
