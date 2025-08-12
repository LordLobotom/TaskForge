namespace TaskForge.Models
{
    public class ChatZprava
    {
        public int ZpravaId { get; set; }
        public int UkolId { get; set; }
        public int UzivatelId { get; set; }
        public DateTime Datum { get; set; }
        public string Text { get; set; } = string.Empty; 
        public Ukol Ukol { get; set; } = null!;
        public Uzivatel Uzivatel { get; set; } = null!;
    }
}