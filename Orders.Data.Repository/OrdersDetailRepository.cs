using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Data.Models;

namespace Orders.Data.Repository
{
    public class OrdersDetailRepository : Repository<OrderDetail>, IOrdersDetailRepository
    {
        public OrdersDetailRepository(CSVContext dataContext,string fileName)
            : base(dataContext, fileName)
        {
        }
    }
}