using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkBL.DataTransferObjects.UserProfileDtos
{
    public class UserProfileUserDto : DtoBase
    {
        public string NickName { get; set; }
        public string Description { get; set; }

        //ignore mapping - managing by my self
        public QueryResultDto<UserProfilePostDto, PostFilterDto> Posts { get; set; }
        public List<BasicUserDto> Friends { get; set; }
    }
}