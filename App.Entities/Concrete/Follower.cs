using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class Follower : IEntity
    {
        public string FollowerId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsRecaiverOrSender { get; set; }
    }
}
