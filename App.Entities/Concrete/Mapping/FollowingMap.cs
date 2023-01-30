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
    public class FollowingMap: EntityTypeConfiguration<Following>
    {
        public FollowingMap()
        {
            this.HasKey(f => f.FollowingId);
            this.ToTable(Constants.FollowingTableName);

            this.Property(f => f.UserId)
                .IsRequired();
        }
    }
}
