//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingSystem.EntityDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class APPROVALTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APPROVALTYPE()
        {
            this.APPROVALS = new HashSet<APPROVAL>();
        }
    
        public string approvalCode { get; set; }
        public string approvalName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVAL> APPROVALS { get; set; }
    }
}
