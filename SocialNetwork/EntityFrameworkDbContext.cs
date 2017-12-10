using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SocialNetworkDAL.Config;
using SocialNetworkDAL.Entities;
using SocialNetworkDAL.Initializers;

namespace SocialNetworkDAL
{
    public class EntityFrameworkDbContext : DbContext
    {
        public EntityFrameworkDbContext() : base(EntityFrameworkInstaller.ConnectionString)
        {
            Database.SetInitializer(new MyInitializer());
            //var instance = SqlProviderServices.Instance;
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Friendship>()
                .HasRequired(u => u.User1)
                .WithMany(u => u.RequestedFriendships)
                .HasForeignKey(u => u.User1Id);

            builder.Entity<Friendship>()
                .HasRequired(u => u.User2)
                .WithMany(u => u.AcceptedFriendships)
                .HasForeignKey(u => u.User2Id);

            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}