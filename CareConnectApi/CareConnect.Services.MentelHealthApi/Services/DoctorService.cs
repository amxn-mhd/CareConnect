using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.MentelHealthApi.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CareConnect.Services.MentelHealthApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly MentelHealthApiContext _context;

        public DoctorService(MentelHealthApiContext context)
        {
            _context = context;
        }


        public async Task<bool> DeleteDoctor(int id)
        {

            var result = _context.Doctor.FirstOrDefault(doc => doc.DoctorId == id);
            if (result == null)
            {
                return false;

            }
           _context.Doctor.Remove(result);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var result = await _context.Doctor.FirstOrDefaultAsync(doc => doc.DoctorId == id);
           
            return   result;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
           return await _context.Doctor.ToListAsync();
        }

        // changes needed 
        public async Task<bool> UpdateDoctor(int id, Doctor d)
        {
            var result =  (_context.Doctor.FirstOrDefault(d => d.DoctorId == id));

            if (result == null) { return false; }

            result.DoctorName= d.DoctorName;
            result.Specialization  = d.Specialization;
            result.Availability = d.Availability;

            await _context.SaveChangesAsync();

            return true;

        }

       public async  Task<bool> AddDoctor(Doctor doc)
        {
             _context.Doctor.Add(doc);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
