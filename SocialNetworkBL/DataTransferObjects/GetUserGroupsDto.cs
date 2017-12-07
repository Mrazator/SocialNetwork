using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GetUserGroupsDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public bool IsAccepted { get; set; } = false;

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public GroupDto Group { get; set; }
    }
}