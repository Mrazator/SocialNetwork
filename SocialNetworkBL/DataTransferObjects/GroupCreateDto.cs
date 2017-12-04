using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GroupCreateDto : DtoBase
    {
        [Required(ErrorMessage = "Group name is required!")]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool AllowAnonymousPosts { get; set; } = false;
    }
}
