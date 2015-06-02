using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}