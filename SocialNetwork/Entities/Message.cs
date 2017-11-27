using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace SocialNetwork.Entities
{
    public class Message : IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Messages);

        [Required]
        public DateTime SentAt { get; set; } = DateTime.Now.ToUniversalTime();

        [Required, MaxLength(100)]
        public string Text { get; set; }

        #region Foreign keys

        public int SenderId { get; set; }
        public int FriendshipId { get; set; }

        #endregion

        #region Navigation properties

        public virtual User Sender { get; set; }
        public virtual Friendship Friendship { get; set; }

        #endregion

    }
}
