using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetCoursework.Models
{
    public class Biography
    {
        public int BiographyId { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        public string SkillOne { get; set; }

        public string SkillTwo { get; set; }

        public string SkillThree { get; set; }
    }
}