namespace App.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                        HasLikeComment = c.Boolean(nullable: false),
                        HasChildComment = c.Int(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.String(nullable: false, maxLength: 128),
                        SubCommentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Comments", t => t.SubCommentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.SubCommentId);
            
            CreateTable(
                "dbo.LikeComments",
                c => new
                    {
                        LikeCommentId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CommentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LikeCommentId)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 300),
                        ProfilePicUrl = c.String(),
                        IsOnline = c.Boolean(nullable: false),
                        EndPoint = c.String(),
                        Biography = c.String(nullable: false, maxLength: 150),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        IsPrivate = c.Boolean(nullable: false),
                        FollowerCount = c.Int(),
                        FollowingCount = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Username, unique: true, name: "IX_Username2")
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsRecaiverOrSender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FollowerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsRecaiverOrSender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FollowingId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashTagId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HashTagId);
            
            CreateTable(
                "dbo.MediaLinks",
                c => new
                    {
                        MediaLinkId = c.String(nullable: false, maxLength: 128),
                        IsImage = c.Boolean(nullable: false),
                        URL = c.String(nullable: false),
                        PostId = c.String(nullable: false, maxLength: 128),
                        Shortcode = c.String(),
                    })
                .PrimaryKey(t => t.MediaLinkId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        PostLikeId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PostLikeId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.SavedPosts",
                c => new
                    {
                        SavedPostId = c.String(nullable: false, maxLength: 128),
                        PostId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SavedPostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.MessageBoxes",
                c => new
                    {
                        MessageBoxId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsRecaiverOrSender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageBoxId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.String(nullable: false, maxLength: 128),
                        MessageDate = c.DateTime(nullable: false),
                        MessageContent = c.String(nullable: false),
                        MessageBoxId = c.String(nullable: false, maxLength: 128),
                        MessageTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.MessageBoxes", t => t.MessageBoxId, cascadeDelete: true)
                .ForeignKey("dbo.MessageTypes", t => t.MessageTypeId, cascadeDelete: true)
                .Index(t => t.MessageBoxId)
                .Index(t => t.MessageTypeId);
            
            CreateTable(
                "dbo.MessageTypes",
                c => new
                    {
                        MessageTypeId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MessageTypeId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        IsRecaiverOrSender = c.Boolean(nullable: false),
                        NotificationTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.NotificationTypes", t => t.NotificationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationTypeId);
            
            CreateTable(
                "dbo.NotificationTypes",
                c => new
                    {
                        NotificationTypeId = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.NotificationTypeId);
            
            CreateTable(
                "dbo.HashTagPosts",
                c => new
                    {
                        HashTag_HashTagId = c.String(nullable: false, maxLength: 128),
                        Post_PostId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.HashTag_HashTagId, t.Post_PostId })
                .ForeignKey("dbo.Hashtags", t => t.HashTag_HashTagId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.HashTag_HashTagId)
                .Index(t => t.Post_PostId);
            
            CreateTable(
                "dbo.SavedPostUsers",
                c => new
                    {
                        SavedPost_SavedPostId = c.String(nullable: false, maxLength: 128),
                        User_UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SavedPost_SavedPostId, t.User_UserId })
                .ForeignKey("dbo.SavedPosts", t => t.SavedPost_SavedPostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.SavedPost_SavedPostId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotificationTypeId", "dbo.NotificationTypes");
            DropForeignKey("dbo.Messages", "MessageTypeId", "dbo.MessageTypes");
            DropForeignKey("dbo.Messages", "MessageBoxId", "dbo.MessageBoxes");
            DropForeignKey("dbo.MessageBoxes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "SubCommentId", "dbo.Comments");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.SavedPostUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.SavedPostUsers", "SavedPost_SavedPostId", "dbo.SavedPosts");
            DropForeignKey("dbo.SavedPosts", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.MediaLinks", "PostId", "dbo.Posts");
            DropForeignKey("dbo.HashTagPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.HashTagPosts", "HashTag_HashTagId", "dbo.Hashtags");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.LikeComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Followings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Followers", "UserId", "dbo.Users");
            DropForeignKey("dbo.LikeComments", "CommentId", "dbo.Comments");
            DropIndex("dbo.SavedPostUsers", new[] { "User_UserId" });
            DropIndex("dbo.SavedPostUsers", new[] { "SavedPost_SavedPostId" });
            DropIndex("dbo.HashTagPosts", new[] { "Post_PostId" });
            DropIndex("dbo.HashTagPosts", new[] { "HashTag_HashTagId" });
            DropIndex("dbo.Notifications", new[] { "NotificationTypeId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "MessageTypeId" });
            DropIndex("dbo.Messages", new[] { "MessageBoxId" });
            DropIndex("dbo.MessageBoxes", new[] { "UserId" });
            DropIndex("dbo.SavedPosts", new[] { "PostId" });
            DropIndex("dbo.PostLikes", new[] { "PostId" });
            DropIndex("dbo.PostLikes", new[] { "UserId" });
            DropIndex("dbo.MediaLinks", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Followings", new[] { "UserId" });
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Users", "IX_Username2");
            DropIndex("dbo.LikeComments", new[] { "CommentId" });
            DropIndex("dbo.LikeComments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "SubCommentId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.SavedPostUsers");
            DropTable("dbo.HashTagPosts");
            DropTable("dbo.NotificationTypes");
            DropTable("dbo.Notifications");
            DropTable("dbo.MessageTypes");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageBoxes");
            DropTable("dbo.SavedPosts");
            DropTable("dbo.PostLikes");
            DropTable("dbo.MediaLinks");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Posts");
            DropTable("dbo.Followings");
            DropTable("dbo.Followers");
            DropTable("dbo.Users");
            DropTable("dbo.LikeComments");
            DropTable("dbo.Comments");
        }
    }
}
