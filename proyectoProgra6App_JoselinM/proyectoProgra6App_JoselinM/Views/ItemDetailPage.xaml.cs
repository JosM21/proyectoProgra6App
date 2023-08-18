using proyectoProgra6App_JoselinM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace proyectoProgra6App_JoselinM.Views
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