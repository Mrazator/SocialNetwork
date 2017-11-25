using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.Common;
using Message = SocialNetwork.Entities.Message;

namespace SocialNetworkBL.Facades
{
    public class MessageFacade : FacadeBase<Message, MessageDto, MessageFilterDto>
    {
        private readonly IMessageService _messageService;

        protected MessageFacade(
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
