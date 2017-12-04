using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class GetGroupUsersFilterDto : FilterDtoBase
    {
        public int? GroupId { get; set; }

        public bool IsAccepted { get; set; }
    }
}