using BlazorStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class WishList
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string ListPrice { get; set; }

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public string Slug { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }
    }
}
