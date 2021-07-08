using BlazorStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string Content { get; set; }
        [Required]
        public string Price { get; set; }

        public double RateValue { get; set; }
        //[NotMapped]
        //public string ListPrice { get {  }
        public int Number_Of_Sold { get; set; }
        public int ViewCount { get; set; }

        public string ListPrice(ApplicationDbContext context, string Price, int ItemSaleOffId)
        {
            return (Convert.ToDecimal(Price) - Convert.ToDecimal(Price) * Convert.ToDecimal((context.ItemSaleOff.FirstOrDefault(i => i.Id == ItemSaleOffId)).SalePersentAmount)).ToString("0.##");
        }
        public bool IsProductReady { get; set; }

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        public string Slug { get; set; }

        public int ItemSaleOffId { get; set; }
        public virtual ItemSaleOff ItemSaleOff { get; set; }

        public int ItemStatusId { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public virtual ICollection<ItemAttachment> Attachments { get; set; } = new HashSet<ItemAttachment>();

        public virtual ICollection<CustomUser> CustomUsers { get; set; } = new HashSet<CustomUser>();

        public Item()
        {

        }
    }
}
