//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AskMinyan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AskMinyan()
        {
            this.AsksToMinyans = new HashSet<AsksToMinyan>();
        }
    
        public long IdAskMinyan { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public long IdPrayer { get; set; }
        public System.TimeSpan AskTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsksToMinyan> AsksToMinyans { get; set; }
        public virtual Prayer Prayer { get; set; }
    }
}
