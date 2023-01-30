using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class Comment : IEntity
    {
        public string CommentId { get; set; }

        public string Content { get; set; }

        public bool HasLikeComment { get; set; }

        public int HasChildComment { get; set; }

        public System.DateTime CommentDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(Post))]  
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("SubComment")]
        public string SubCommentId { get; set; }

        public Comment SubComment { get; set; }

        public ICollection<LikeComment> LikeComments { get; set; }
    }
}
