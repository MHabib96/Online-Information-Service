using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCoursework.Models;

namespace NetCoursework.ViewModels
{
    public class NewUserViewModel
    {
        public IEnumerable<Biography> Biographies { get; set; }
        public RegisteredUsers RegisteredUser { get; set; }
    }
}