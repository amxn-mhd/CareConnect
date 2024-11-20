using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.MentelHealthApi.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Doctor name is required.")]
        [StringLength(100, ErrorMessage = "Doctor name can't exceed 100 characters.")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(50, ErrorMessage = "Specialization can't exceed 50 characters.")]
        public string Specialization { get; set; }

        public bool Availability { get; set; } = true;

    }
}
