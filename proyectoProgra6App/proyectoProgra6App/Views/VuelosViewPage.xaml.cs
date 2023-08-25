using proyectoProgra6App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoProgra6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VuelosViewPage : ContentPage
    {
        VueloViewModel vueloViewModel;

        public VuelosViewPage()
        {
            InitializeComponent();

            BindingContext = vueloViewModel = new VueloViewModel();

            LoadVueloAsync();
        }

        private async void LoadVueloAsync()
        {
            GlobalObjects.MiVueloLocal.IdVuelo = 1;
            LvList.ItemsSource = await vueloViewModel.GetVuelosAsyncV(GlobalObjects.MiVueloLocal.IdVuelo);
        }
    }
}