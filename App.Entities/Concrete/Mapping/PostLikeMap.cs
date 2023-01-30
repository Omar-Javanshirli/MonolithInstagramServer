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
    public class PostLikeMap : EntityTypeConfiguration<PostLike>
    {
        public PostLikeMap()
        {
            this.HasKey(pl => pl.PostLikeId);
            this.ToTable(Constants.PostLikeTableName);

            this.Property(p => p.UserId)
                .IsRequired();

            this.Property(p => p.PostId)
                .IsRequired();
        }

    }
}
