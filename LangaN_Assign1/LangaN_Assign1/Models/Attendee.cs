using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace LangaN_Assign1.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [DisplayName("Name") ]
        [Required(ErrorMessage = "Please enter your name")]
        public string AttendeeName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Email")]
        public string AttendeeEmail { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}
