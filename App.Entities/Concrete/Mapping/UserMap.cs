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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.UserId);
            this.ToTable(Constants.UserTableName);

            this.HasIndex(u => u.Username)
                .IsUnique(true);

            this.Property(u => u.Username)
                .HasColumnAnnotation(
                 IndexAnnotation.AnnotationName,
                 new IndexAnnotation(new IndexAttribute(Constants.UserNameCluster, 2) { IsUnique = true }));

            this.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(u => u.Fullname)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(true);

            this.Property(u => u.Biography)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(true);

            //Collections

            this.HasMany(u => u.LikeComments)
                .WithOptional()
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);
        }

    }
}
