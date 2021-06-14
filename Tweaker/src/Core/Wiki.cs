using System;
using UnityEngine;

namespace Dex.Tweaker.Core
{
    class Wiki
    {
        public static string name { get; } = "MTFO Wiki";
        private static string url { get; } = "https://wiki.mtfo.dev/";
        public static Action<int> callback { get; } = (id) => Application.OpenURL(url);
    }
}
