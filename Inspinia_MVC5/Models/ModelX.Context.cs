﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspinia_MVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cdashEntities1 : DbContext
    {
        public cdashEntities1()
            : base("name=cdashEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Committee> Committees { get; set; }
        public virtual DbSet<committee_Memberlist> committee_Memberlist { get; set; }
        public virtual DbSet<Inbox> Inboxes { get; set; }
        public virtual DbSet<meeting> meetings { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<agendanote> agendanotes { get; set; }
    }
}
