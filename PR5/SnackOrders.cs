//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR5
{
    using System;
    using System.Collections.Generic;
    
    public partial class SnackOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SnackOrders()
        {
            this.TicketOrders = new HashSet<TicketOrders>();
        }
    
        public int ID_SnackOrders { get; set; }
        public int SnackID { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
    
        public virtual Snacks Snacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketOrders> TicketOrders { get; set; }
    }
}
