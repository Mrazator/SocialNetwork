using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserGroupDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public int UserId { get; set; }

        public GroupDto GroupDto { get; set; }
    }
}