namespace TaskForge.Models
{
    public class Zadatel
    {
        public int ZadatelId { get; set; }
        public int UkolId { get; set; }
        public int UzivatelId { get; set; }      
        public Ukol Ukol { get; set; } = null!;
        public Uzivatel Uzivatel { get; set; } = null!;
    }
}