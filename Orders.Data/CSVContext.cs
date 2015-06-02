using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data
{
    public class CSVContext : IDisposable
    {
        private string _path = String.IsNullOrEmpty(DataResource.CsvFilePath.ToString()) ? System.Environment.CurrentDirectory : DataResource.CsvFilePath.ToString();            
       
        public CSVContext()
        {      
        }

        public string CsvFilePath { get { return _path; } }

        public IEnumerable<TEntity> GetTable<TEntity>(string name) where TEntity : class
        {
            StreamReader reader = File.OpenText(CsvFilePath +@"\" + name + ".csv");
            var csv = new CsvReader(reader);
            var records = csv.GetRecords<TEntity>();
            return (IEnumerable<TEntity>)records;
        }

        public void Dispose()
        {
         
        }
    }
}
