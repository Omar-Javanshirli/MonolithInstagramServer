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
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.HasKey(c => c.CommentId);
            this.ToTable(Constants.CommentTableName);

            this.Property(c => c.CommentId)
                .IsRequired();

            this.Property(c => c.UserId)
                .IsRequired();

            this.Property(c => c.PostId)
                .IsRequired();

            this.Property(c => c.Content)
                .IsRequired();

            this.Property(c => c.CommentDate)
                .IsRequired();

          
                
        }
    }
}
