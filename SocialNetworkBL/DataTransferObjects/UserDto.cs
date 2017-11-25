using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserDto : DtoBase
    {
        public string NickName { get; set; }

        public string PasswordHash { get; set; }

        public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;
    }
}
