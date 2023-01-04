using Dex.Tweaker.Util;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dex.Tweaker.DataTransfer;

abstract class ConfigBaseSingle<T> where T : new()
{
    [JsonIgnore] public T Config { get; private set; }
    public virtual string GetFileName { get => $"{typeof(T).Name}.json"; }
    public ConfigBaseSingle()
    {
        var jsonPath = Path.Combine(MTFOInfo.CustomPath, "Tweaker", GetFileName);
        if (File.Exists(jsonPath))
        {
            Config = JsonSerializer.Deserialize<T>(File.ReadAllText(jsonPath), ReadOptions);
        }
        else
        {
            Config = new T();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(Config, WriteOptions)) ;
        }
        Log.Debug($"Loaded {GetFileName}");
        OnConfigLoaded();
    }
    public abstract void OnConfigLoaded();
    [JsonIgnore] private static JsonSerializerOptions ReadOptions = new() { PropertyNameCaseInsensitive = false };
    [JsonIgnore] private static JsonSerializerOptions WriteOptions = new() { WriteIndented = true };
}