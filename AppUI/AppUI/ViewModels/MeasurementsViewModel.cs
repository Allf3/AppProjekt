using AppUI.Models;
using AppUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
//Commands
using Xamarin.Forms;

namespace AppUI.ViewModels
{
    public class MeasurementsViewModel : BaseViewModel
    {
        private Measurement selectedMeasurement;

        public ObservableCollection<Measurement> Measurements { get; }

        public Command LoadMeasurementsCMD { get; }
        public Command<Measurement> MeasurementTapped { get; }

        public MeasurementsViewModel()
        {
            Title = "Measurements";
            Measurements = new ObservableCollection<Measurement>();
            LoadMeasurementsCMD = new Command(async () => await LoadMeasurements());
            MeasurementTapped = new Command<Measurement>(OnMeasurementSelected);
        }

        private async void OnMeasurementSelected(Measurement measurement)
        {
            if (measurement == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MeasurementDetailViewModel)}?{nameof(MeasurementDetailViewModel.MeasurementId)}={measurement.ID.ToString()}");
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

    }
}
