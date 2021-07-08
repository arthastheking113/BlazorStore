using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string TrackingNumber { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool IsSold { get; set; }

        public int Quantity { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset Date { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string Notes { get; set; }

        public string Slug { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string TrackingLink { get; set; }

        public bool IsViewByOwner { get; set; }

        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
