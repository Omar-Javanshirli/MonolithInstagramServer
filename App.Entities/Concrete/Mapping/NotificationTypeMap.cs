using App.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete.Mapping
{
    public class NotificationTypeMap : EntityTypeConfiguration<NotificationType>
    {
        public NotificationTypeMap()
        {
            this.HasKey(nt => nt.NotificationTypeId);
            this.ToTable(Constants.NotificationTypeTableName);
        }
    }
}
