using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.Models;

namespace Weather_App.Services
{
    public class MockDataStore : IDataStore<City>
    {
        readonly List<City> citys;

        public MockDataStore()
        {
            citys = new List<City>()
            {
                new City { Id = Guid.NewGuid().ToString(), Name = "Addis Ababa", Country="Ethiopia",Temrature=23.4 },
                new City { Id = Guid.NewGuid().ToString(), Name = "Hawassa", Country="Ethiopia",Temrature=23.4 },
                new City { Id = Guid.NewGuid().ToString(), Name = "Adama", Country="Ethiopia",Temrature=23.4 },
                new City { Id = Guid.NewGuid().ToString(), Name = "Shashemene", Country="Ethiopia",Temrature=23.4 },
                new City { Id = Guid.NewGuid().ToString(), Name = "Bahir Dar", Country="Ethiopia",Temrature=23.4 },
                new City { Id = Guid.NewGuid().ToString(), Name = "Arba Minch", Country="Ethiopia",Temrature=23.4 }
            };
        }

        public async Task<bool> AddCityAsync(City city)
        {
            citys.Add(city);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            var oldCity = citys.Where((City arg) => arg.Id == city.Id).FirstOrDefault();
            citys.Remove(oldCity);
            citys.Add(city);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCityAsync(string id)
        {
            var oldCity = citys.Where((City arg) => arg.Id == id).FirstOrDefault();
            citys.Remove(oldCity);

            return await Task.FromResult(true);
        }

        public async Task<City> GetCityAsync(string id)
        {
            return await Task.FromResult(citys.FirstOrDefault(s => s.Id == id));
        }

        //public async Task<IEnumerable<City>> GetcitysAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(citys);
        //}

        public async Task<IEnumerable<City>> GetCitysAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(citys);
        }
    }
}