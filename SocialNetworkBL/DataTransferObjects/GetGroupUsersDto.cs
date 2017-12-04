using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GetGroupUsersDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public bool IsAccepted { get; set; }

        public int GroupId { get; set; }

        public UserDto UserDto { get; set; }
    }
}