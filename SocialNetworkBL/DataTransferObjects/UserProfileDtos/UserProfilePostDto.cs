using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkBL.DataTransferObjects.UserProfileDtos
{
    public class UserProfilePostDto : DtoBase
    {
        public DateTime PostedAt { get; set; }
        public string Text { get; set; }
        public bool StayAnonymous { get; set; } = false;
        public int? UserId { get; set; }
        public int? GroupId { get; set; }

        //ignored - managing by myself in facade
        public string NickName { get; set; }
        public QueryResultDto<CommentDto, CommentFilterDto> Comments { get; set; }
    }
}
