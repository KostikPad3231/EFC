using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
