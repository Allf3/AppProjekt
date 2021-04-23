using AppUI.Models;
using AppUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.ChartEntry;
using Xamarin.Forms;
using AppUI.Views;
using Xamarin.Essentials;
using Microcharts;
using SkiaSharp;
using AppUI.Converters;
using System.Globalization;

namespace AppUI.ViewModels
{
    public class MeasurementsViewModel : BaseViewModel
    {
        private Measurement selectedMeasurement;
        public ObservableCollection<Measurement> Measurements { get; }
        public Command LoadMeasurementsCMD { get; }
        public Command<Measurement> MeasurementTapped { get; }

        private Chart temparatureChart;

        public Chart TemperatureChart
        {
            get => temparatureChart;
            set => SetProperty(ref temparatureChart, value);
        }

        public MeasurementsViewModel()
        {
            Title = "Measurements";
            Measurements = new ObservableCollection<Measurement>();
            LoadMeasurementsCMD = new Command(async () => await LoadMeasurements());
            MeasurementTapped = new Command<Measurement>(OnMeasurementSelected);
            IsConnected = Connectivity.NetworkAccess != NetworkAccess.Internet; //Checks connectivity status
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged; //Subscribes to connectivity event.
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            //If connection status changes this code will be called.
            IsConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        private async void OnMeasurementSelected(Measurement measurement)
        {
            if (measurement == null)
                return;

            // This will push the MeasurementDetailPage onto the navigation stack
            string shellurl = $"{nameof(MeasurementDetailPage)}?{nameof(MeasurementDetailViewModel.MeasurementId)}={measurement.ID.ToString()}";
            await Shell.Current.GoToAsync(shellurl);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            selectedMeasurement = null;
        }

        async Task LoadMeasurements()
        {
            IsBusy = true; //Tells rest of viewmodel it's doing something.
            try
            {
                Measurements.Clear(); //Clears the Current Collection.
                IEnumerable<Measurement> NewMeasurements = await _service.GetMeasurementsAsync();
                foreach (var item in NewMeasurements)
                {
                    Measurements.Add(item);
                }

                PopulateANDgenerateChart(NewMeasurements);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false; //Tells rest of viewmodel it's done doing something.
            }
        }

        void PopulateANDgenerateChart(IEnumerable<Measurement> measurements)
        {
            List<Entry> TempEntries = new List<Entry>();
            CultureInfo cultureInfo = new CultureInfo("da-DK");

            foreach (var item in measurements)
            {
                TempEntries.Add(new Entry(item.Temperatur)
                {
                    Color = SKColor.Parse("#77d065"),
                    Label = item.Date.ToString(cultureInfo),
                    ValueLabel = item.Temperatur.ToString()
                }) ;
            }

            TemperatureChart = new LineChart
            {
                Entries = TempEntries,
                LabelTextSize = 32,
                LineSize = 8
            };

        }

        public void Dispose()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

    }
}
