using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using MTFO.Managers;
using Dex.Tweaker.Util;

namespace Dex.Tweaker.DataTransfer
{
    abstract class ConfigBaseSingle<T> where T : new()
    {

        [JsonIgnore] public T Config { get; private set; }
        public virtual string GetFileName { get => $"{typeof(T).Name}.json"; }
        public ConfigBaseSingle()
        {
            var jsonPath = Path.Combine(ConfigManager.CustomPath, "Tweaker", GetFileName);
            if(File.Exists(jsonPath))
            {
                Config = JsonSerializer.Deserialize<T>(File.ReadAllText(jsonPath));
            }
            else
            {
                Config = new T();
                File.WriteAllText(jsonPath, JsonSerializer.Serialize(Config, new JsonSerializerOptions() { WriteIndented = true })) ;
            }
            Log.Debug($"Loaded {GetFileName}");
            OnConfigLoaded();
        }
        public abstract void OnConfigLoaded();
    }
}