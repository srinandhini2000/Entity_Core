using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Field.Models
{
    public class Login
    {
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
