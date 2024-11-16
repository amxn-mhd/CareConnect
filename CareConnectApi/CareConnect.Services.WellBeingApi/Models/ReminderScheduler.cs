using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.WellBeingApi.Models
{
    public class ReminderScheduler
    {
        [Key]
        public int Totalreminders { get; set; }
        
        [Required]
        [Column("EntryDate")]

        public DateOnly DateTimeOfEntry { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string Task { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        
    }
}
