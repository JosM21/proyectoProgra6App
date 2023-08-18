using proyectoProgra6App_JoselinM.ViewModels;
using proyectoProgra6App_JoselinM.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace proyectoProgra6App_JoselinM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
