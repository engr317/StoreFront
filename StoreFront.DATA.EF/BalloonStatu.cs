//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreFront.DATA.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class BalloonStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BalloonStatu()
        {
            this.Balloons = new HashSet<Balloon>();
        }
    
        public int BalloonStatusID { get; set; }
        public string BalloonStatusName { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Balloon> Balloons { get; set; }
    }
}