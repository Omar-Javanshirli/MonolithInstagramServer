using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Service.InstagramApiService.ApiEntity
{
    public class UserApi
    {
        public class Rootobject
        {
            public string id { get; set; }
            public string fbid { get; set; }
            public string username { get; set; }
            public string full_name { get; set; }
            public string bio { get; set; }
            public int followers { get; set; }
            public int following { get; set; }
            public object category_name { get; set; }
            public bool is_private { get; set; }
            public bool is_verified { get; set; }
            public bool is_business { get; set; }
            public string profile_pic_url { get; set; }
            public string profile_pic_url_proxy { get; set; }
            public string profile_pic_url_hd { get; set; }
            public string profile_pic_url_hd_proxy { get; set; }
            public Lastmedia lastMedia { get; set; }
            public Lastvideo lastVideo { get; set; }
        }

        public class Lastmedia
        {
            public int count { get; set; }
            public Medium[] media { get; set; }
            public Page_Info page_info { get; set; }
        }

        public class Page_Info
        {
            public bool has_next_page { get; set; }
            public string next { get; set; }
        }

        public class Medium
        {
            public string id { get; set; }
            public string shortcode { get; set; }
            public string link_to_post { get; set; }
            public string display_url { get; set; }
            public string display_url_proxy { get; set; }
            public bool is_video { get; set; }
            public bool is_pinned { get; set; }
            public int comment_count { get; set; }
            public int like { get; set; }
            public string accessibility_caption { get; set; }
            public string caption { get; set; }
            public string thumbnail_src { get; set; }
            public string thumbnail_src_proxy { get; set; }
            public int timestamp { get; set; }
            public bool is_more_than_one { get; set; }
            public Child[] children { get; set; }
            public int video_views { get; set; }
            public string video_url { get; set; }
        }


        public class Child
        {
            public string id { get; set; }
            public string shortcode { get; set; }
            public string link_to_post { get; set; }
            public string display_url { get; set; }
            public string display_url_proxy { get; set; }
            public bool is_video { get; set; }
            public string accessibility_caption { get; set; }
        }

        public class Lastvideo
        {
            public int count { get; set; }
            public Medium1[] media { get; set; }
            public Page_Info1 page_info { get; set; }
        }

        public class Page_Info1
        {
            public bool has_next_page { get; set; }
            public string next { get; set; }
        }

        public class Medium1
        {
            public string id { get; set; }
            public string shortcode { get; set; }
            public string link_to_post { get; set; }
            public string display_url { get; set; }
            public string display_url_proxy { get; set; }
            public bool is_video { get; set; }
            public int comment_count { get; set; }
            public int like { get; set; }
            public string caption { get; set; }
            public string thumbnail_src { get; set; }
            public string thumbnail_src_proxy { get; set; }
            public int timestamp { get; set; }
            public bool is_more_than_one { get; set; }
            public object[] children { get; set; }
            public int video_views { get; set; }
            public string video_url { get; set; }
        }
    }
}
