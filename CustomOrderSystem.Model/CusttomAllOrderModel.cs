using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Model
{
    public class CustomAllOrderModel
    {
        public CustomAllOrderModel()
        {
            this.Orders = new List<OrderModel>();
        }

        public int UserId { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
