namespace TaskForge.Models
{
    public class Uzivatel
    {
        public int UzivatelId { get; set; }
        public string Jmeno { get; set; }// = string.Empty;       
        public int FirmaId { get; set; }
        public string? Email { get; set; }
        public Firma Firma { get; set; }// = null!;
        
        public List<Ukol> ZadaneUkoly { get; set; } = new();
        public List<Resitel> ReseneUkoly { get; set; } = new();
        public List<ChecklistPolozka> ChecklistPolozky { get; set; } = new();
        public List<Priloha> Prilohy { get; set; } = new();
        public List<ChatZprava> ChatZpravy { get; set; } = new();
    }
}