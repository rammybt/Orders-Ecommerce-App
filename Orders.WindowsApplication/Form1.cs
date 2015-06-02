using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orders.Data;
using Orders.Data.Repository;
using Orders.Data.Models;

namespace Orders.WindowsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<Order> ordersAll;
            IEnumerable<OrderDetail> orderDetailAll;
            using (var csvcontext = new CSVContext())
            {
                var ordRepository = new Repository<Order>(csvcontext, "Orders");

                ordersAll = ordRepository.GetAll();

                var ordDetailRepository = new Repository<OrderDetail>(csvcontext, "OrderDetail");

                orderDetailAll = ordDetailRepository.GetAll();

                PopulateTreeView(ordersAll.ToList(), orderDetailAll.ToList());
            }
        }

        List<TreeViewItem> treeViewList = new List<TreeViewItem>();
        private void PopulateTreeView(IEnumerable<Order> ordersAll, IEnumerable<OrderDetail> orderDetailAll)
        {
           
            int cnt = 1;
            foreach (var ord in ordersAll)
            {
                treeViewList.Add(new TreeViewItem()
                {
                    ParentID = 0,
                    ID = cnt,
                    Text = ord.ID
                });                
                foreach (var ordDet in orderDetailAll)
                {                   
                    if (ord.ID == ordDet.OrderId)
                    {                        
                        treeViewList.Add(new TreeViewItem()
                        {
                            ParentID = cnt,
                            ID = cnt + 1 ,
                            Text = ordDet.ItemId
                        });
                        cnt++;
                    }
                    
                }
                cnt++;
            }           
            PopulateTreeView(0, null);
        }

        private void PopulateTreeView(int parentId, TreeNode parentNode)
        {
            var filteredItems = treeViewList.Where(item => item.ParentID == parentId);
            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(i.Text);
                else
                    childNode = parentNode.Nodes.Add(i.Text);

                PopulateTreeView(i.ID, childNode);
            }
        }

    }

    public class TreeViewItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Text { get; set; }
    }
}
