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
    public class PostMap: EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            this.HasKey(p => p.PostId);
            this.ToTable(Constants.PostTableName);
  
            //this.Property(p => p.UserId)
            //    .IsRequired();

            //this.HasMany(p => p.MediaLinks)
            //    .WithOptional()
            //    .HasForeignKey(p => p.PostId)
            //    .WillCascadeOnDelete(true);

            //this.HasMany(p => p.PostLikes)
            //   .WithOptional()
            //   .HasForeignKey(p => p.PostId)
            //   .WillCascadeOnDelete(true);

            //this.HasOne(p => p.SavedPost) ==> muellimden sorus
            //   .WithOptional()
            //   .HasForeignKey(p => p.PostId)
            //   .WillCascadeOnDelete(true);

            this.HasMany(p => p.Comments)
                .WithOptional()
                .HasForeignKey(c => c.PostId)
                .WillCascadeOnDelete(false);
        }
    }
}
