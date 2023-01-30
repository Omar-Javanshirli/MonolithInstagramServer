using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class User : IEntity
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ProfilePicUrl { get; set; }

        public bool IsOnline { get; set; }

        public string EndPoint { get; set; }

        public string Biography { get; set; }

        public string Fullname { get; set; }

        public bool IsPrivate { get; set; }

        public int? FollowerCount { get; set; }

        public int? FollowingCount { get; set; }

        public virtual ICollection<SavedPost> SavedPosts { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<LikeComment> LikeComments { get; set; }

        public virtual ICollection<Following> Followings { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }
    }
}
