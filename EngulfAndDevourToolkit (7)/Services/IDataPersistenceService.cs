// IDataPersistenceService.cs
using System.Threading.Tasks;

namespace EngulfAndDevourToolkit.Services;

public interface IDataPersistenceService
{
    Task<T[]> LoadListAsync<T>(string fileName) where T : class, new();
    Task SaveListAsync<T>(string fileName, T[] items) where T : class;
}

