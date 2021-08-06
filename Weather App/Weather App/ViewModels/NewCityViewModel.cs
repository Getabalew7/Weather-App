using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Weather_App.Models;
using Xamarin.Forms;

namespace Weather_App.ViewModels
{
    public class NewCityViewModel : BaseViewModel
    {
        private string name;
        private string country;
        private string temrature;

        public NewCityViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(country) && !String.IsNullOrWhiteSpace(temrature);
        }

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
        public string Temrature
        {
            get => temrature;
            set => SetProperty(ref temrature, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            City newCity = new City()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Country = Country,
                Temrature = Convert.ToDouble(Temrature)
            };

            await DataStore.AddCityAsync(newCity);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
