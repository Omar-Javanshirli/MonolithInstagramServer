using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class MessageBox : IEntity
    {
        public string MessageBoxId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public bool IsRecaiverOrSender { get; set; }

        public virtual User User { get; set; }
    }
}
