using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class SavedPost : IEntity
    {
        public string SavedPostId { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
