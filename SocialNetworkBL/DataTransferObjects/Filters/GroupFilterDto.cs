using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class GroupFilterDto : FilterDtoBase
    {
        public string GroupName { get; set; }

        public string SubName { get; set; }
    }
}