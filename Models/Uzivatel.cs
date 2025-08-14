using System.ComponentModel.DataAnnotations.Schema;

namespace TaskForge.Models
{
    public class Uzivatel
    {
        public int UzivatelId { get; set; }
        public string Jmeno { get; set; } = string.Empty;
        public int FirmaId { get; set; }
        public string? Email { get; set; }
        public Firma Firma { get; set; } = null!;


        public List<Ukol> VlozeneUkoly { get; set; } = new();
        public List<ChecklistPolozka> ChecklistPolozky { get; set; } = new();
        public List<Priloha> Prilohy { get; set; } = new();
        public List<ChatZprava> ChatZpravy { get; set; } = new();

        public List<Resitel> Resitele { get; set; } = new(); // Vazba na řešené úkoly
        public List<Zadatel> Zadatele { get; set; } = new(); // Vazba na zadané úkoly
        
        [NotMapped]
        public IEnumerable<Ukol> ZadaneUkoly => Zadatele.Select(z => z.Ukol);
        [NotMapped]
        public IEnumerable<Ukol> ReseneUkoly => Resitele.Select(r => r.Ukol);
    }
}