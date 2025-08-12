namespace TaskForge.Models
{
    public class Priloha
    {
        public int PrilohaId { get; set; }
        public int UkolId { get; set; }
        public string NazevSouboru { get; set; }// = string.Empty;
        public string? Typ { get; set; }
        public int? Velikost { get; set; }  
        public string Cesta { get; set; }// = string.Empty;       
        public int VlozilUzivatelId { get; set; }
        public DateTime VlozenDatum { get; set; }  
        public Ukol Ukol { get; set; } = null!;
        public Uzivatel VlozilUzivatel { get; set; } = null!;
    }
}