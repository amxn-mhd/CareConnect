using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();

         Task<Doctor> GetDoctorById(int id);

        Task<bool> UpdateDoctor(int id,Doctor doc );

        Task<bool> DeleteDoctor(int id);

        Task<bool> AddDoctor(Doctor doc );







    }
}
