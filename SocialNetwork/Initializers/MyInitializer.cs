using System;
using System.Data.Entity;
using SocialNetwork.Entities;
using SocialNetwork.Enums;

namespace SocialNetwork.Initializers
{
    public class MyInitializer : DropCreateDatabaseAlways<EntityFrameworkDbContext>
    {
        protected override void Seed(EntityFrameworkDbContext context)
        {
            var userM = new User()
            {
                NickName = "Mrazator",
                PasswordSalt = "hFrDVp5UB9eMycpU+4wSEA==",
                PasswordHash = "ZXnjeNKhDTSH6Rc6q4++tVoQVHo=",
            };

            context.Users.Add(userM);
            //PV226jesuper
            var user1 = new User
            {
                NickName = "Bara",
                PasswordSalt = "hFrDVp5UB9eMycpU+4wSEA==",
                PasswordHash = "ZXnjeNKhDTSH6Rc6q4++tVoQVHo=",
                //PostVisibilityPreference = Visibility.NotVisible
            };

            context.Users.Add(user1);

            var user2 = new User
            {
                NickName = "Lucie",
                PasswordSalt = "hFrDVp5UB9eMycpU+4wSEA==",
                PasswordHash = "ZXnjeNKhDTSH6Rc6q4++tVoQVHo="
            };

            context.Users.Add(user2);
            context.SaveChanges();

            var friendship = new Friendship
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user1,
                User2 = user2
            };

            context.Friendships.Add(friendship);
            context.SaveChanges();

            var user3 = new User
            {
                NickName = "Aneta",
                PasswordSalt = "hFrDVp5UB9eMycpU+4wSEA==",
                PasswordHash = "ZXnjeNKhDTSH6Rc6q4++tVoQVHo=",
                //PostVisibilityPreference = Visibility.NotVisible
            };

            context.Users.Add(user3);

            var user4 = new User
            {
                NickName = "Alena",
                PasswordSalt = "hFrDVp5UB9eMycpU+4wSEA==",
                PasswordHash = "ZXnjeNKhDTSH6Rc6q4++tVoQVHo="
            };

            context.Users.Add(user4);
            context.SaveChanges();

            var marcelFriendship = new Friendship()
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = userM,
                User2 = user4

            };

            context.Friendships.Add(marcelFriendship);
            context.SaveChanges();

