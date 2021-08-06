using Weather_App.ViewModels;
using Xamarin.Forms;

namespace Weather_App.Views
{
    public partial class CityListPage : ContentPage
    {
        public CityListPage()
        {
            InitializeComponent();
            BindingContext = new CityListViewModel();
        }
    }
}