using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected IEnumerable<T> DataTable;

        public Repository(CSVContext dataContext, string fileName)
        {
            DataTable = dataContext.GetTable<T>(fileName);
        }

        #region Members
        public IEnumerable<T> GetAll()
        {
            return DataTable;
        }

        #endregion
    }
}
