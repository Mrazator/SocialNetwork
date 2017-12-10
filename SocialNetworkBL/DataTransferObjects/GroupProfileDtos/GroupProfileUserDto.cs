using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects.GroupProfileDtos
{
    public class GroupProfileUserDto : DtoBase
    {
        public string NickName { get; set; }

        //not mapped
        public bool IsAdmin { get; set; }
        public bool IsAccepted { get; set; }
    }
}
