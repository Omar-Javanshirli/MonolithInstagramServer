using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class PostLike : IEntity
    {
        public string PostLikeId { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
