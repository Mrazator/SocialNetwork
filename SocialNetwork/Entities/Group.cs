using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;

namespace SocialNetworkDAL.Entities
{
    public class Group : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        #region Settings

        //true if some user can post anonymous posts to this group
        public bool AllowAnonymousPosts { get; set; } = false;

        //only for invitations
        public bool IsPrivate { get; set; }

        #endregion

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Groups);

        #region Navigation properties

        public virtual HashSet<GroupUser> GroupUsers { get; set; }
        public virtual HashSet<Post> Posts { get; set; }

        #endregion
    }
}