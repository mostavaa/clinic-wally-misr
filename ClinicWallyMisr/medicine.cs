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
    
    public partial class medicine
    {
        public System.Guid id { get; set; }
        public string code { get; set; }
        public string scientificName { get; set; }
        public string commercialName { get; set; }
        public string activeIngredient { get; set; }
        public string type { get; set; }
        public string dose { get; set; }
        public string sideEffects { get; set; }
        public string notes { get; set; }
        public string UOM { get; set; }
        public string Route { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public Nullable<System.Guid> prescriptionId { get; set; }
    
        public virtual prescription prescription { get; set; }
    }
}
