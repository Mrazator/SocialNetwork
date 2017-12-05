using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.UserProfile
{
    public interface IUserProfilePostService : IService<UserProfilePostDto, PostFilterDto>
    {
        Task<QueryResultDto<UserProfilePostDto, PostFilterDto>> GetPostsByFilterAsync(PostFilterDto filter);
    }
}