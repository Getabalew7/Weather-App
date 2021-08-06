using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Weather_App.Models;
using Weather_App.Views;
using Xamarin.Forms;

namespace Weather_App.ViewModels
{
    public class CityListViewModel : BaseViewModel
    {
        private City _selectedCity;

        public ObservableCollection<City> citys { get; }
        public Command LoadCitysCommand { get; }
        public Command AddCityCommand { get; }
        public Command<City> CityTapped { get; }

        public CityListViewModel()
        {
            Name = "List City";
            citys = new ObservableCollection<City>();
            LoadCitysCommand = new Command(async () => await ExecuteLoadCitysCommand());

            CityTapped = new Command<City>(OnCitySelected);

            AddCityCommand = new Command(OnAddCity);
        }

        async Task ExecuteLoadCitysCommand()
        {
            IsBusy = true;

            try
            {
                citys.Clear();
                var items = await DataStore.GetCitysAsync(true);
                foreach (var item in items)
                {
                    citys.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCity = null;
        }

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                SetProperty(ref _selectedCity, value);
                OnCitySelected(value);
            }
        }

        private async void OnAddCity(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnCitySelected(City city)
        {
            if (city == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(CityDetailViewModel.CityID)}={city.Id}");
        }
    }
}