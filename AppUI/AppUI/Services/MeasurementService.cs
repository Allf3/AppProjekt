using AppUI.Constants;
using AppUI.Models;
using AppUI.Repository;
using MonkeyCache.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;
using System.Linq;
using Xamarin.Essentials;

namespace AppUI.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IGenericRepository _repo;

        public MeasurementService()
        {
            _repo = TinyIoCContainer.Current.Resolve<IGenericRepository>();
        }

        public async Task<IEnumerable<Measurement>> GetMeasurementsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.MeasurementEndPoint
            };

            string urlkey = builder.ToString();

            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                return Barrel.Current.Get<IEnumerable<Measurement>>(key: urlkey);
            }
            if (!Barrel.Current.IsExpired(key: urlkey))
            {
                return Barrel.Current.Get<IEnumerable<Measurement>>(key: urlkey);
            }
            IEnumerable<Measurement> measurements = await _repo.GetAsync<IEnumerable<Measurement>>(urlkey);
            //Saves to cache
            Barrel.Current.Add(key: urlkey, data: measurements, expireIn: TimeSpan.FromSeconds(60));
            return measurements.OrderBy(d => d.Date);
        }

        public async Task<Measurement> GetMeasurementAsync(Guid Id)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.MeasurementEndPoint}/{Id.ToString()}"
            };
            return await _repo.GetAsync<Measurement>(builder.ToString());
        }

        public async Task<bool> AddMeasurementAsync(Measurement measurement)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.MeasurementEndPoint
            };
            await _repo.PostAsync(builder.ToString(), measurement);
            return true;
        }

        public async Task<bool> UpdateMeasurementAsync(Measurement measurement)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.MeasurementEndPoint}/{measurement.ID.ToString()}"
            };
            await _repo.PutAsync(builder.ToString(), measurement);
            return true;
        }


        public async Task<bool> DeleteMeasurementAsync(Guid Id)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.MeasurementEndPoint}/{Id.ToString()}"
            };
            await _repo.DeleteAsync(builder.ToString());
            return true;
        }
    }
}
