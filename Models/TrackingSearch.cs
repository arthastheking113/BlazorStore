using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class TrackingSearch
    {
        [Required]
        public string TrackingNumber { get; set; }
    }
}
