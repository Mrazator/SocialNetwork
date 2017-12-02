using AutoMapper;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;

namespace SocialNetworkBL.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Friendship, FriendshipDto>().ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDto, FriendshipFilterDto>>();

            config.CreateMap<Friendship, FriendshipDtoWithNavigationProps>().ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDtoWithNavigationProps, FriendshipFilterDto>>();

            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UserFilterDto>>();

            config.CreateMap<User, UserCreateDto>().ReverseMap();

            config.CreateMap<Message, MessageDto>().ReverseMap();
            config.CreateMap<QueryResult<Message>, QueryResultDto<MessageDto, MessageFilterDto>>();

            config.CreateMap<Comment, CommentDto>().ReverseMap();
            config.CreateMap<QueryResult<Comment>, QueryResultDto<CommentDto, CommentFilterDto>>();

            config.CreateMap<Group, GroupDto>().ReverseMap();
            config.CreateMap<QueryResult<Group>, QueryResultDto<GroupDto, GroupFilterDto>>();

            config.CreateMap<Post, PostDto>().ReverseMap();
            config.CreateMap<QueryResult<Post>, QueryResultDto<PostDto, PostFilterDto>>();

            config.CreateMap<GroupUser, GroupUserDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<GroupUserDto, GroupUserFilterDto>>();

            config.CreateMap<GroupUser, UserGroupDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<UserGroupDto, UserGroupFilterDto>>();

            config.CreateMap<User, UserDetailDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDetailDto, UserFilterDto>>();

            config.CreateMap<User, UserDetailFriendshipDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDetailFriendshipDto, UserFilterDto>>();

            config.CreateMap<Friendship, FriendshipDetailDto>().ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDetailDto, FriendshipFilterDto>>();
        }
    }
}