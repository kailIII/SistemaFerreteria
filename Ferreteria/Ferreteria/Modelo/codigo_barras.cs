//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ferreteria.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class codigo_barras
    {
        public codigo_barras()
        {
            this.producto = new HashSet<producto>();
        }
    
        public int id_cod_barras { get; set; }
        public string numero_cod_barras { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual ICollection<producto> producto { get; set; }
    }
}
