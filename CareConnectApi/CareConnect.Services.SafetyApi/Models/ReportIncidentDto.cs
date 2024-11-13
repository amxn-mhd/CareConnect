using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.SafetyApi.Models
{
    public class ReportIncidentDto
    {

        [Key]
        [Required]
        [Column("EntryDate")]

        public DateOnly DateTimeOfEntry { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string TypeOfAccident { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        [MaxLength(100)]
        public string ShortDescription { get; set; }
    }
}
