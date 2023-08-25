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
    public partial class ViajeViewPage : ContentPage
    {
        ViajeViewModel viajeViewModel;
        public ViajeViewPage()
        {
            InitializeComponent();

            BindingContext = viajeViewModel = new ViajeViewModel();

            LoadViajeAsync();
        }

        private async void LoadViajeAsync()
        {
            GlobalObjects.MiViajeLocal.IdViaje = 5;
            LvList.ItemsSource = await viajeViewModel.GetViajeListByIDV(GlobalObjects.MiViajeLocal.IdViaje);
        }
    }
}