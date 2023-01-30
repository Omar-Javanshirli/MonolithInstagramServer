using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Service.InstagramApiService.ApiEntity
{
    public class LikerApi
    {
        public class LikerRootObject
        {
            public int status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string shortcode { get; set; }
            public string link_to_post { get; set; }
            public int count_like { get; set; }
            public Liker[] likers { get; set; }
            public bool has_next_page { get; set; }
            public string next { get; set; }
        }

        public class Liker
        {
            public string id { get; set; }
            public string username { get; set; }
            public string full_name { get; set; }
            public bool is_private { get; set; }
            public bool is_verified { get; set; }
            public string profile_pic_url { get; set; }
            public string profile_pic_url_proxy { get; set; }
        }
    }
}
