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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
            InitializeComponent();

            LoadUserName();
        }

        private void LoadUserName()
        {
            LblUserName.Text = GlobalObjects.MiUsuarioLocal.Name.ToUpper();
        }

        private async void BtnUserManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagmentPage());
        }

        private async void Cliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClienteManagmentPage());

        }

        private async void Hospedaje_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HospedajeManagmentPage());

        }

        private async void Recorrido_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecorridoManagmentPage());

        }

        private async void Viaje_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViajeManagmentPage());

        }

        private async void Vuelo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VueloManagmentPage());

        }
    }
}