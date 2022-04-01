using CrmExpert.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CrmExpert.DbLayer
{
    public class OrbisContext : DbContext
    {
        public OrbisContext(DbContextOptions<OrbisContext> options)
                                 : base(options)
        {

        }
        public DbSet<Klijenti> Klijenti { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klijenti>().ToTable("Klijenti");

        }
    }
}
