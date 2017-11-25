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
    public class Friendship : IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Friendships);

        [Required]
        public DateTime FriendshipStart { get; set; }

        #region Foreign keys
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        #endregion

        #region Navigation properties

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual HashSet<Message> Messages{ get; set; }

        #endregion
    }
}
