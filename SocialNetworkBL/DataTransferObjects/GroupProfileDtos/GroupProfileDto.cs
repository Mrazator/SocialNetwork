using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects.GroupProfileDtos
{
    public class GroupProfileDto : DtoBase
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public bool AllowAnonymousPosts { get; set; }

        public IList<GroupProfileUserDto> GroupUsers { get; set; }
        public IList<GroupProfilePostDto> Posts { get; set; }

    }
}
