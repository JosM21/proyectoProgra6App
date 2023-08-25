using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.ViewModels
{


    public class ViajeViewModel : BaseViewModel
    {
        public Viaje MyViaje { get; set; }

        public Hospedaje MyHospedaje { get; set; }

        public ViajeViewModel()
        {
            MyViaje = new Viaje();

            MyHospedaje = new Hospedaje();

        }



       // FUNCION DE CREACION VIAJES

        public async Task<bool> AddViajesAsyncV(
                                   string pDestino,
                                   string pFechaS,
                                   string pFechaR,
                                   string pCosto,
                                   int pHospedaje)


        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
               // MyViaje = new Viaje();

                MyViaje.Destino = pDestino;
                MyViaje.FechaSalida = pFechaS;
                MyViaje.FechaRegreso = pFechaR;
                MyViaje.Costo = pCosto;
                MyViaje.FkHospedaje = pHospedaje;


                bool R = await MyViaje.AddViajesAsyncM();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }


        }


        //función de creación HOSPEDAJE
        public async Task<bool> AddHospedajeAsyncV(string pNombreH,
                                             string pUbicacion,
                                             string pTelefono)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                 MyHospedaje = new Hospedaje();

                MyHospedaje.NombreHotel = pNombreH;
                MyHospedaje.Ubicacion = pUbicacion;
                MyHospedaje.Telefono = pTelefono;



                bool R = await MyHospedaje.AddHospedajeAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }
        }

        //carga la lista de hospedajes, que se usaran por ejemplo en el picker de roles en la
        //creación de un usuario nuevo
        public async Task<List<Hospedaje>> GetHospedajesVAsync()
        {
            try
            {
                List<Hospedaje> hospedajes = new List<Hospedaje>();

                hospedajes = await MyHospedaje.GetAllHospedajeAsync();

                if (hospedajes == null)
                {
                    return null;
                }

                return hospedajes;

            }
            catch (Exception)
            {

                throw;
            }
        }





        // LISTAR HOSPEDAJES

        public async Task<ObservableCollection<Hospedaje>> GetHospedajeAsyncV(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Hospedaje> hospedaje = new ObservableCollection<Hospedaje>();

                MyHospedaje.IdHotel = pID;

                hospedaje = await MyHospedaje.GetHospedajeListByHotelM();

                if (hospedaje == null)
                {
                    return null;
                }
                return hospedaje;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        // LISTAR VIAJES

        public async Task<ObservableCollection<Viaje>> GetViajeListByIDV(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Viaje> viaje = new ObservableCollection<Viaje>();

                MyViaje.IdViaje = pID;

                viaje = await MyViaje.GetViajeListByIDM();

                if (viaje == null)
                {
                    return null;
                }
                return viaje;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
    }


}

    

