﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrayOnTheWayEntities : DbContext
    {
        public PrayOnTheWayEntities()
            : base("name=PrayOnTheWayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsksToMinyan> AsksToMinyans { get; set; }
        public virtual DbSet<SafePointOnTheWay> SafePointOnTheWays { get; set; }
        public virtual DbSet<Minyan> Minyans { get; set; }
        public virtual DbSet<AskMinyan> AskMinyans { get; set; }
        public virtual DbSet<Prayer> Prayers { get; set; }
        public virtual DbSet<TimeAtTheDay> TimeAtTheDays { get; set; }
    }
}
