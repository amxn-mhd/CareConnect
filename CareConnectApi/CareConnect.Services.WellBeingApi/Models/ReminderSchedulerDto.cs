using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.WellBeingApi.Models
{
    public class ReminderSchedulerDto
    {

        [Key]
        [Required]
        [Column("EntryDate")]

        public DateOnly DateTimeOfEntry { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public TimeOnly Time { get; set; }
    }
}
