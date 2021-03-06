﻿using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;

namespace SocialNetworkDAL.Entities
{
    public class GroupUser : IEntity
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsAccepted { get; set; } = false;

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.GroupUsers);

        #region Foreign keys

        public int UserId { get; set; }
        public int GroupId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }

        #endregion
    }
}