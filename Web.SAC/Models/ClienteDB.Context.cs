﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.SAC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClientesEntities : DbContext
    {
        public ClientesEntities()
            : base("name=ClientesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
    
        public virtual int ins_Cliente(string nome, string usuario, string email, string senha)
        {
            var nomeParameter = nome != null ?
                new ObjectParameter("nome", nome) :
                new ObjectParameter("nome", typeof(string));
    
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var senhaParameter = senha != null ?
                new ObjectParameter("senha", senha) :
                new ObjectParameter("senha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ins_Cliente", nomeParameter, usuarioParameter, emailParameter, senhaParameter);
        }
    }
}