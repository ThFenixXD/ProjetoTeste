﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoTeste
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_ProjetoTesteEntities : DbContext
    {
        public db_ProjetoTesteEntities()
            : base("name=db_ProjetoTesteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_chave> tb_chave { get; set; }
        public virtual DbSet<tb_fabricante> tb_fabricante { get; set; }
        public virtual DbSet<tb_software> tb_software { get; set; }
        public virtual DbSet<tb_tecnologia> tb_tecnologia { get; set; }
        public virtual DbSet<tb_login> tb_login { get; set; }
    }
}
