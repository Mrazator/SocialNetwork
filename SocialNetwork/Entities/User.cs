using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;
using SocialNetwork.Enums;

namespace SocialNetwork.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string NickName { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string PasswordSalt { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        #region Settings

        //true if anyone can see user posts
        //public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;
        public string ProfileDescription { get; set; } = "Your profile description, you can change this in Settings tab";

        #endregion

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Users);

        #region Navigation properties

        public virtual HashSet<Friendship> RequestedFriendships { get; set; }
        public virtual HashSet<Friendship> AcceptedFriendships { get; set; }
        public virtual HashSet<Post> Posts { get; set; }
        public virtual HashSet<GroupUser> GroupUsers { get; set; }
        public virtual HashSet<Comment> Comments { get; set; }

        #endregion
    }
}