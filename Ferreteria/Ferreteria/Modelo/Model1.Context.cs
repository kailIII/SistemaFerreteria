﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FerreteriaEntities : DbContext
    {
        public FerreteriaEntities()
            : base("name=FerreteriaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<categoria> categoria { get; set; }
        public DbSet<detalle_venta> detalle_venta { get; set; }
        public DbSet<marca> marca { get; set; }
        public DbSet<producto> producto { get; set; }
        public DbSet<tipo_usuario> tipo_usuario { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<venta> venta { get; set; }
    }
}
