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

                IEnumerable<Order> ordersAll = ordRepository.GetAll().ToList();
                    
                foreach (Order ord in ordersAll)
                {
                    System.Console.WriteLine(ord.ID + " : " + ord.OrderTotal + " : " + ord.ETA);
                }

                System.Console.WriteLine("---------------------------------");

                var ordDetailRepository = new OrdersDetailRepository(csvcontext, "OrderDetail");

                IEnumerable<OrderDetail> orderDetailAll = ordDetailRepository.GetAll().ToList();

                foreach (OrderDetail ordDet in orderDetailAll)
                {
                    System.Console.WriteLine(ordDet.ItemId+ " : " + ordDet.ItemQty+ " : " + ordDet.ItemUnitPrice + " : "+ ordDet.OrderId);
                }

                System.Console.WriteLine("---------------------------------");

                var ord1 = (Order)ordRepository.GetOrderById("ORD5");
                System.Console.WriteLine(ord1.ID + " : " + ord1.ETA + " : " + ord1.OrderTotal);


                IEnumerable<OrderDetail> orddet1 = ordDetailRepository.GetOrderDetail("ORD5");
                foreach (var det in orddet1)
                {
                    System.Console.WriteLine(det.ID + " : " + det.OrderId + " : " + det.ItemId+ " : " + det.ItemQty+ " : " + det.ItemUnitPrice);
                }
                System.Console.ReadKey();
            }
        }
    }
}
