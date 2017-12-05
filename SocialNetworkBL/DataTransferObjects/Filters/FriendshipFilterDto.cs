using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class FriendshipFilterDto : FilterDtoBase
    {
        public int UserId { get; set; }
        public bool IsAccepted { get; set; }
    }
}