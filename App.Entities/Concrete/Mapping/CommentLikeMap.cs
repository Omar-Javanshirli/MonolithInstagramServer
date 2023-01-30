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
    public class LikeCommentMap : EntityTypeConfiguration<LikeComment>
    {
        public LikeCommentMap()
        {
            this.HasKey(cl => cl.LikeCommentId);
            this.ToTable(Constants.LikeCommentTableName);

            this.Property(c => c.CommentId)
                .IsRequired();

            this.Property(c => c.UserId)
                .IsRequired();
        }
    }
}
