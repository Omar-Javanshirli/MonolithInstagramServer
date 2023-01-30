using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
    public class MediaLink : IEntity
    {
        public string MediaLinkId { get; set; }

        public bool IsImage { get; set; }

        public string URL { get; set; }

        public string PostId { get; set; }

        public string Shortcode { get; set; }

        public Post Post { get; set; }
    }
}
