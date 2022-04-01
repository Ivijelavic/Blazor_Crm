using CrmExpert.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CrmExpert.DbLayer
{
    public class OrbisDbContext : DbContext
    {
        public OrbisDbContext(DbContextOptions<OrbisDbContext> options)
                                     : base(options)
        {
        }
        public DbSet<Prilike> Prilike { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Klijenti> Klijenti { get; set; }
        public DbSet<Kontakti> Kontakti { get; set; }
        public DbSet<Prilika_Komentari> Prilika_Komentari { get; set; }
        public DbSet<Scoring> Scoring { get; set; }
        public DbSet<ListaPonudaDobavljaci> ListaPonudaDobavljaci { get; set; }
        public DbSet<Valute> Valute { get; set; }
        public DbSet<Klijent_Kontakti> Klijent_Kontakti { get; set; }
        public DbSet<PonudePrilika> PonudePrilika { get; set; }
        public DbSet<StatusOdobrenja> StatusOdobrenja { get; set; }
        public DbSet<Vrsta_Leasinga> Vrsta_Leasinga { get; set; }
        public DbSet<Kolaterali> Kolaterali { get; set; }
        public DbSet<BuyBackUgovor> BuyBackUgovor { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<VrstePrilike> vrstePrilike { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<ListaPonudaDobavljaciStavke> ListaPonudaDobavljaciStavke { get; set; }
        public DbSet<PonudePrilika_Dobavljaci> PonudePrilika_Dobavljaci { get; set; }

        public DbSet<TranSektor> TranSektor { get; set; }
        public DbSet<Sektor> Sektor { get; set; }
        public DbSet<State> Drzava { get; set; }
        public DbSet<HtmlTemplate> HtmlTemplate { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Ponude_Dobavljaci_Documents> Ponude_Dobavljaci_Documents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prilike>().ToTable("Prilike");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Klijenti>().ToTable("Klijenti");
            modelBuilder.Entity<Kontakti>().ToTable("Kontakti");
            modelBuilder.Entity<Prilika_Komentari>().ToTable("Prilika_Komentari");
            modelBuilder.Entity<Scoring>().ToTable("SCORING");
            modelBuilder.Entity<ListaPonudaDobavljaci>().ToTable("ListaPonudaDobavljaci");
            modelBuilder.Entity<Valute>().ToTable("Valute");
            modelBuilder.Entity<Klijent_Kontakti>().ToTable("Klijent_Kontakti");
            modelBuilder.Entity<PonudePrilika>().ToTable("PonudePrilika");
            modelBuilder.Entity<StatusOdobrenja>().ToTable("StatusOdobrenja");
            modelBuilder.Entity<Vrsta_Leasinga>().ToTable("Vrsta_Leasinga");
            modelBuilder.Entity<Kolaterali>().ToTable("Kolaterali");
            modelBuilder.Entity<BuyBackUgovor>().ToTable("BuyBackUgovor");
            modelBuilder.Entity<NacinPlacanja>().ToTable("NacinPlacanja");
            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<VrstePrilike>().ToTable("Vrsta_Prilika");
            modelBuilder.Entity<Komentar>().ToTable("Komentari");
            modelBuilder.Entity<ListaPonudaDobavljaciStavke>().ToTable("ListaPonudaDobavljaciStavke");
            modelBuilder.Entity<PonudePrilika_Dobavljaci>().ToTable("PonudePrilika_Dobavljaci");
            modelBuilder.Entity<TranSektor>().ToTable("TranSektor");
            modelBuilder.Entity<Sektor>().ToTable("Sektor");
            modelBuilder.Entity<State>().ToTable("Drzava");
            modelBuilder.Entity<HtmlTemplate>().ToTable("HtmlTemplate");
            modelBuilder.Entity<Messages>().ToTable("Messages");
            modelBuilder.Entity<Ponude_Dobavljaci_Documents>().ToTable("Ponude_Dobavljaci_Documents");
        }
    }
}
