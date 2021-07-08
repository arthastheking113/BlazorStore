using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class InformationCheckOut
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 7)]
        public string Email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 4)]
        public string Address { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 5)]
        public string Zipcode { get; set; }

        public string Notes { get; set; }

        public bool CreateAccount { get; set; }
    }
}
