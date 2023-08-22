using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using proyectoProgra6App.Models;
using System.Threading.Tasks;

namespace proyectoProgra6App.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
       
        public Usuario MiUsuario { get; set; }

        public UsuarioRol MiUsuarioRol { get; set; }

        public UsuarioDTO MiUsuarioDTO { get; set; }

        public UserViewModel()
        {
            MiUsuario = new Usuario();
            MiUsuarioRol = new UsuarioRol();
            MiUsuarioDTO = new UsuarioDTO();
        }




        public async Task<UsuarioDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UsuarioDTO userDTO = new UsuarioDTO();

                userDTO = await MiUsuarioDTO.GetUserInfo(pEmail);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }


        public async Task<bool> UpdateUser(UsuarioDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuarioDTO = pUser;

                bool R = await MiUsuarioDTO.UpdateUserAsync();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }


        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            //debemos poder controlar que no se ejecute la operación más de una vez 
            //en este caso hay una funcionalidad pensada para eso en BaseViewModel que 
            //fue heredada al definir esta clase. 
            //Se usará una propiedad llamada "IsBusy" para indicar que está en proceso de ejecución
            //mientras su valor sea verdadero 

            //control de bloqueo de funcionalidad 
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuario.Email = pEmail;
                MiUsuario.Contrasenia = pPassword;

                bool R = await MiUsuario.ValidateUserLogin();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<UsuarioRol>> GetUserRolesAsync()
        {
            try
            {
                List<UsuarioRol> roles = new List<UsuarioRol>();

                roles = await MiUsuarioRol.GetAllUserRolesAsync();

                if (roles == null)
                {
                    return null;
                }

                return roles;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //función de creación de usuario nuevo 
        public async Task<bool> AddUserAsync(string pEmail,
                                             string pPassword,
                                             string pName,
                                             string pBackUpEmail,
                                             string pPhoneNumber,
                                             string pAddress,
                                             int pUserRoleID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuario = new Usuario();

                MiUsuario.Email = pEmail;
                MiUsuario.Contrasenia = pPassword;
                MiUsuario.Nombre = pName;
                MiUsuario.BackUpEmail = pBackUpEmail;
                MiUsuario.Telefono = pPhoneNumber;
                MiUsuario.Direccion = pAddress;
                MiUsuario.FkUsuarioRol = pUserRoleID;

                bool R = await MiUsuario.AddUserAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }





    }
}

