using proyectoProgra6App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace proyectoProgra6App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}