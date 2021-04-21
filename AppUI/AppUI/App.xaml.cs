using AppUI.Repository;
using AppUI.Services;
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

            container.Register<IMeasurementService, MeasurementService>();

            container.Register<IGenericRepository, GenericRepository>();

            //container.Register<IGenericRepository, GenericRepository>();

            //container.Register<IMeasurementService, MeasurementService>();

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
