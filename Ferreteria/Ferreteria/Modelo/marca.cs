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
    
    public partial class marca
    {
        public marca()
        {
            this.producto = new HashSet<producto>();
        }
    
        public int id_marca { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<producto> producto { get; set; }
    }
}
