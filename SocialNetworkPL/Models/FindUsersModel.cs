using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkPL.Models
{
    public class FindUsersModel
    {
        public IEnumerable<UserDto> Users { get; set; }
        public UserFilterDto Filter { get; set; }
    }
}