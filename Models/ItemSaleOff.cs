using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Models
{
    public class ItemSaleOff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePersentAmount { get; set; }
    }
}
