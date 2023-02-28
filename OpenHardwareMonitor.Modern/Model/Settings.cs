using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OpenHardwareMonitor.Modern.Model;

public class Settings : ISettings
{
    private Dictionary<string, string> _settings = new();
    private readonly string _filepath;

    public Settings(string filepath)
    {
        _filepath = filepath;

        if (File.Exists(filepath))
        {
            _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(filepath)) ?? new();
        }
    }

    public bool Contains(string name)
    {
        return _settings.ContainsKey(name);
    }

    public string GetValue(string name, string value)
    {
        if (_settings.TryGetValue(name, out var result))
        {
            return result;
        }

        return value;
    }

    public void Remove(string name)
    {
        _settings.Remove(name);
        Save();
    }

    public void SetValue(string name, string value)
    {
        _settings[name] = value;
        Save();
    }

    private void Save()
    {
        File.WriteAllText(_filepath, JsonSerializer.Serialize(_settings));
    }
}
