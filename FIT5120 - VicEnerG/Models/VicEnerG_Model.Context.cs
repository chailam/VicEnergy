﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5120___VicEnerG.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VicEnerG_ModelContainer : DbContext
    {
        public VicEnerG_ModelContainer()
            : base("name=VicEnerG_ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Station> StationSet { get; set; }
        public virtual DbSet<StationData> StationDataSet { get; set; }
        public virtual DbSet<Appliance> ApplianceSet { get; set; }
        public virtual DbSet<PostcodeData> PostcodeDatas { get; set; }
    }
}
