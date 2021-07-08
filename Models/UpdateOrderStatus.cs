using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class UpdateOrderStatus
    {
        public string TrackingOrder { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        public string TrackingLink { get; set; }
    }
}
