using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;

namespace SocialNetworkBL.Services.UserProfile
{
    public interface IUserProfileUserService
    {
        Task<UserProfileUserDto> GetUserProfileUserByNickNameAsync(string nickName);
        Task<UserProfileUserDto> GetUserProfileUserByIdAsync(int? id);
    }
}