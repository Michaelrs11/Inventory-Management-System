using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IMS.BE.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwrod", Prompt = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
