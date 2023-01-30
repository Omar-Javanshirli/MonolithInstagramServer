using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class HashTag : IEntity
    {
        public string HashTagId { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
