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
    public class Group : IEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.Groups);

        [Required, MaxLength(30)]
        public string Name { get; set; }

        #region Settings

        //true if some user can post anonymous posts to this group

        public bool AllowAnonymousPosts { get; set; } = false;

        #endregion

        #region Navigation properties

        public virtual HashSet<GroupUser> GroupUsers { get; set; }
        public virtual HashSet<Post> Posts { get; set; }

        #endregion
    }
}
