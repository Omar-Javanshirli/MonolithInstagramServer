using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Entities.Concrete
{
    public class LikeComment : IEntity
    {
        public string LikeCommentId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public string CommentId { get; set; }

        public virtual User User { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
