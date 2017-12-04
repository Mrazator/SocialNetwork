using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class AddUserToGroupDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public bool IsAccepted { get; set; }
    }
}
