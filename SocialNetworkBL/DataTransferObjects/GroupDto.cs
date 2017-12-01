using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GroupDto : DtoBase
    {
        public string Name { get; set; }

        public bool AllowAnonymousPosts { get; set; } = false;
    }
}