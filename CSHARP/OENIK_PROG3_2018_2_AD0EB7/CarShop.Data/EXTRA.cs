//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EXTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXTRA()
        {
            this.MODELEXTRASWITCHERs = new HashSet<MODELEXTRASWITCHER>();
        }
    
        public decimal extra_id { get; set; }
        public string category { get; set; }
        public string extra_name { get; set; }
        public Nullable<decimal> extra_price { get; set; }
        public string color { get; set; }
        public string usagemorethanonce { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODELEXTRASWITCHER> MODELEXTRASWITCHERs { get; set; }
    }
}
