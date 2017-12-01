using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class UserGroupFilterDto : FilterDtoBase
    {
        public int? UserId { get; set; }
    }
}