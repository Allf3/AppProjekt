using AppUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppUI.Services
{
    public interface IMeasurementService
    {
        Task<IEnumerable<Measurement>> GetMeasurementsAsync();
        Task<bool> AddMeasurementAsync(Measurement measurement);
        Task<bool> UpdateMeasurementAsync(Measurement measurement);
        Task<bool> DeleteMeasurementAsync(Guid Id);
        Task<Measurement> GetMeasurementAsync(Guid Id);
    }
}
