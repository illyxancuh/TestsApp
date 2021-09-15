using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProj.Models
{
    public class UserLoginModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Login { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
