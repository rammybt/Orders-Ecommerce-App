using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class Order : IEntity
    {
        public string ID { get; set; }
        public string OrderTotal{ get; set; }
        public string ETA { get; set; }
    }
}
