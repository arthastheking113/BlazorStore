using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public int RateId { get; set; }
        public virtual Rate Rate { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }
    }
}
