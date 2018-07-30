using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetCoursework.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Eventdate { get; set; }

        [Required]
        [Display(Name = "Event Subject")]
        public string EventSubject { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        
    }
}