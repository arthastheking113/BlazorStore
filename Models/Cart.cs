using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }
        public bool IsSold { get; set; }

        public int Quantity { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public string Notes { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string Slug { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }
    }
}
