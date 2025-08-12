namespace TaskForge.Models
{
    public class Firma
    {
        public int FirmaId { get; set; }
        public string Nazev { get; set; } = string.Empty; //warning musí definované, proto Empty
        public string? Popis { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }

        public List<Uzivatel> Uzivatele { get; set; } = new(); // List of users associated with the company
        public List<Ukol> Ukoly { get; set; } = new(); // List of tasks associated with the company
    }
}