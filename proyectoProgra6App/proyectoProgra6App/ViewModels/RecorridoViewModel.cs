using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.ViewModels
{
    public class RecorridoViewModel :BaseViewModel
    {

        public Recorrido MiRecorrido { get; set; }

        public RecorridoViewModel()
        {
            MiRecorrido = new Recorrido();

        }
        //función de creación de usuario nuevo 
        public async Task<bool> AddRecorridoAsync(string pFecha,
                                                  string pHoraS,
                                                  string pLugar,
                                                  string pCosto )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiRecorrido = new Recorrido();

                MiRecorrido.Fecha = pFecha;
                MiRecorrido.HoraSalida = pHoraS;
                MiRecorrido.Lugar = pLugar;
                MiRecorrido.CostoPp = pCosto;



                bool R = await MiRecorrido.AddRecorridoAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

        //creacion de listar VM
        public async Task<ObservableCollection<Recorrido>> GetRecorridoAsyncV(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Recorrido> recorridos = new ObservableCollection<Recorrido>();

                MiRecorrido.IdRecorrido = pID;

                recorridos = await MiRecorrido.GetRecorridoListByIDM();

                if (recorridos == null)
                {
                    return null;
                }
                return recorridos;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

    }
}
