using System.ComponentModel.DataAnnotations;

namespace TestProj.Models
{
    public class UserRegisterModel
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