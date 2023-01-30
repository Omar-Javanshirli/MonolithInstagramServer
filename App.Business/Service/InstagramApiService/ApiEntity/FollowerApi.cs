using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Service.InstagramApiService.ApiEntity
{
    public class FolloerApi
    {
        public class FollowerRootObject
        {
            public string user_id { get; set; }
            public int count { get; set; }
            public Follower[] followers { get; set; }
        }

        public class Follower
        {
            public string id { get; set; }
            public string username { get; set; }
            public string full_name { get; set; }
            public bool is_private { get; set; }
            public string profile_pic_url { get; set; }
            public string profile_pic_url_proxy { get; set; }
            public bool is_verified { get; set; }
        }
    }
}
