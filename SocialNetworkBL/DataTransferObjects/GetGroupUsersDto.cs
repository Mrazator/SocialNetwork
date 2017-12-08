using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GetGroupUsersDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public bool IsAccepted { get; set; }

        public int GroupId { get; set; }

        public GroupProfileUserDto User { get; set; }
    }
}