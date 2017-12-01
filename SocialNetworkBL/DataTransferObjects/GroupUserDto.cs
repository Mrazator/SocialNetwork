using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GroupUserDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        //public int UserId { get; set; }

        public int GroupId { get; set; }

        //public GroupDto GroupDto { get; set; }
        public UserDto UserDto { get; set; }
    }
}