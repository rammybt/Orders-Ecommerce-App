using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Orders.Data.Models;

namespace Orders.Data.Repository
{
    public interface IOrdersDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
    }
}