using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class PostFilterDto : FilterDtoBase
    {
        public int? UserId { get; set; }
        public int? GroupId { get; set; }

        protected bool Equals(PostFilterDto other)
        {
            return UserId == other.UserId && GroupId == other.GroupId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PostFilterDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (UserId.GetHashCode() * 397) ^ GroupId.GetHashCode();
            }
        }
    }
}
