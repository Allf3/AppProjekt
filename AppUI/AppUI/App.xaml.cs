using AppUI.Services;
using AppUI.Views;
using System;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            var container = TinyIoCContainer.Current;

            //container.Register<IMeasurementService, MeasurementService>();


            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
