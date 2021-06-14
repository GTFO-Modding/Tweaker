using System;
using System.IO;
using Newtonsoft.Json;
using Dex.Tweaker.Util;
using Dex.Tweaker.PluginDependency;

namespace Dex.Tweaker.DataTransfer
{
    abstract class ConfigBaseMultiple<T> where T : new()
    {
        [JsonIgnore] public T[] Config { get; private set; }
        public virtual string GetFileName { get => $"{typeof(T).Name}.json"; }
        public ConfigBaseMultiple()
        {
            var jsonPath = Path.Combine(MTFO.CustomPath, "Tweaker", GetFileName);
            if (File.Exists(jsonPath))
            {
                Config = JsonConvert.DeserializeObject<T[]>(File.ReadAllText(jsonPath));
            }
            else
            {
                Config = new T[] { new T() };
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Config, Formatting.Indented));
            }
            Log.Debug($"Loaded {GetFileName}");
            OnConfigLoaded();
        }
        public abstract void OnConfigLoaded();
    }
}
