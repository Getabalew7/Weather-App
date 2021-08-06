using System.ComponentModel;
using Weather_App.ViewModels;
using Xamarin.Forms;

namespace Weather_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new CityDetailViewModel();
        }
    }
}