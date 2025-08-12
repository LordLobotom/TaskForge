namespace TaskForge.Models
{
    public class ChecklistPolozka
    {
        public int PolozkaId { get; set; }
        public int UkolId { get; set; }
        public string Nazev { get; set; } = string.Empty;
        public string? Poznamka { get; set; }
        public int Stav { get; set; } = 0;
        public DateTime? Termin { get; set; }
        public DateTime? DatumSplneni { get; set; }
        public int Priorita { get; set; } = 0;
        public int VlozilUzivatelId { get; set; }
        public DateTime VlozenDatum { get; set; }       
        public Ukol Ukol { get; set; } = null!;
        public Uzivatel VlozilUzivatel { get; set; } = null!;
    }
}