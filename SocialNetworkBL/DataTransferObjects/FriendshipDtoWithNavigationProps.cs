using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class FriendshipDtoWithNavigationProps : FriendshipDto
    {
        public UserDto User1 { get; set; }
        public UserDto User2 { get; set; }
    }
}
