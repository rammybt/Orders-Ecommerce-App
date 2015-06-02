using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class OrderDetail : IEntity
    {
        public string ID { get; set; }
        public string OrderId { get; set; }
        public int LineId { get; set; }

        public string ItemId { get; set; }

        public int ItemQty { get; set; }

        public decimal ItemUnitPrice { get; set; }

    }
}
