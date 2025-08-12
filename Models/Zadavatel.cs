namespace TaskForge.Models
{
    public class Zadavatel
    {
        public int ZadavatelId { get; set; }
        public int UkolId { get; set; }
        public int UzivatelId { get; set; }      
        public Ukol Ukol { get; set; } = null!;
        public Uzivatel Uzivatel { get; set; } = null!;
    }
}