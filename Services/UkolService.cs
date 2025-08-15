using Microsoft.EntityFrameworkCore;
using TaskForge.Models;
using TaskForge.Data;

namespace TaskForge.Services
{
    public interface IUkolService
    {
        Task<List<Ukol>> GetAllUkolyAsync();
        Task<Ukol?> GetUkolByIdAsync(int id);
        Task<Ukol> CreateUkolAsync(Ukol ukol);
        Task<Ukol> CreateUkolWithRelationsAsync(Ukol ukol, List<int> zadavateleIds, List<int> resiteleIds);
        Task<Ukol> UpdateUkolAsync(Ukol ukol);
        Task<List<Uzivatel>> GetAllUzivateleAsync();
        Task<List<Firma>> GetAllFirmyAsync();
    }
      
    public class UkolService : IUkolService
    {
        private readonly TaskForgeDbContext _context;
        
        public UkolService(TaskForgeDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Získá všechny úkoly včetně souvisejících dat
        /// </summary>
        public async Task<List<Ukol>> GetAllUkolyAsync()
        {
            return await _context.Ukoly
                .Include(u => u.Firma)
                .Include(u => u.VlozilUzivatel)
                .Include(u => u.Resitele)
                    .ThenInclude(r => r.Uzivatel)
                .Include(u => u.Zadatele)
                    .ThenInclude(z => z.Uzivatel)
                .Include(u => u.ChecklistPolozky)
                .OrderByDescending(u => u.DatumZadani)
                .ToListAsync();
        }

        /// <summary>
        /// Získá úkol podle ID s kompletními daty
        /// </summary>
        public async Task<Ukol?> GetUkolByIdAsync(int id)
        {
            return await _context.Ukoly
                .Include(u => u.Firma)
                .Include(u => u.VlozilUzivatel)
                .Include(u => u.Resitele)
                    .ThenInclude(r => r.Uzivatel)
                .Include(u => u.Zadatele)
                    .ThenInclude(z => z.Uzivatel)
                .Include(u => u.ChecklistPolozky)
                    .ThenInclude(cp => cp.VlozilUzivatel)
                .Include(u => u.Prilohy)
                .Include(u => u.ChatZpravy)
                    .ThenInclude(cz => cz.Uzivatel)
                .FirstOrDefaultAsync(u => u.UkolId == id);
        }

        /// <summary>
        /// Vytvoří nový úkol
        /// </summary>
        public async Task<Ukol> CreateUkolAsync(Ukol ukol)
        {
            // Nastavení základních hodnot
            ukol.DatumZadani = DateTime.Now;
            ukol.VlozenDatum = DateTime.Now;
            
            // Přidání úkolu do databáze
            _context.Ukoly.Add(ukol);
            await _context.SaveChangesAsync();
            
            // Vrácení úkolu s načtenými daty
            return await GetUkolByIdAsync(ukol.UkolId) ?? ukol;
        }

        /// <summary>
        /// Vytvoří nový úkol včetně zadavatelů a řešitelů
        /// </summary>
        public async Task<Ukol> CreateUkolWithRelationsAsync(Ukol ukol, List<int> zadavateleIds, List<int> resiteleIds)
        {
            // Nastavení základních hodnot
            ukol.DatumZadani = DateTime.Now;
            ukol.VlozenDatum = DateTime.Now;
            
            // Přidání úkolu do databáze
            _context.Ukoly.Add(ukol);
            await _context.SaveChangesAsync();
            
            // Přidání zadavatelů
            foreach (var zadatelId in zadavateleIds)
            {
                var zadatel = new Zadatel
                {
                    UkolId = ukol.UkolId,
                    UzivatelId = zadatelId
                };
                _context.Zadatele.Add(zadatel);
            }
            
            // Přidání řešitelů
            foreach (var resitelId in resiteleIds)
            {
                var resitel = new Resitel
                {
                    UkolId = ukol.UkolId,
                    UzivatelId = resitelId
                };
                _context.Resitele.Add(resitel);
            }
            
            // Uložení relací
            await _context.SaveChangesAsync();
            
            // Vrácení úkolu s načtenými daty
            return await GetUkolByIdAsync(ukol.UkolId) ?? ukol;
        }

        /// <summary>
        /// Aktualizuje existující úkol
        /// </summary>
        public async Task<Ukol> UpdateUkolAsync(Ukol ukol)
        {
            _context.Entry(ukol).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetUkolByIdAsync(ukol.UkolId) ?? ukol;
        }

        /// <summary>
        /// Získá všechny uživatele pro výběr v formulářích
        /// </summary>
        public async Task<List<Uzivatel>> GetAllUzivateleAsync()
        {
            return await _context.Uzivatele
                .Include(u => u.Firma)
                .OrderBy(u => u.Jmeno)
                .ToListAsync();
        }

        /// <summary>
        /// Získá všechny firmy pro výběr v formulářích
        /// </summary>
        public async Task<List<Firma>> GetAllFirmyAsync()
        {
            return await _context.Firmy
                .OrderBy(f => f.Nazev)
                .ToListAsync();
        }
    }
}