using Microsoft.EntityFrameworkCore;
using TaskForge.Models;

namespace TaskForge.Data
{
    public class TaskForgeDbContext : DbContext
    {
        public TaskForgeDbContext(DbContextOptions<TaskForgeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Zadatel> Zadatele { get; set; }
        public DbSet<Resitel> Resitele { get; set; }
        public DbSet<Firma> Firmy { get; set; }
        public DbSet<Ukol> Ukoly { get; set; }
        public DbSet<ChecklistPolozka> ChecklistPolozky { get; set; }
        public DbSet<Priloha> Prilohy { get; set; }
        public DbSet<ChatZprava> ChatZpravy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ukol
            modelBuilder.Entity<Ukol>(entity =>
            {
                entity.HasKey(u => u.UkolId);
                entity.Property(u => u.Popis).IsRequired();
                entity.Property(u => u.Detail);
                entity.Property(u => u.Priorita).IsRequired();
                entity.Property(u => u.Stav).IsRequired();
                entity.Property(u => u.DatumZadani).IsRequired();
                entity.Property(u => u.DatumUzavreni);
                entity.Property(u => u.TerminVyreseni);
                entity.Property(u => u.VlozilUzivatelId).IsRequired();

                entity.HasOne(u => u.Firma)
                    .WithMany(f => f.Ukoly)
                    .HasForeignKey(u => u.FirmaId);
                    
                entity.HasOne(u => u.VlozilUzivatel)
                    .WithMany(u => u.VlozeneUkoly)
                    .HasForeignKey(u => u.VlozilUzivatelId);
            });

            //Zadatel
            modelBuilder.Entity<Zadatel>(entity =>
            {
                entity.HasKey(z => z.ZadatelId);
                entity.HasOne(z => z.Ukol)
                    .WithMany(u => u.Zadatele)
                    .HasForeignKey(z => z.UkolId);
                entity.HasOne(z => z.Uzivatel)
                    .WithMany(u => u.Zadatele)
                    .HasForeignKey(z => z.UzivatelId);
            });

            //Resitel
            modelBuilder.Entity<Resitel>(entity =>
            {
                entity.HasKey(r => r.ResitelId);
                entity.HasOne(r => r.Ukol)
                    .WithMany(u => u.Resitele)
                    .HasForeignKey(r => r.UkolId);
                entity.HasOne(r => r.Uzivatel)
                    .WithMany(u => u.Resitele)
                    .HasForeignKey(r => r.UzivatelId);
            });

            //Prilohy
            modelBuilder.Entity<Priloha>(entity =>
            {
                entity.HasKey(p => p.PrilohaId);
                entity.Property(p => p.NazevSouboru).IsRequired();
                entity.Property(p => p.Cesta).IsRequired();
                entity.Property(p => p.VlozilUzivatelId).IsRequired();
                entity.Property(p => p.VlozenDatum).IsRequired();
                entity.Property(p => p.Typ);
                entity.Property(p => p.Velikost);
                entity.Property(p => p.UkolId).IsRequired();
                entity.HasOne(p => p.VlozilUzivatel)
                    .WithMany(u => u.Prilohy)
                    .HasForeignKey(p => p.VlozilUzivatelId);
                entity.HasOne(p => p.Ukol)
                    .WithMany(u => u.Prilohy)
                    .HasForeignKey(p => p.UkolId);
            });
            //ChatZprava
            modelBuilder.Entity<ChatZprava>(entity =>
            {
                entity.HasKey(c => c.ZpravaId);
                entity.Property(c => c.Text).IsRequired();
                entity.Property(c => c.Datum).IsRequired();
                entity.Property(c => c.UzivatelId).IsRequired();
                entity.Property(c => c.Uzivatel).IsRequired();
                entity.HasOne(c => c.Ukol)
                    .WithMany(u => u.ChatZpravy)
                    .HasForeignKey(c => c.UkolId);
            });
            //ChecklistPolozka
            modelBuilder.Entity<ChecklistPolozka>()
                .HasOne(cp => cp.Ukol)
                .WithMany(u => u.ChecklistPolozky)
                .HasForeignKey(cp => cp.UkolId);

            modelBuilder.Entity<ChecklistPolozka>()
                .HasOne(cp => cp.VlozilUzivatel)
                .WithMany(u => u.ChecklistPolozky)
                .HasForeignKey(cp => cp.VlozilUzivatelId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=TaskForge.db");
            }
        }
    }       
}