﻿using System;
using System.Collections.Generic;
using Weather_App.ViewModels;
using Weather_App.Views;
using Xamarin.Forms;

namespace Weather_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CityListPage), typeof(CityListPage));
           // Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
           // Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
