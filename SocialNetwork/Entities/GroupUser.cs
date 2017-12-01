﻿using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure;

namespace SocialNetwork.Entities
{
    public class GroupUser : IEntity
    {
        public bool IsAdmin { get; set; } = false;
        public int Id { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(EntityFrameworkDbContext.GroupUsers);

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