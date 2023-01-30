using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Model
{
    public class Constants
    {
        public const string UserTableName = "Users";
        public const string CommentTableName = "Comments";
        public const string LikeCommentTableName = "LikeComments";
        public const string FollowerTableName = "Followers";
        public const string FollowingTableName = "Followings";
        public const string HashTagTableName = "Hashtags";
        public const string MessageTableName = "Messages";
        public const string MessageBoxTableName = "MessageBoxes";
        public const string MessageTypeTableName = "MessageTypes";
        public const string NotificationTableName = "Notifications";
        public const string NotificationTypeTableName = "NotificationTypes";
        public const string PostTableName = "Posts";
        public const string PostLikeTableName = "PostLikes";
        public const string MediaLinksTableName = "MediaLinks";
        public const string SavedPostTableName = "SavedPosts";
        public const string UserNameCluster = "IX_Username2";
    }
}
