﻿using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GroupUserDto : DtoBase
    {
        public bool IsAdmin { get; set; } = false;

        public bool IsAccepted { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }
    }
}
