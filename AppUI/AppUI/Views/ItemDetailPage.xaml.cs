using AppUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppUI.Views
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