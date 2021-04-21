using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeasurementDetailPage : ContentPage
    {
        MeasurementDetailPage _vm;

        public MeasurementDetailPage()
        {
            InitializeComponent();
        }
    }
}