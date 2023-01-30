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
    public class MediaLinkMap : EntityTypeConfiguration<MediaLink>
    {
        public MediaLinkMap()
        {
            this.HasKey(x => x.MediaLinkId);
            this.ToTable(Constants.MediaLinksTableName);

            this.Property(p => p.IsImage)
                .IsRequired();

            this.Property(p => p.URL)
            .IsRequired();

            this.Property(p => p.PostId)
            .IsRequired();
        }
    }
}
