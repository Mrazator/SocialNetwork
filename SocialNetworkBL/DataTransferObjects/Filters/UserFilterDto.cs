using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.Filters
{
    public class UserFilterDto : FilterDtoBase
    {
        public string NickName { get; set; }
        public string SubName { get; set; }

        //potreba prepsat tyhle metody, kvuli tomu ze,
        //Mock framework interne porovnava reference filteru v UserFacadeTests/GetUsersContainingGivenSubnameAsyncTest()
        protected bool Equals(UserFilterDto other)
        {
            return string.Equals(NickName, other.NickName) && string.Equals(SubName, other.SubName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UserFilterDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((NickName != null ? NickName.GetHashCode() : 0) * 397) ^
                       (SubName != null ? SubName.GetHashCode() : 0);
            }
        }
    }
}