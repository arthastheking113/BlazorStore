using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

        public ICollection<WishList> WishLists { get; set; } = new HashSet<WishList>();

    }
}
