using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Schemas
{
    internal class PostDetails
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UserUsername { get; set; } = null!;
    }
}
