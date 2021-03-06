﻿using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Api.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Infrastructure
{
    public class PropertyManagerDataContext : IdentityDbContext<PropertyManagerUser>
    {
        public PropertyManagerDataContext() : base("PropertyManager")
        {
        }

        // SQL Tables
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Lease> Leases { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Tenant> Tenants { get; set; }
        public IDbSet<WorkOrder> WorkOrders { get; set; }

        // Model our relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Properties)
                .WithRequired(p => p.Address)
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Tenants)
                .WithRequired(t => t.Address)
                .HasForeignKey(t => t.AddressId)
                .WillCascadeOnDelete(false);

            // Leases
            // There are no many relationships here, so move on.

            //Property
            modelBuilder.Entity<Property>()
            .HasMany(p => p.Leases)
            .WithRequired(l => l.Property)
            .HasForeignKey(l => l.PropertyId);

            modelBuilder.Entity<Property>()
            .HasMany(p => p.WorkOrders)
            .WithRequired(wo => wo.Property)
            .HasForeignKey(wo => wo.PropertyId);

            // Tenant
            modelBuilder.Entity<Tenant>()
            .HasMany(t => t.Leases)
            .WithRequired(l => l.Tenant)
            .HasForeignKey(l => l.TenantId);

            modelBuilder.Entity<Tenant>()
            .HasMany(t => t.WorkOrders)
            .WithOptional(wo => wo.Tenant)
            .HasForeignKey(wo => wo.TenantId);

            // Property Manager User

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.Properties)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.Tenants)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(false);

            // This will setup all relationships for ASP Net Identity
            base.OnModelCreating(modelBuilder);
        }
    }
}