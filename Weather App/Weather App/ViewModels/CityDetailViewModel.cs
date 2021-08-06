using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Weather_App.Models;
using Xamarin.Forms;

namespace Weather_App.ViewModels
{
    [QueryProperty(nameof(CityID), nameof(CityID))]
    public class CityDetailViewModel : BaseViewModel
    {
        private string cityId;
        private string name;
        private string country;
        private double temrature;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public double Temrature
        {
            get => temrature;
            set => SetProperty(ref temrature, value);
        }

        public string CityID
        {
            get
            {
                return cityId;
            }
            set
            {
                cityId = value;
                LoadCityId(value);
            }
        }

        public async void LoadCityId(string itemId)
        {
            try
            {
                var city = await DataStore.GetCityAsync(itemId);
                Id = city.Id;
                Name = city.Name;
                Country = city.Country;
                Temrature = city.Temrature;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Country");
            }
        }
    }
}
