using Microsoft.EntityFrameworkCore;
using CrmExpert.Model;
namespace CrmExpert.DbLayer
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options)
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
        public DbSet<SCORING_Param1> SCORING_Param1 { get; set; }
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
    }
}
