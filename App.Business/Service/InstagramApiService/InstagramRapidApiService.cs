using App.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static App.Business.Service.InstagramApiService.ApiEntity.CommentApi;
using static App.Business.Service.InstagramApiService.ApiEntity.FolloerApi;
using static App.Business.Service.InstagramApiService.ApiEntity.LikerApi;
using static App.Business.Service.InstagramApiService.ApiEntity.UserApi;

namespace App.Business.Service.InstagramApiService
{
    public class InstagramRapidApiService
    {
        public static async Task<User> GetUserBydAsync(string username)
        {
            User user = new User();
            var posts = new List<Post>();


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-profile1.p.rapidapi.com/getprofile/{username}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4650f7d9dcmsh8265daf5ee89220p1deaf9jsnb7f0e3ecb30a" },
                    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Rootobject>(body);

                foreach (var item in data.lastMedia.media)
                {
                    var post = new Post();
                    List<MediaLink> medium = new List<MediaLink>();

                    if (item.children.Count() == 0)
                    {
                        var medium2 = new MediaLink()
                        {
                            IsImage = item.is_video,
                            PostId = item.id,
                            URL = item.display_url,
                            Shortcode = item.shortcode,
                        };

                        medium.Add(medium2);
                    }

                    foreach (var item2 in item.children)
                    {
                        var link = new MediaLink()
                        {
                            IsImage = item2.is_video,
                            PostId = item.id,
                            URL = item2.display_url,
                            Shortcode = item2.shortcode,
                        };
                        medium.Add(link);
                    }
                    post.MediaLinks = medium;
                    posts.Add(post);
                }

                user = new User()
                {
                    UserId = data.id,
                    Biography = data.bio,
                    Fullname = data.full_name,
                    IsPrivate = data.is_private,
                    ProfilePicUrl = data.profile_pic_url,
                    Username = data.username,
                    IsOnline = false,
                    Password = "12345",
                    FollowerCount = data.followers,
                    FollowingCount = data.following,
                    Posts = posts,
                };

                return user;
            }
        }

        public static async Task<List<Entities.Concrete.Comment>> GetCommentAsync(string postId)
        {
            List<Entities.Concrete.Comment> comments = new List<Entities.Concrete.Comment>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-profile1.p.rapidapi.com/comments/{postId}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4650f7d9dcmsh8265daf5ee89220p1deaf9jsnb7f0e3ecb30a" },
                    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CommentRootobject>(body);

                foreach (var item in data.data.comments)
                {
                    Entities.Concrete.Comment comment = new Entities.Concrete.Comment()
                    {
                        CommentId = (item.comment.id),
                        Content = item.comment.text,
                        HasLikeComment = item.comment.has_liked_comment,
                        HasChildComment = item.comment.has_child_comments,
                        User = new User
                        {
                            UserId = item.owner.id,
                            Username = item.owner.username,
                            Fullname = item.owner.full_name,
                            IsPrivate = item.owner.is_private,
                            ProfilePicUrl = item.owner.profile_pic_url,
                        }
                    };
                    if (comment.HasChildComment != 0)
                    {
                        foreach (var subCommnet in item.comment.child_comments)
                        {
                            comment.SubComment.CommentId = (subCommnet.comment.id);
                            comment.SubComment.Content = subCommnet.comment.text;
                            comment.HasLikeComment = subCommnet.comment.has_liked_comment;
                            comment.SubCommentId = (subCommnet.comment.id);
                            comment.User = new User()
                            {
                                UserId = subCommnet.owner.id,
                                Username = subCommnet.owner.username,
                                Fullname = subCommnet.owner.full_name,
                                IsPrivate = subCommnet.owner.is_private,
                                ProfilePicUrl = subCommnet.owner.profile_pic_url
                            };
                        }
                    }
                    comments.Add(comment);
                }
            }
            return comments;
        }

        public static async Task<List<User>> GetLikers(string postId)
        {
            var users = new List<User>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-profile1.p.rapidapi.com/likers/{postId}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4650f7d9dcmsh8265daf5ee89220p1deaf9jsnb7f0e3ecb30a" },
                    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<LikerRootObject>(body);

                foreach (var item in data.data.likers)
                {
                    User user = new User
                    {
                        UserId = item.id,
                        Username = item.username,
                        Fullname = item.full_name,
                        IsPrivate = item.is_private,
                        ProfilePicUrl = item.profile_pic_url
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public static async Task<List<User>> GetFollower(string username)
        {
            var users = new List<User>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-profile1.p.rapidapi.com/getfollowerswithusername/{username}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4650f7d9dcmsh8265daf5ee89220p1deaf9jsnb7f0e3ecb30a" },
                    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<FollowerRootObject>(body);

                foreach (var item in data.followers)
                {
                    User user = new User
                    {
                        UserId = item.id,
                        Username = item.username,
                        Fullname = item.full_name,
                        IsPrivate = item.is_private,
                        ProfilePicUrl = item.profile_pic_url
                    };
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
