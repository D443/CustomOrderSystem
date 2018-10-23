namespace CustomOrderSystem.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int OrderAmount { get; set; }

        public string OrderDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }

        public virtual Product Product { get; set; }
    }
}
