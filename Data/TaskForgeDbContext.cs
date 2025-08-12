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
            //Firma
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.HasKey(f => f.FirmaId);
                entity.Property(f => f.Nazev).IsRequired();
                entity.Property(f => f.Popis);
                entity.Property(f => f.Adresa);
                entity.Property(f => f.Telefon);
            });

            //Uzivatel
            modelBuilder.Entity<Uzivatel>(entity =>
            {
                entity.HasKey(u => u.UzivatelId);
                entity.Property(u => u.Jmeno).IsRequired();
                entity.Property(u => u.Email);
                entity.HasOne(u => u.Firma)
                    .WithMany(f => f.Uzivatele)
                    .HasForeignKey(u => u.FirmaId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

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
                    .HasForeignKey(u => u.FirmaId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(u => u.VlozilUzivatel)
                    .WithMany(u => u.VlozeneUkoly)
                    .HasForeignKey(u => u.VlozilUzivatelId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Zadatel
            modelBuilder.Entity<Zadatel>(entity =>
            {
                entity.HasKey(z => z.ZadatelId);
                entity.HasOne(z => z.Ukol)
                    .WithMany(u => u.Zadatele)
                    .HasForeignKey(z => z.UkolId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(z => z.Uzivatel)
                    .WithMany(u => u.Zadatele)
                    .HasForeignKey(z => z.UzivatelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //Resitel
            modelBuilder.Entity<Resitel>(entity =>
            {
                entity.HasKey(r => r.ResitelId);
                entity.HasOne(r => r.Ukol)
                    .WithMany(u => u.Resitele)
                    .HasForeignKey(r => r.UkolId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Uzivatel)
                    .WithMany(u => u.Resitele)
                    .HasForeignKey(r => r.UzivatelId)
                    .OnDelete(DeleteBehavior.Restrict);
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
                    .HasForeignKey(p => p.VlozilUzivatelId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Ukol)
                    .WithMany(u => u.Prilohy)
                    .HasForeignKey(p => p.UkolId)
                    .OnDelete(DeleteBehavior.Cascade);
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
                    .HasForeignKey(c => c.UkolId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.Uzivatel)
                    .WithMany(u => u.ChatZpravy)
                    .HasForeignKey(c => c.UzivatelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            //ChecklistPolozka
            modelBuilder.Entity<ChecklistPolozka>(entity =>
            {
                entity.HasKey(cp => cp.PolozkaId);
                entity.Property(cp => cp.UkolId).IsRequired();
                entity.Property(cp => cp.Nazev).IsRequired();
                entity.Property(cp => cp.Popis).IsRequired();
                entity.Property(cp => cp.Stav).IsRequired();
                entity.Property(cp => cp.Termin);
                entity.Property(cp => cp.DatumSplneni);
                entity.Property(cp => cp.Priorita).IsRequired();
                entity.Property(cp => cp.VlozenDatum).IsRequired();
                entity.Property(cp => cp.VlozilUzivatelId).IsRequired();
                entity.HasOne(cp => cp.Ukol)
                    .WithMany(u => u.ChecklistPolozky)
                    .HasForeignKey(cp => cp.UkolId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(cp => cp.VlozilUzivatel)
                    .WithMany(u => u.ChecklistPolozky)
                    .HasForeignKey(cp => cp.VlozilUzivatelId)
                    .OnDelete(DeleteBehavior.Restrict);

            }); 
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