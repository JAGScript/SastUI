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
    
    public partial class TBL_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USUARIO()
        {
            this.TBL_CABECERA_FICHA = new HashSet<TBL_CABECERA_FICHA>();
        }
    
        public int us_id { get; set; }
        public int pe_id { get; set; }
        public string us_login { get; set; }
        public string us_pass { get; set; }
        public string us_nombre { get; set; }
        public string us_correo { get; set; }
        public string us_identificacion { get; set; }
        public int us_estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CABECERA_FICHA> TBL_CABECERA_FICHA { get; set; }
        public virtual TBL_PERFIL TBL_PERFIL { get; set; }
    }
}
