using System;
using System.IO;
using MTFO.Managers;
using Newtonsoft.Json;
using Dex.Tweaker.Util;

namespace Dex.Tweaker.DataTransfer
{
    abstract class ConfigBaseMultiple<T> where T : new()
    {
        [JsonIgnore] public T[] Config { get; private set; }
        public virtual string GetFileName { get => $"{typeof(T).Name}.json"; }
        public ConfigBaseMultiple()
        {
            var jsonPath = Path.Combine(ConfigManager.CustomPath, "Tweaker", GetFileName);
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
