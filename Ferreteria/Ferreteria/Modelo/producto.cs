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
    
    public partial class producto
    {
        public producto()
        {
            this.detalle_venta = new HashSet<detalle_venta>();
        }
    
        public string cod_producto { get; set; }
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public Nullable<int> id_marca { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> precio { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public string cod_barra { get; set; }
        public Nullable<int> stock { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual ICollection<detalle_venta> detalle_venta { get; set; }
        public virtual marca marca { get; set; }
    }
}
