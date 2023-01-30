using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Service.InstagramApiService.ApiEntity
{
    public class CommentApi
    {
        public class CommentRootobject
        {
            public int status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public bool comment_likes_enabled { get; set; }
            public int count_all_comment { get; set; }
            public int count_comment { get; set; }
            public Comment[] comments { get; set; }
            public string next { get; set; }
        }

        public class Comment
        {
            public Comment1 comment { get; set; }
            public Owner1 owner { get; set; }
        }

        public class Comment1
        {
            public string id { get; set; }
            public string status { get; set; }
            public string text { get; set; }
            public bool has_liked_comment { get; set; }
            public int comment_like_count { get; set; }
            public int created_at { get; set; }
            public int has_child_comments { get; set; }
            public Child_Comments[] child_comments { get; set; }
            public bool has_more_tail_child_comments { get; set; }
            public bool has_more_head_child_comments { get; set; }
        }

        public class Child_Comments
        {
            public Comment2 comment { get; set; }
            public Owner owner { get; set; }
        }

        public class Comment2
        {
            public string id { get; set; }
            public string status { get; set; }
            public string text { get; set; }
            public bool has_liked_comment { get; set; }
            public int comment_like_count { get; set; }
            public int created_at { get; set; }
        }

        public class Owner
        {
            public string id { get; set; }
            public string username { get; set; }
            public string full_name { get; set; }
            public bool is_private { get; set; }
            public bool is_verified { get; set; }
            public string profile_pic_url { get; set; }
            public string profile_pic_url_proxy { get; set; }
        }

        public class Owner1
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
