using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.MentelHealthApi.Services.IService;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace CareConnect.Services.MentelHealthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _DoctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _DoctorService = doctorService;

        }

        // GET: api/Doctors
        [HttpGet]
        public async  Task<IActionResult> GetDoctors()
        {
           var  result=  await _DoctorService.GetDoctors();

            return Ok(result);

        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDoctor(int id)
        {
            var doctor =await _DoctorService.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
           var result= await _DoctorService.UpdateDoctor(id, doctor);

            return new OkObjectResult(result);
        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            var result =_DoctorService.AddDoctor(doctor);
            if (result == null) { return NotFound();
            }
            return Ok(result);  
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
           var result =_DoctorService.DeleteDoctor(id);
            return new OkObjectResult(result);
        }

       
    }
}
