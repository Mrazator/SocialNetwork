using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;

namespace SocialNetwork.Entities
{
    public class GroupUser : IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.GroupUsers);

        public bool IsAdmin { get; set; } = false;

        #region Foreign keys

        public int UserId { get; set; }
        public int GroupId { get; set; }

        #endregion

        #region Navigation Properties

        public User User { get; set; }
        public Group Group { get; set; }

        #endregion
    }
}