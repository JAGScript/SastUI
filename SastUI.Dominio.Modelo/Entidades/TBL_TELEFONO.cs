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
    
    public partial class TBL_TELEFONO
    {
        public int te_id { get; set; }
        public int tt_id { get; set; }
        public int cl_id { get; set; }
        public string te_numero { get; set; }
        public int te_estado { get; set; }
    
        public virtual TBL_CLIENTE TBL_CLIENTE { get; set; }
        public virtual TBL_TIPO_TELEFONO TBL_TIPO_TELEFONO { get; set; }
    }
}