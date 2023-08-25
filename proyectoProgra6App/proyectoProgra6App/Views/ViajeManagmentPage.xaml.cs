using proyectoProgra6App.Models;
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
    public partial class ViajeManagmentPage : ContentPage
    {
        ViajeViewModel viewModel;

        
        public ViajeManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ViajeViewModel();

            LoadHospedajeAsync();
        }

        private async void LoadHospedajeAsync()
        {
            PkrHospedaje.ItemsSource = await viewModel.GetHospedajesVAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

           Hospedaje SelectedHospedaje = PkrHospedaje.SelectedItem as Hospedaje;



            bool R = await viewModel.AddViajesAsyncV(
                                                  TxtDestino.Text.Trim(),
                                                  TxtFechaS.Text.Trim(),
                                                  TxtFechaR.Text.Trim(),
                                                  TxtCosto.Text.Trim(),
                                                  SelectedHospedaje.IdHotel);

            if (R)
            {
                await DisplayAlert(":)", "Viaje creado con exito", "OK");
                await Navigation.PopAsync();


            }
            else
            {
                await DisplayAlert(":(", "Something went wrong", "OK");
            }



        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



        private async void BtnVer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViajeViewPage());
        }
    }
}