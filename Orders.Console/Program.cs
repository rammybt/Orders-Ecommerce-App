using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Data;
using Orders.Data.Repository;
using Orders.Data.Models;

namespace Orders.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var csvcontext = new CSVContext())
            {
                var ordRepository = new Repository<Order>(csvcontext, "Orders");

                IEnumerable<Order> ordersAll = ordRepository.GetAll();
                    
                foreach (Order ord in ordersAll)
                {
                    System.Console.WriteLine(ord.ID + " : " + ord.OrderTotal + " : " + ord.ETA);
                }

                System.Console.WriteLine("---------------------------------");

                var ordDetailRepository = new Repository<OrderDetail>(csvcontext, "OrderDetail");

                IEnumerable<OrderDetail> orderDetailAll = ordDetailRepository.GetAll();

                foreach (OrderDetail ordDet in orderDetailAll)
                {
                    System.Console.WriteLine(ordDet.ItemId+ " : " + ordDet.ItemQty+ " : " + ordDet.ItemUnitPrice + " : "+ ordDet.OrderId);
                }

                System.Console.ReadKey();
            }
        }
    }
}
