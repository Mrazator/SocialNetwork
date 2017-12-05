using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class BasicUserDto : DtoBase
    {
        public string NickName { get; set; }
        public string Description { get; set; }

        //not mapped
        public IEnumerable<FriendshipDto> Friends { get; set; }
    }
}
