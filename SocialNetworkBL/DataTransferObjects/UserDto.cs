using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Enums;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserDto : DtoBase
    {
        public string NickName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;
    }
}