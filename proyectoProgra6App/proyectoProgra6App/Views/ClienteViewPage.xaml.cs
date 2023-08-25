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
    public partial class ClienteViewPage : ContentPage
    {
        ClienteViewModel clienteViewModel;
        public ClienteViewPage()
        {
            InitializeComponent();

            BindingContext = clienteViewModel = new ClienteViewModel();

            LoadClienteAsync();
        }

        private async void LoadClienteAsync()
        {
           GlobalObjects.MiClienteLocal.IdCliente = 1;
            LvList.ItemsSource = await clienteViewModel.GetClienteAsyncV(GlobalObjects.MiClienteLocal.IdCliente);
        }
    }
}