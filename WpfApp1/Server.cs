using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using WpfApp1.Models;
using WpfApp1.Schemas;

namespace WpfApp1
{
    internal class Server
    {
        ApplicationContext db = new ApplicationContext();
        public Dictionary<string, string> CreateUser(string username, string password)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            User? user = db.Users.Where(u => u.Username == username).FirstOrDefault();
            if (user != null)
            {
                result.Add("details", "failed");
                result.Add("username", "User with this username already exists");
            }
            else
            {
                User new_user = new User { Username = username, Password = password };
                db.Users.Add(new_user);
                db.SaveChanges();
                result.Add("details", "success");
            }
            return result;
        }

        public Dictionary<string, string> Login(string username, string password)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            User? user = db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                result.Add("details", "success");
            }
            else
            {
                result.Add("details", "failed");
                result.Add("non_field_errors", "Pair username/password isn't valid");
            }
            return result;
        }

        public User GetUser(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault()!;
        }

        public Dictionary<string, string> UpdateUser(string RealUsername, string username)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            User? checkUser = db.Users.Where(u => u.Username == username).FirstOrDefault();
            if (checkUser != null)
            {
                result.Add("details", "failed");
                result.Add("username", "User with this username already exists");
                return result;
            }

            User? user = db.Users.Where(u => u.Username == RealUsername).FirstOrDefault()!;
            if (user != null)
            {
                user.Username = username;
                db.SaveChangesAsync();
                result.Add("details", "success");
            }

            return result;
        }

        public (int, List<TopicDetails>) GetTopics(int page = 0, string search = "", int sorting = 0)
        {
            int pageSize = 5;
            search = search.ToLower();
            var topics = db.Topics.Where(t => EF.Functions.Like(t.Name.ToLower(), $"%{search}%"));
            var topicDetails = topics.Select(t => new TopicDetails
            {
                Id = t.Id,
                Name = t.Name,
                CreatedAt = t.CreatedAt,
                UserUsername = t.User.Username,
                PostsCount = t.posts.Count()
            });
            int pagesCount = (int)Math.Ceiling(1.0 * topicDetails.Count() / pageSize);

            if (sorting == 0)
            {
                return (pagesCount, topicDetails
                    .Skip(page * 5)
                    .Take(5)
                    .ToList());
            }
            else if (sorting == 1)
            {
                return (pagesCount, topicDetails
                    .OrderByDescending(t => t.Name)
                    .Skip(page * 5)
                    .Take(5)
                    .ToList());
            }
            else
            {
                return (pagesCount, topicDetails
                    .OrderBy(t => t.Name)
                    .Skip(page * 5)
                    .Take(5)
                    .ToList());
            }

        }

        public Dictionary<string, string> NewTopic(string username, string subject, string message)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            User user = db.Users.Where(u => u.Username == username).FirstOrDefault()!;
            Topic new_topic = new Topic { Name = subject, User = user };
            Post new_post = new Post { Message = message, Topic = new_topic, User = user };

            db.Topics.Add(new_topic);
            db.Posts.Add(new_post);
            db.SaveChanges();

            result.Add("details", "success");

            return result;
        }

        public Topic GetTopic(int topicId)
        {
            return db.Topics.Where(t => t.Id == topicId).FirstOrDefault()!;
        }

        public Dictionary<string, string> DeleteTopic(int topicId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            Topic? topic = db.Topics.Where(t => t.Id == topicId).FirstOrDefault();
            if (topic != null)
            {
                db.Topics.Remove(topic);
                db.SaveChanges();
                result.Add("details", "success");
            }

            return result;
        }

        public Dictionary<string, string> UpdateTopic(int topicId, string subject)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            Topic? topic = db.Topics.Where(t => t.Id == topicId).FirstOrDefault();
            if (topic != null)
            {
                topic.Name = subject;
                db.SaveChanges();
                result.Add("details", "success");
            }

            return result;
        }

        public List<PostDetails> GetTopicPosts(int topicId)
        {
            return db.Posts
                .Where(p => p.TopicId == topicId)
                .Select(p => new PostDetails
                {
                    Id = p.Id,
                    Message = p.Message,
                    UpdatedAt = p.UpdatedAt,
                    UserUsername = p.User.Username
                })
                .ToList();
        }

        public Post GetPost(int postId)
        {
            return db.Posts.Where(p => p.Id == postId).FirstOrDefault()!;
        }

        public Dictionary<string, string> Reply(int topicId, string username, string message)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            User user = db.Users.Where(u => u.Username == username).FirstOrDefault()!;
            Post post = new Post { Message = message, User = user, TopicId = topicId };
            db.Posts.Add(post);
            db.SaveChanges();

            result.Add("details", "success");

            return result;
        }

        public Dictionary<string, string> DeletePost(int postId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            Post? post = db.Posts.Where(t => t.Id == postId).FirstOrDefault();
            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
                result.Add("details", "success");
            }

            return result;
        }

        public Dictionary<string, string> UpdatePost(int postId, string message)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            Post? post = db.Posts.Where(t => t.Id == postId).FirstOrDefault();
            if (post != null)
            {
                post.Message = message;
                post.UpdatedAt = DateTime.UtcNow;
                db.SaveChanges();
                result.Add("details", "success");
            }

            return result;
        }
    }
}
