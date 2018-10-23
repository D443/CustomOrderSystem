using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderSystem.Model
{
    public class OrderModel
    {

        public int ID { get; set; }
        public int ProductId { get; set; }
        public int OrderAmount { get; set; }
        public string OrderDescription { get; set; }

    }

}
