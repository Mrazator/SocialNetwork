using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;
using SocialNetwork.Interfaces;

namespace SocialNetwork.Entities
{
    public class Post : IPostable, IEntity
    {
        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Posts);

        public int Id { get; set; }

        [Required]
        public DateTime PostedAt { get; set; } = DateTime.Now.ToUniversalTime();

        [Required]
        [MaxLength(5000)]
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