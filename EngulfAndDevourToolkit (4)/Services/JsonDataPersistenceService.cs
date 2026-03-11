// JsonDataPersistenceService.cs
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace EngulfAndDevourToolkit.Services;

public class JsonDataPersistenceService : IDataPersistenceService
{
    private readonly IWebHostEnvironment _env;

    public JsonDataPersistenceService(IWebHostEnvironment env)
    {
        _env = env;
    }

    private string GetPath(string fileName) => Path.Combine(_env.WebRootPath, "data", fileName);

    public async Task<T[]> LoadListAsync<T>(string fileName) where T : class, new()
    {
        var path = GetPath(fileName);
        if (!File.Exists(path)) return Array.Empty<T>();

        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<T[]>(json) ?? Array.Empty<T>();
    }

    public async Task SaveListAsync<T>(string fileName, T[] items) where T : class
    {
        var path = GetPath(fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(path, json);
    }
}