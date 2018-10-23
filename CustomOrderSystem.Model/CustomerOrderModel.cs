using System.Collections.Generic;

namespace CustomOrderSystem.Model
{
    public  class CustomerOrderModel
    {
        public int UserId { get; set; }
        public OrderModel Order { get; set; }
      
    }
}
