using System;
using System.Collections.Generic;
using System.ComponentModel;
using Weather_App.Models;
using Weather_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather_App.Views
{
    public partial class NewItemPage : ContentPage
    {
        public City city { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewCityViewModel();
        }
    }
}