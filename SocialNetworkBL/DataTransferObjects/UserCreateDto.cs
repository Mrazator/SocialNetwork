using SocialNetwork.Enums;
using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserCreateDto : DtoBase
    {
        [Required(ErrorMessage = "Nick name is required!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Nick name length must be between 4 and 30")]
        public string NickName { get; set; }

        public Visibility VisibilityPreference { get; set; } = Visibility.Visible;

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 30")]
        public string Password { get; set; }
    }
}
