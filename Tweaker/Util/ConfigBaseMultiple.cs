using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dex.Tweaker.Util
{
    abstract class ConfigBaseMultiple<T> where T : DataBase, new()
    {
        public ConfigBaseMultiple()
        {
            var jsonPath = Path.Combine(MTFOWrapper.CustomPath, GetFileName);
            if (File.Exists(jsonPath))
            {
                Config = JsonSerializer.Deserialize<T[]>(File.ReadAllText(jsonPath), new() { AllowTrailingCommas = true, PropertyNameCaseInsensitive = true });
            }
            else
            {
                Config = new T[] { new T() };
                File.WriteAllText(jsonPath, JsonSerializer.Serialize(Config, new() { WriteIndented = true }));
            }

            Log.Debug($"Loaded {GetFileName}");

            foreach (var config in Config)
            {
                if (config.internalEnabled)
                {
                    foreach (var patch in PatchClasses)
                    {
                        if (patch != null)
                            Harmony.Current.Patch(patch);
                    }
                    break;
                }
            }
        }
        public abstract Type[] PatchClasses { get; }
        [JsonIgnore] public T[] Config { get; private set; }
        public virtual string GetFileName { get => $"{typeof(T).DeclaringType.Name}.json"; }
    }
}
