using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //creacion de listar VM
        public async Task<ObservableCollection<Cliente>> GetClienteAsyncV(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();

                MiCliente.IdCliente = pID;

                clientes = await MiCliente.GetClientesListByNameM();

                if (clientes == null)
                {
                    return null;
                }
                return clientes;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

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
