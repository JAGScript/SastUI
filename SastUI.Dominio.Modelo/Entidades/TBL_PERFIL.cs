//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SastUI.Dominio.Modelo.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_PERFIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PERFIL()
        {
            this.TBL_USUARIO = new HashSet<TBL_USUARIO>();
        }
    
        public int pe_id { get; set; }
        public string pe_nombre { get; set; }
        public int pe_estado { get; set; }
        public Nullable<int> pe_permisos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USUARIO> TBL_USUARIO { get; set; }
    }
}
