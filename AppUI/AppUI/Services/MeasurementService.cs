using AppUI.Constants;
using AppUI.Models;
using AppUI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;

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
            return await _repo.GetAsync<IEnumerable<Measurement>>(builder.ToString());
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
