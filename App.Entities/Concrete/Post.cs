using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Entities.Concrete
{
    public class Post : IEntity
    {
        public string PostId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<MediaLink> MediaLinks { get; set; }

        public ICollection<PostLike> PostsLikes { get; set; }

        public ICollection<SavedPost> SavedPosts { get; set; }

        public ICollection<HashTag> Hashtags { get; set; }
    }
}
