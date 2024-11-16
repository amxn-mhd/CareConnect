using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.WellBeingApi.Models
{
    public class SleepAnalyser
    {
        [Key]
        public int EntryId { get; set; }

        [Required]
        [Column("EntryDate")]

        public DateOnly DateTimeOfEntry { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }

        [MaxLength(100)]
        public string Remarks { get; set; }

        

    }
}
