using AutoMapper;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.ChatDtos;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Friendship, FriendshipDto>().ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDto, FriendshipFilterDto>>();

            config.CreateMap<User, UserProfileUserDto>()
                .ForMember(x => x.Posts, opt => opt.Ignore())
                .ForMember(x => x.Friends, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserProfileUserDto, UserFilterDto>>();

            config.CreateMap<Post, UserProfilePostDto>()
                .ForMember(x => x.Comments, opt => opt.Ignore())
                .ForMember(x => x.NickName, opt => opt.Ignore());
            config.CreateMap<UserProfilePostDto, Post>();
            config.CreateMap<QueryResult<Post>, QueryResultDto<UserProfilePostDto, PostFilterDto>>();

            config.CreateMap<User, BasicUserDto>()
                .ForMember(x => x.Friends, opt => opt.Ignore())
                .ForMember(x => x.Groups, opt => opt.Ignore());
            config.CreateMap<BasicUserDto, User>();
            config.CreateMap<QueryResult<User>, QueryResultDto<BasicUserDto, UserFilterDto>>();


            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UserFilterDto>>();

            config.CreateMap<User, UserCreateDto>().ReverseMap();

            config.CreateMap<User, UserProfileUserDto>()
                .ForMember(x => x.Posts, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserProfileUserDto, UserFilterDto>>();

            //config.CreateMap<User, UserProfileFriendshipDto>().ReverseMap();
            //config.CreateMap<QueryResult<User>, QueryResultDto<UserProfileFriendshipDto, UserFilterDto>>();

            config.CreateMap<Message, MessageDto>().ReverseMap();
            config.CreateMap<QueryResult<Message>, QueryResultDto<MessageDto, MessageFilterDto>>();

            config.CreateMap<Post, PostDto>().ReverseMap();
            config.CreateMap<QueryResult<Post>, QueryResultDto<PostDto, PostFilterDto>>();

            config.CreateMap<Comment, CommentDto>().ForMember(x => x.NickName, opt => opt.Ignore()).ReverseMap();
            config.CreateMap<QueryResult<Comment>, QueryResultDto<CommentDto, CommentFilterDto>>();

            config.CreateMap<Group, GroupDto>().ReverseMap();
            config.CreateMap<QueryResult<Group>, QueryResultDto<GroupDto, GroupFilterDto>>();

            config.CreateMap<GroupUser, GroupUserDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<GroupUserDto, GroupUserFilterDto>>();

            config.CreateMap<GroupUser, GetGroupUsersDto>().ReverseMap();
            config.CreateMap<GroupUser, GetGroupUsersDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<GetGroupUsersDto, GetGroupUsersFilterDto>>();

            config.CreateMap<GroupUser, GetUserGroupsDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<GetUserGroupsDto, GetUserGroupsFilterDto>>();

            config.CreateMap<GroupUser, AddUserToGroupDto>().ReverseMap();

            config.CreateMap<Group, GroupProfileDto>()
                .ForMember(x => x.GroupUsers, opt => opt.Ignore())
                .ForMember(x => x.Posts, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<Group>, QueryResultDto<GroupProfileDto, GroupFilterDto>>();

            config.CreateMap<Post, GroupProfilePostDto>()
                .ForMember(x => x.Comments, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<Post>, QueryResultDto<GroupProfilePostDto, PostFilterDto>>();

            config.CreateMap<User, GroupProfileUserDto>()
                .ForMember(x => x.IsAdmin, opt => opt.Ignore())
                .ForMember(x => x.IsAccepted, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<GroupProfileUserDto, UserFilterDto>>();

            config.CreateMap<Group, GroupCreateDto>().ReverseMap();

            config.CreateMap<Friendship, FriendsWithChatDto>()
                .ForMember(x => x.Chat, opt => opt.Ignore())
                .ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendsWithChatDto, FriendshipFilterDto>>();
        }
    }
}