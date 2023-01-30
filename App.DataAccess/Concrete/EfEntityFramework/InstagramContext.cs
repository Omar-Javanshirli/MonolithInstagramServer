using App.Entities.Concrete;
using App.Entities.Concrete.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete.EfEntityFramework
{
    public class InstagramContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageBox> MessageBoxes { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<MediaLink> MediaLinks { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public InstagramContext()
            : base("InstagramDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SavedPostMap());
            modelBuilder.Configurations.Add(new PostLikeMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new NotificationTypeMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageBoxMap());
            modelBuilder.Configurations.Add(new MessageTypeMap());
            modelBuilder.Configurations.Add(new MediaLinkMap());
            modelBuilder.Configurations.Add(new HashTagMap());
            modelBuilder.Configurations.Add(new FollowingMap());
            modelBuilder.Configurations.Add(new FollowerMap());
            modelBuilder.Configurations.Add(new LikeCommentMap());
            modelBuilder.Configurations.Add(new CommentMap());
        }
    }
}
