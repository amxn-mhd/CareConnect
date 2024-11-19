using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.WellBeingApi.Models
{
    public class ReminderSchedulerDto
    {
        [Key]
        public int Totalreminders { get; set; }

        [MaxLength(100)]
        public string Task { get; set; }

        [Required]
        public TimeOnly Time { get; set; }
    }
}
