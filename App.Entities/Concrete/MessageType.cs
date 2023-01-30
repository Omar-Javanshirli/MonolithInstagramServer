using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class MessageType : IEntity
    {
        public string MessageTypeId { get; set; }
        public string Title { get; set; }
    }
}
