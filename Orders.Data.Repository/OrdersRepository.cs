using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Data.Models;

namespace Orders.Data.Repository
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(CSVContext dataContext,string fileName)
            : base(dataContext, fileName)
        {
        }


    }
}
