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
    public class MessageBoxMap : EntityTypeConfiguration<MessageBox>
    {
        public MessageBoxMap()
        {
            this.HasKey(mB => mB.MessageBoxId);
            this.ToTable(Constants.MessageBoxTableName);

            this.Property(nt => nt.UserId)
                .IsRequired();

        }

    }
}
