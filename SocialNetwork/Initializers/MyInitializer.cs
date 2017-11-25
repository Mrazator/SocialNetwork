using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;
using SocialNetwork.Enums;

namespace SocialNetwork.Initializers
{
    public class MyInitializer : CreateDatabaseIfNotExists<EntityFrameworkDbContext>
    {
        protected override void Seed(EntityFrameworkDbContext context)
        {
            var user1 = new User()
            {
                NickName = "Marcello",
                PasswordHash = "123456",
                PostVisibilityPreference = Visibility.NotVisible
            };

            context.Users.Add(user1);

            var user2 = new User()
            {
                NickName = "Misko",
                PasswordHash = "123456"
            };

            context.Users.Add(user2);
            context.SaveChanges();

            var friendship = new Friendship()
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user1,
                User2 = user2
            };

            context.Friendships.Add(friendship);
            context.SaveChanges();

            var user3 = new User()
            {
                NickName = "Marcello2",
                PasswordHash = "123456",
                PostVisibilityPreference = Visibility.NotVisible
            };

            context.Users.Add(user3);

            var user4 = new User()
            {
                NickName = "Misko2",
                PasswordHash = "123456"
            };

            context.Users.Add(user4);
            context.SaveChanges();

            var friendship2 = new Friendship()
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user1,
                User2 = user3
            };

            context.Friendships.Add(friendship2);
            context.SaveChanges();

            var friendship3 = new Friendship()
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user4,
                User2 = user1
            };

            context.Friendships.Add(friendship3);
            context.SaveChanges();

            var group = new Group()
            {
                Name = "First group"
            };

            context.Groups.Add(group);
            context.SaveChanges();

            var groupUser = new GroupUser()
            {
                Group = group,
                User = user2,
                IsAdmin = true
            };

            context.GroupUsers.Add(groupUser);

            var groupUser2 = new GroupUser()
            {
                Group = group,
                User = user1
            };

            context.GroupUsers.Add(groupUser2);

            var post = new Post()
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text = "My First Post",
                Group = group,
                User = user1
            };

            context.Posts.Add(post);
            context.SaveChanges();

            var comment = new Comment()
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text = "That's cute",
                User = user2,
                Post = post,
                StayAnonymous = true
            };

            context.Comments.Add(comment);

            var message = new Message()
            {
                Text = "Hi there",
                Friendship = friendship,
                SentAt = DateTime.Now.ToUniversalTime(),
                Sender = user1
            };

            context.Messages.Add(message);

            var message2 = new Message()
            {
                Text = "Hi!",
                Friendship = friendship,
                SentAt = DateTime.Now.ToUniversalTime(),
                Sender = user2
            };

            context.Messages.Add(message2);

            base.Seed(context);
        }
    }
}
