namespace CustomOrderSystem.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerOrder")]
    public partial class CustomerOrder
    {
        public int CustomerOrderId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
