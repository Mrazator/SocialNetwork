using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class GroupUserFilterDto : FilterDtoBase
    {
        //public int? UserId { get; set; }
        public int? GroupId { get; set; }
    }
}