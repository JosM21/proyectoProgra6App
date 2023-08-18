using Acr.UserDialogs;
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
    public partial class AppLoginPage : ContentPage
    {

        UserViewModel viewModel;
        public AppLoginPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new UserViewModel();    

        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {

                    UserDialogs.Instance.ShowLoading("Cargando...");
                    await Task.Delay(2000);


                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    bool R = await viewModel.UserAccessValidation(username, password);



                    if (R)
                    {


                        //GlobalObjects.MyLocalUser = await viewModel.GetUserDataAsync(TxtUserName.Text.Trim());

                        await Navigation.PushAsync(new StartPage());
                        return;

                    }
                    else
                    {
                        await DisplayAlert("Acceso denegado", "Usuario o contraseña incorrectos", "OK");
                        return;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();

                }



            }
            else
            {
                await DisplayAlert("Datos requeridos", "Ususario y contraseña requeridoS...", "OK");
                return;
            }


        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new UserSingUpPage());

        }
    }
}