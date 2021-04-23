using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUI.Models;
using AppUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeasurementsPage : ContentPage
    {
        MeasurementsViewModel _vm;

        public MeasurementsPage()
        {
            InitializeComponent();

            BindingContext = _vm = new MeasurementsViewModel();

            MessagingCenter.Subscribe<MeasurementDetailViewModel, Measurement>(this, "DeleteCMD", (sender, arg) =>
            {
                DisplayAlert(sender.ToString(), arg.ID.ToString(), "Ok");
            });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.OnAppearing();
        }

    }
}