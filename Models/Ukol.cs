namespace TaskForge.Models
{
    public class Ukol
    {
        public int UkolId { get; set; }
        public int? FirmaId { get; set; }
        public string Popis { get; set; } = string.Empty; 
        public string? Detail { get; set; }
        public DateTime DatumZadani { get; set; }
        public int ZadavatelId { get; set; } 
        public string Priorita { get; set; } = string.Empty;
        public string Stav { get; set; } = string.Empty;
        public DateTime? TerminVyreseni { get; set; }
        public DateTime? DatumUzavreni { get; set; }
        public int VlozilUzivatelId { get; set; }
        public DateTime VlozenDatum { get; set; }       
        public Firma? Firma { get; set; }
        public Uzivatel Zadavatel { get; set; } = null!;
        public Uzivatel VlozilUzivatel { get; set; } = null!;


        public List<Resitel> Resitele { get; set; } = new(); // List of users assigned to the task
        public List<Zadavatel> Zadavatele { get; set; } = new(); // List of users who created the task
        public List<ChecklistPolozka> ChecklistPolozky { get; set; } = new(); // List of checklist items associated with the task
        public List<Priloha> Prilohy { get; set; } = new(); // List of attachments associated with the task
        public List<ChatZprava> ChatZpravy { get; set; } = new(); // List of chat messages associated with the task
    }
}