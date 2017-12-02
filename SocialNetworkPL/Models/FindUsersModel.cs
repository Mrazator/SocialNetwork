using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkPL.Models
{
    public class FindUsersModel
    {
        public UserDto User { get; set; }
        public UserFilterDto Filter { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}