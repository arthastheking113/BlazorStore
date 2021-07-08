using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class CustomUser : IdentityUser
    {
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string FirstName { get; set; }


        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public string Notes { get; set; }

        public string IpAdress { get; set; }
        public string ConnectionId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
