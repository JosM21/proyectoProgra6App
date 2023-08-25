using proyectoProgra6App.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoProgra6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HospedajeViewPage : ContentPage
    {
        ViajeViewModel hospedajeViewModel;
        public HospedajeViewPage()
        {
            InitializeComponent();

            BindingContext = hospedajeViewModel = new ViajeViewModel();

            LoadHospedajeAsync();
        }

        private async void LoadHospedajeAsync()
        {
            GlobalObjects.MiHospedajeLocal.IdHotel = 1;
            LvList.ItemsSource = await hospedajeViewModel.GetHospedajeAsyncV(GlobalObjects.MiHospedajeLocal.IdHotel);
        }
    }
}