//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicWallyMisr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Complaint
    {
        public System.Guid id { get; set; }
        public string complaintName { get; set; }
        public Nullable<System.Guid> visitId { get; set; }
    
        public virtual visit visit { get; set; }
    }
}
