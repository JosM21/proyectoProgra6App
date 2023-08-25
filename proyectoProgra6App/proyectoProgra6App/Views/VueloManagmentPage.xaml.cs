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
    public partial class VueloManagmentPage : ContentPage
    {

        VueloViewModel viewModel;

        
        public VueloManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new VueloViewModel();

            LoadVaijesAsync();
        }

        private async void LoadVaijesAsync()
        {
            PkrViaje.ItemsSource = await viewModel.GetAllViajeAsyncV();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            Viaje SelectedViaje = PkrViaje.SelectedItem as Viaje;



            bool R = await viewModel.AddVueloVAsync(
                                                  TxtDestino.Text.Trim(),
                                                  TxtAerolinea.Text.Trim(),
                                                  TxtFecha.Text.Trim(),
                                                  TxtGate.Text.Trim(),
                                                  TxtHoraD.Text.Trim(),
                                                  TxtHoraA.Text.Trim(),
                                                  SelectedViaje.IdViaje);

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
            await Navigation.PushAsync(new VuelosViewPage());
        }
    }
}