using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public Cliente MiCliente { get; set; }



        public ClienteViewModel()
        {
            MiCliente = new Cliente();

        }
        //función de creación de usuario nuevo 
        public async Task<bool> AddClienteAsync(string pCedula,
                                             string pEmail,
                                             string pNombre,
                                             string pFechaN,
                                             string pTelefono,
                                             string pDireccion)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiCliente = new Cliente();

                MiCliente.Cedula = pCedula;
                MiCliente.Email = pEmail;
                MiCliente.NombreCompleto = pNombre;
                MiCliente.FechaNacimiento = pFechaN;
                MiCliente.Telefono = pTelefono;
                MiCliente.Direccion = pDireccion;
                

                bool R = await MiCliente.AddClienteAsync();

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
