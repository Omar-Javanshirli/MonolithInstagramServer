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
    public class FollowerMap: EntityTypeConfiguration<Follower>
    {
        public FollowerMap()
        {
            this.HasKey(f => f.FollowerId);
            this.ToTable(Constants.FollowerTableName);

            this.Property(f => f.UserId)
                .IsRequired();

        }
    }
}
