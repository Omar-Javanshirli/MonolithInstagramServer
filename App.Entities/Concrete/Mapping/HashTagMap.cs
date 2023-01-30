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
    public class HashTagMap : EntityTypeConfiguration<HashTag>
    {
        public HashTagMap()
        {
            this.HasKey(ht => ht.HashTagId);
            this.ToTable(Constants.HashTagTableName);

            this.Property(m => m.Content)
             .IsRequired();
        }
    }
}
