using System.ComponentModel.DataAnnotations;

namespace TaskForge.Models
{
    public class Ukol
    {
        public int UkolId { get; set; }
        
        [Required(ErrorMessage = "Firma je povinná")]
        public int FirmaId { get; set; }

        [Required(ErrorMessage = "Popis úkolu je povinný")]
        
        public string Popis { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public DateTime DatumZadani { get; set; }
        [Required(ErrorMessage = "Priorita je povinná")]
        public string Priorita { get; set; } = string.Empty;
        [Required(ErrorMessage = "Stav je povinný")]
        public string Stav { get; set; } = string.Empty;
        public DateTime? TerminVyreseni { get; set; }
        public DateTime? DatumUzavreni { get; set; }
        public int? VlozilUzivatelId { get; set; }
        public Uzivatel? VlozilUzivatel { get; set; } = null!;
        public DateTime VlozenDatum { get; set; } = DateTime.Now;

        public Firma? Firma { get; set; }
        public List<Resitel> Resitele { get; set; } = new();
        public List<Zadatel> Zadatele { get; set; } = new();
        public List<ChecklistPolozka> ChecklistPolozky { get; set; } = new();
        public List<Priloha> Prilohy { get; set; } = new();
        public List<ChatZprava> ChatZpravy { get; set; } = new();
    }
}