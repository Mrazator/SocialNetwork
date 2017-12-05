using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class BasicUserDto : DtoBase
    {
        public string NickName { get; set; }
        public string Description { get; set; }
    }
}
