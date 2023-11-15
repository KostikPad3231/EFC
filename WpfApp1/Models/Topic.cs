using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    internal class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Post> posts { get; set; } = new();
    }
}
