using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class NotificationType:IEntity
    {
        public string NotificationTypeId { get; set; }
        public string Type { get; set; }
    }
}
