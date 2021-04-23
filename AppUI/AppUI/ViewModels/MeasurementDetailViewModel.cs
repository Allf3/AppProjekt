using AppUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppUI.ViewModels
{
    [QueryProperty(nameof(MeasurementId), nameof(MeasurementId))]
    public class MeasurementDetailViewModel : BaseViewModel
    {
        #region QueryPropertyHelper
        private string measurementId;

        public string MeasurementId
        {
            get
            {
                return measurementId;
            }
            set
            {
                measurementId = value;
                LoadItemId(value);
            }
        }

        #endregion

        #region Basicly Measurement???
        //private Guid measurementID;
        //private DateTime Date;
        //private float Humidity;
        //private float Temperatur;

        private Measurement measurement;
        public Measurement Measurement
        {
            get => measurement;
            set => SetProperty<Measurement>(ref measurement, value);
        }

        #endregion

        #region Commands
        public ICommand DeleteCMD { get; private set; }
        #endregion

        public MeasurementDetailViewModel()
        {
            DeleteCMD = new Command(DeleteItem);
        }

        private async void DeleteItem()
        {
            try
            {
                bool result = await _service.DeleteMeasurementAsync(measurement.ID);
                if (result)
                {
                    MessagingCenter.Send<MeasurementDetailViewModel, Measurement>(this, nameof(DeleteCMD), measurement);

                    //pops current stack
                    await Shell.Current.GoToAsync("..");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void LoadItemId(string stringid)
        {
            // Look at QueryPropertyHelper, runs this method when an id is send to Query.
            try
            {
                Measurement measurementfromDb = await _service.GetMeasurementAsync(Guid.Parse(stringid));

                this.measurement = measurementfromDb;

                //measurement.ID = measurementfromDb.ID;
                //measurement.Date = measurementfromDb.Date;
                //measurement.Humidity = measurementfromDb.Humidity;
                //measurement.Temperatur = measurementfromDb.Temperatur;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Measurement");
            }
        }
    }
}
