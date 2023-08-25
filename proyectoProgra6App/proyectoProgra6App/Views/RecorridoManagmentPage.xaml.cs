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
    public partial class RecorridoManagmentPage : ContentPage
    {
        RecorridoViewModel viewModel;
        public RecorridoManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecorridoViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddRecorridoAsync(TxtFecha.Text.Trim(),
                                                       TxtHoraS.Text.Trim(),
                                                       TxtLugar.Text.Trim(),
                                                       TxtCosto.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Recorrido creado corecctamente!", "OK");
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
            await Navigation.PushAsync(new RecorridoViewPage());
        }
    }
}