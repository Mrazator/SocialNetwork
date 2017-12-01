using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class CommentFilterDto : FilterDtoBase
    {
        public int PostId { get; set; }
    }
}