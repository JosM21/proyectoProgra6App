using Newtonsoft.Json;
using proyectoProgra6App.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.ViewModels
{
    public class VueloViewModel : BaseViewModel
    {

        public int IdVuelo { get; set; }
        public string Destino { get; set; } = null!;
        public string Aerolinea { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public string Gate { get; set; } = null!;
        public string HoraDespegue { get; set; } = null!;
        public string? HoraAterrizaje { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int? FkViaje { get; set; }
        public virtual Viaje FkViajeNavigation { get; set; } = null!;


        public Vuelo MyVuelo { get; set; }

        public Viaje MyViaje { get; set; }

        public VueloViewModel()
        {
            MyViaje = new Viaje();
            MyVuelo = new Vuelo();

        }

        // caraga la lista de viajes en vuelos en picker

        public async Task<List<Viaje>> GetAllViajeAsyncV()
        {
            try
            {
                List<Viaje> viajes = new List<Viaje>();

                viajes = await MyViaje.GetAllViajesAsyncM();

                if (viajes == null)
                {
                    return null;
                }

                return viajes;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //creacion de listar VM
        public async Task<ObservableCollection<Vuelo>> GetVuelosAsyncV(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Vuelo> vuelos = new ObservableCollection<Vuelo>();

                MyVuelo.IdVuelo = pID;

                vuelos = await MyVuelo.GetVuelosListByIDM();

                if (vuelos == null)
                {
                    return null;
                }
                return vuelos;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }


        public async Task<bool> AddVueloVAsync(string pDestino,
                                             string pAerolinea,
                                             string pFecha,
                                             string pGate,
                                             string pHoraD,
                                             string pHoraA,
                                             int pViaje)


        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
               // MyVuelo = new Ask();

                MyVuelo.Destino = pDestino;
                MyVuelo.Aerolinea = pAerolinea;
                MyVuelo.Fecha = pFecha;
                MyVuelo.Gate = pGate;
                MyVuelo.HoraDespegue = pHoraD;
                MyVuelo.HoraAterrizaje = pHoraA;
                MyVuelo.FkViaje = pViaje;


                bool R = await MyVuelo.AddVueloMAsync();

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
