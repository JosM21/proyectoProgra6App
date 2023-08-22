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
    public partial class UserManagmentPage : ContentPage
    {
        UserViewModel viewModel;
        public UserManagmentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();

            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            TxtID.Text = GlobalObjects.MiUsuarioLocal.IdUser.ToString();
            TxtEmail.Text = GlobalObjects.MiUsuarioLocal.Email;
            TxtName.Text = GlobalObjects.MiUsuarioLocal.Name;
            TxtPhoneNumber.Text = GlobalObjects.MiUsuarioLocal.Phone;
            TxtBackUpEmail.Text = GlobalObjects.MiUsuarioLocal.backupEmail;
            TxtAddress.Text = GlobalObjects.MiUsuarioLocal.Address;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {

            //primero hacemos validación de campos requeridos 

            if (ValidateFields())
            {
                //sacar un respaldo del usuario global tal y como está en este momento 
                //por si algo sale mal en el proceso de update, reversar los cambios 
                UsuarioDTO BackupLocaluser = new UsuarioDTO();
                BackupLocaluser = GlobalObjects.MiUsuarioLocal;

                try
                {
                    GlobalObjects.MiUsuarioLocal.Name = TxtName.Text.Trim();
                    GlobalObjects.MiUsuarioLocal.backupEmail = TxtBackUpEmail.Text.Trim();
                    GlobalObjects.MiUsuarioLocal.Phone = TxtPhoneNumber.Text.Trim();
                    GlobalObjects.MiUsuarioLocal.Address = TxtAddress.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating user info?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MiUsuarioLocal);

                        if (R)
                        {
                            await DisplayAlert(":)", "User Updated!!!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong...", "OK");
                            await Navigation.PopAsync();
                        }

                    }

                }
                catch (Exception)
                {
                    //si algo sale mal reversamos los cambios 
                    GlobalObjects.MiUsuarioLocal = BackupLocaluser;
                    throw;
                }



            }

        }


        private bool ValidateFields()
        {
            bool R = false;
            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                //en este caso están todos los datos requeridos 

                R = true;
            }
            else
            {
                //si falta algún  dato obligatorio 
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Name is required", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Backup Email is required", "OK");
                    TxtBackUpEmail.Focus();
                    return false;
                }

                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Phone Number is required", "OK");
                    TxtPhoneNumber.Focus();
                    return false;
                }

            }

            return R;
        }


        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}