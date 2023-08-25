using proyectoProgra6App.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoProgra6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecorridoViewPage : ContentPage
    {
        RecorridoViewModel recorridoViewModel;
        public RecorridoViewPage()
        {
            InitializeComponent();

            BindingContext = recorridoViewModel = new RecorridoViewModel();

            LoadRecorridoAsync();
        }

        private async void LoadRecorridoAsync()
        {
            GlobalObjects.MiRecorridoLocal.IdRecorrido = 1;
            LvList.ItemsSource = await recorridoViewModel.GetRecorridoAsyncV(GlobalObjects.MiRecorridoLocal.IdRecorrido);
        }
    }
}