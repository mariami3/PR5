﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaEntities2 : DbContext
    {
        public CinemaEntities2()
            : base("name=CinemaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<SnackOrders> SnackOrders { get; set; }
        public virtual DbSet<Snacks> Snacks { get; set; }
        public virtual DbSet<StatusTicket> StatusTicket { get; set; }
        public virtual DbSet<TicketOrders> TicketOrders { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}
