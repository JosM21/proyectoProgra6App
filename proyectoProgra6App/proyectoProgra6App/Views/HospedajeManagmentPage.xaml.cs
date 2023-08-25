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
    public partial class HospedajeManagmentPage : ContentPage
    {

        ViajeViewModel viewModel;
        public HospedajeManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ViajeViewModel();
        }




        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddHospedajeAsyncV(TxtNombreH.Text.Trim(),
                                                       TxtUbicacion.Text.Trim(),
                                                       TxtTelefono.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Hospedaje creado corecctamente!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Algo salio mal..", "OK");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        private async void BtnVer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HospedajeViewPage());
        }
    }


}
