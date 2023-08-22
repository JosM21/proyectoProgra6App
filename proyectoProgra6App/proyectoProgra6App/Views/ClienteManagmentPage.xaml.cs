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
    public partial class ClienteManagmentPage : ContentPage
    {

        ClienteViewModel viewModel;
        public ClienteManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ClienteViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            bool R = await viewModel.AddClienteAsync(TxtCedula.Text.Trim(),
                                                 TxtEmail.Text.Trim(),
                                                 TxtName.Text.Trim(),
                                                 TxtFechaN.Text.Trim(),
                                                 TxtTelefono.Text.Trim(),
                                                 TxtDireccion.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Usuario creado corecctamente!", "OK");
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
    }
}