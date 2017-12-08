using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.GroupProfile
{
    public interface IGroupProfileService : IService<GroupProfileDto, GroupFilterDto>
    {
        Task<GroupProfileDto> GetGroupProfileAsync(int id);

    }
}
