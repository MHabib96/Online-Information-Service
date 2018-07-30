using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetCoursework.Models
{
    public class RegisteredUsers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phonenumber { get; set; }

        public Biography Biography { get; set; }

        [ForeignKey("Biography")]
        [Display(Name = "Subject")]
        public int BiographyId { get; set; }
    }
}