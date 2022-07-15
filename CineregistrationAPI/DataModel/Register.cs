using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineregistrationAPI.DataModel
{
    public partial class Register
    {
        public string Phoneno { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Password { get; set; }
    }
}
