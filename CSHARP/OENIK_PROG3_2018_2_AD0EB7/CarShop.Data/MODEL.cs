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
    
    public partial class MODEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODEL()
        {
            this.MODELEXTRASWITCHERs = new HashSet<MODELEXTRASWITCHER>();
        }
    
        public decimal model_id { get; set; }
        public Nullable<decimal> brand_id { get; set; }
        public string model_name { get; set; }
        public Nullable<decimal> release_date { get; set; }
        public Nullable<decimal> engine_volume { get; set; }
        public Nullable<decimal> horsepower { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual CARBRAND CARBRAND { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODELEXTRASWITCHER> MODELEXTRASWITCHERs { get; set; }
    }
}
