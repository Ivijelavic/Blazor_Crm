using CrmExpert.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CrmExpert.DbLayer
{
    public class MRManagementContext : DbContext
    {
        public MRManagementContext(DbContextOptions<MRManagementContext> options)
                                   : base(options)
        {

        }
        public DbSet<SCORING_Param1> SCORING_Param1 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SCORING_Param1>().ToTable("SCORING_Param1");

        }
    }
}


