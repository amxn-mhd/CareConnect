using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareConnect.Services.SafetyApi.Models
{
    public class ReportIncidentDto
    {

        [Key]

        public int IncidentId { get; set; }

        [Required]
        [Column("EntryDate")]

        public DateOnly DateTimeOfEntry { get; set; }

        [Required]

        public string UserId { get; set; }

        [Required]
        public string TypeOfAccident { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public TimeOnly Time { get; set; }


        public bool AuthorizeEdit { get; set; } = true;


    }
}
