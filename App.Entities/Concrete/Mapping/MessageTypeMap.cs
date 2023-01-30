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
    public class MessageTypeMap:EntityTypeConfiguration<MessageType>
    {
        public MessageTypeMap()
        {
            this.HasKey(mT=>mT.MessageTypeId);
            this.ToTable(Constants.MessageTypeTableName);


            this.Property(mT => mT.Title)
                .IsRequired();
        }

    }
}
