using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class GetUserGroupsFilterDto : FilterDtoBase
    {
        public int UserId { get; set; }

        public bool? IsAccepted { get; set; } = null;
    }
}