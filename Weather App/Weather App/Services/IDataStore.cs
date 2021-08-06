using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather_App.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddCityAsync(T city);
        Task<bool> UpdateCityAsync(T city);
        Task<bool> DeleteCityAsync(string id);
        Task<T> GetCityAsync(string id);
        Task<IEnumerable<T>> GetCitysAsync(bool forceRefresh = false);
    }
}
