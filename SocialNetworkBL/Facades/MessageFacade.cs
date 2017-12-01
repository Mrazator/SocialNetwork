using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Messages;

namespace SocialNetworkBL.Facades
{
    public class MessageFacade : FacadeBase<Message, MessageDto, MessageFilterDto>
    {
        private readonly IMessageService _messageService;

        public MessageFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Message, MessageDto, MessageFilterDto> service,
            IMessageService messageService)
            : base(unitOfWorkProvider, service)
        {
            _messageService = messageService;
        }

        public async Task<IList<MessageDto>> GetMessagesByFriendshipIdAsync(int friendshipId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _messageService.GetMessagesByFriendshipIdAsync(friendshipId);
            }
        }
    }
}