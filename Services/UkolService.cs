using Microsoft.EntityFrameworkCore;
using TaskForge.Models;
using TaskForge.Data;

namespace TaskForge.Services
{
    public interface IUkolService
    {
        Task<List<Ukol>> GetAllUkolyAsync();
        Task<Ukol?> GetUkolByIdAsync(int id);
        //Task<Ukol> CreateUkolAsync(Ukol ukol);
        //Task<Ukol> UpdateUkolAsync(Ukol ukol);
        //Task DeleteUkolAsync(int id);
        //Task<List<Ukol>> GetUkolyByStavAsync(string stav);
        //Task<List<Ukol>> GetUkolyByPrioritaAsync(string priorita);
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
    }
}