            var friendship2 = new Friendship
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user1,
                User2 = user3
            };

            context.Friendships.Add(friendship2);
            context.SaveChanges();

            var friendship3 = new Friendship
            {
                FriendshipStart = DateTime.Now.ToUniversalTime(),
                User1 = user4,
                User2 = user1
            };

            context.Friendships.Add(friendship3);
            context.SaveChanges();

            var group = new Group
            {
                Name = "First group"
            };

            context.Groups.Add(group);
            context.SaveChanges();

            var groupUser = new GroupUser
            {
                Group = group,
                User = user2,
                IsAdmin = true,
                IsAccepted = true
      
            };

            context.GroupUsers.Add(groupUser);

            var groupUser2 = new GroupUser
            {
                Group = group,
                User = user1,
                IsAccepted = true
            };

            context.GroupUsers.Add(groupUser2);

            var post = new Post
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text = "My First Post",
                Group = group,
                User = user1
            };

            context.Posts.Add(post);

            var post5 = new Post
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text =
                    "5Navzdory všeobecnému přesvědčení Lorem Ipsum není náhodný text. Jeho původ má kořeny v klasické latinské literatuře z roku 45 před Kristem, což znamená, že je více jak 2000 let staré. Richard McClintock, profesor latiny na univerzitě Hampden-Sydney stát Virginia, který se zabýval téměř neznámými latinskými slovy, odhalil prapůvod slova consectetur z pasáže Lorem Ipsum. Nejstarším dílem, v němž se pasáže Lorem Ipsum používají, je Cicerova kniha z roku 45 před Kristem s názvem (O koncích dobra a zla), konkrétně jde pak o kapitoly 1.10.32 a 1.10.33. Tato kniha byla nejvíce známá v době renesance, jelikož pojednávala o etice. Úvodní řádky Lorem Ipsum, pocházejí z kapitoly 1.10.32 z uvedené knihy.",
                Group = group,
                User = user1
            };

            context.Posts.Add(post5);

            var post2 = new Post
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text =
                    "2Navzdory všeobecnému přesvědčení Lorem Ipsum není náhodný text. Jeho původ má kořeny v klasické latinské literatuře z roku 45 před Kristem, což znamená, že je více jak 2000 let staré. Richard McClintock, profesor latiny na univerzitě Hampden-Sydney stát Virginia, který se zabýval téměř neznámými latinskými slovy, odhalil prapůvod slova consectetur z pasáže Lorem Ipsum. Nejstarším dílem, v němž se pasáže Lorem Ipsum používají, je Cicerova kniha z roku 45 před Kristem s názvem (O koncích dobra a zla), konkrétně jde pak o kapitoly 1.10.32 a 1.10.33. Tato kniha byla nejvíce známá v době renesance, jelikož pojednávala o etice. Úvodní řádky Lorem Ipsum, pocházejí z kapitoly 1.10.32 z uvedené knihy.",
                Group = group,
                User = user2
            };

            context.Posts.Add(post2);

            var post3 = new Post
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text =
                    "3Navzdory všeobecnému přesvědčení Lorem Ipsum není náhodný text. Jeho původ má kořeny v klasické latinské literatuře z roku 45 před Kristem, což znamená, že je více jak 2000 let staré. Richard McClintock, profesor latiny na univerzitě Hampden-Sydney stát Virginia, který se zabýval téměř neznámými latinskými slovy, odhalil prapůvod slova consectetur z pasáže Lorem Ipsum. Nejstarším dílem, v němž se pasáže Lorem Ipsum používají, je Cicerova kniha z roku 45 před Kristem s názvem (O koncích dobra a zla), konkrétně jde pak o kapitoly 1.10.32 a 1.10.33. Tato kniha byla nejvíce známá v době renesance, jelikož pojednávala o etice. Úvodní řádky Lorem Ipsum, pocházejí z kapitoly 1.10.32 z uvedené knihy.",
                Group = group,
                User = user3
            };

            context.Posts.Add(post3);

            var post4 = new Post
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text =
                    "4Navzdory všeobecnému přesvědčení Lorem Ipsum není náhodný text. Jeho původ má kořeny v klasické latinské literatuře z roku 45 před Kristem, což znamená, že je více jak 2000 let staré. Richard McClintock, profesor latiny na univerzitě Hampden-Sydney stát Virginia, který se zabýval téměř neznámými latinskými slovy, odhalil prapůvod slova consectetur z pasáže Lorem Ipsum. Nejstarším dílem, v němž se pasáže Lorem Ipsum používají, je Cicerova kniha z roku 45 před Kristem s názvem (O koncích dobra a zla), konkrétně jde pak o kapitoly 1.10.32 a 1.10.33. Tato kniha byla nejvíce známá v době renesance, jelikož pojednávala o etice. Úvodní řádky Lorem Ipsum, pocházejí z kapitoly 1.10.32 z uvedené knihy.",
                Group = group,
                User = user4
            };

            context.Posts.Add(post4);
            context.SaveChanges();

            var comment = new Comment
            {
                PostedAt = DateTime.Now.ToUniversalTime(),
                Text = "That's cute",
                User = user2,
                Post = post,
                StayAnonymous = true
            };

            context.Comments.Add(comment);

            var message = new Message
            {
                Text = "Hi there",
                Friendship = friendship,
                SentAt = DateTime.Now.ToUniversalTime(),
                Sender = user1
            };

            context.Messages.Add(message);

            var message2 = new Message
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