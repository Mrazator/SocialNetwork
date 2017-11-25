using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using SocialNetwork.Enums;

namespace SocialNetwork.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Users);

        [Required, MaxLength(50)]
        public string NickName { get; set; }

        [Required, MinLength(6), MaxLength(50)]
        public string PasswordHash { get; set; }

        #region Settings

        //true if anyone can see user posts
        public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;

        #endregion

        #region Navigation properties

        public virtual HashSet<Friendship> RequestedFriendships { get; set; }
        public virtual HashSet<Friendship> AcceptedFriendships { get; set; }
        public virtual HashSet<Post> Posts { get; set; }
        public virtual HashSet<GroupUser> GroupUsers { get; set; }
        public virtual HashSet<Comment> Comments { get; set; }

        #endregion
    }
}
