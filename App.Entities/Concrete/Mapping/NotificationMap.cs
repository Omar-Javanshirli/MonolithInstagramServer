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
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            this.HasKey(n => n.NotificationId);
            this.ToTable(Constants.NotificationTableName);

            this.Property(nt => nt.UserId)
              .IsRequired();

            this.Property(nt => nt.NotificationTypeId)
              .IsRequired();
        }

    }
}
