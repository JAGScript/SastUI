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
    
    public partial class TBL_TIPO_EQUIPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_TIPO_EQUIPO()
        {
            this.TBL_EQUIPO = new HashSet<TBL_EQUIPO>();
        }
    
        public int tp_id { get; set; }
        public string tp_descripcion { get; set; }
        public int tp_estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EQUIPO> TBL_EQUIPO { get; set; }
    }
}
