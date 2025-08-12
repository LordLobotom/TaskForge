namespace TaskForge.Models
{
    public class Ukol
    {
        public int UkolId { get; set; }
        public int? FirmaId { get; set; }
        public string Popis { get; set; } = string.Empty; 
        public string? Detail { get; set; }
        public DateTime DatumZadani { get; set; }
        public string Priorita { get; set; } = string.Empty;
        public string Stav { get; set; } = string.Empty;
        public DateTime? TerminVyreseni { get; set; }
        public DateTime? DatumUzavreni { get; set; }
        public int VlozilUzivatelId { get; set; }
        public Uzivatel VlozilUzivatel { get; set; } = null!;


        public Firma? Firma { get; set; }
        public List<Resitel> Resitele { get; set; } = new();
        public List<Zadatel> Zadatele { get; set; } = new();
        public List<ChecklistPolozka> ChecklistPolozky { get; set; } = new();
        public List<Priloha> Prilohy { get; set; } = new();
        public List<ChatZprava> ChatZpravy { get; set; } = new();
    }
}