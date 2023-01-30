using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class Message : IEntity
    {
        public string MessageId { get; set; }

        public DateTime MessageDate { get; set; }

        public string MessageContent { get; set; }

        [ForeignKey(nameof(MessageBox))]
        public string MessageBoxId { get; set; }

        [ForeignKey(nameof(MessageType))]
        public string MessageTypeId { get; set; }

        public virtual MessageBox MessageBox { get; set; }

        public virtual MessageType MessageType { get; set; }
    }
}
