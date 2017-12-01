using System.ComponentModel.DataAnnotations;

namespace SocialNetworkPL.Models
{
    public class LoginModel
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}