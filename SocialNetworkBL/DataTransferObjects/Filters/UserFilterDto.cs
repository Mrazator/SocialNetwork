using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class UserFilterDto : FilterDtoBase
    {
        public string SubName { get; set; }

        public string NickName { get; set; }

        //potreba prepsat tyhle metody, kvuli tomu ze,
        //Mock framework interne porovnava reference filteru v UserFacadeTests/GetUsersContainingGivenSubnameAsyncTest()
        public override bool Equals(object obj)
        {
            return obj is UserFilterDto dto && SubName == dto.SubName;
        }

        public override int GetHashCode()
        {
            return 1540050470 + EqualityComparer<string>.Default.GetHashCode(SubName);
        }
    }
}
