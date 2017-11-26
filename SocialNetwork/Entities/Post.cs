using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using SocialNetwork.Interfaces;

namespace SocialNetwork.Entities
{
    public class Post : IPostable, IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Posts);

        [Required]
        public DateTime PostedAt { get; set; }

        [Required, MaxLength(200)]
        public string Text { get; set; }

        public bool StayAnonymous { get; set; } = false;

        #region Foreign keys

        public int? UserId { get; set; }
        public int? GroupId { get; set; }

        #endregion

        #region Navigation properties

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual HashSet<Comment> Comments { get; set; }

        #endregion
    }
}
