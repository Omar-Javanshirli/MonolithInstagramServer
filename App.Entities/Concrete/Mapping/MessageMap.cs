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
    public class MessageMap : EntityTypeConfiguration<Message>
    {

        public MessageMap()
        {
            this.HasKey(m => m.MessageId);
            this.ToTable(Constants.MessageTableName);

            this.Property(m => m.MessageTypeId)
                .IsRequired();

            this.Property(m => m.MessageDate)
                .IsRequired();

            this.Property(m => m.MessageBoxId)
                .IsRequired();

            this.Property(m => m.MessageContent)
                .IsRequired();
        }

    }
}
