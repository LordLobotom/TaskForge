using Microsoft.EntityFrameworkCore;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Data
{
    public static class SeedData
    {
        public static void Initialize(TaskForgeDbContext context)
        {
            context.Database.EnsureCreated();

            // Pokud už existují data, neděláme nic
            if (context.Firmy.Any())
            {
                return;
            }

            // Vytvoření firem
            var firmy = new Firma[]
            {
                new Firma
                {
                    Nazev = "TechCorp s.r.o.",
                    Popis = "Technologická společnost zaměřená na vývoj software",
                    Adresa = "Praha 1, Wenceslas Square 1",
                    Telefon = "+420 123 456 789"
                },
                new Firma
                {
                    Nazev = "DesignStudio Ltd.",
                    Popis = "Kreativní studio pro grafický design",
                    Adresa = "Brno, Malinovského nám. 2",
                    Telefon = "+420 987 654 321"
                },
                new Firma
                {
                    Nazev = "ConsultPro",
                    Popis = "Poradenská společnost",
                    Adresa = "Ostrava, Nová karolina 3",
                    Telefon = "+420 555 123 456"
                }
            };

            context.Firmy.AddRange(firmy);
            context.SaveChanges();

            // Vytvoření uživatelů
            var uzivatele = new Uzivatel[]
            {
                new Uzivatel
                {
                    Jmeno = "Jan Novák",
                    FirmaId = firmy[0].FirmaId,
                    Email = "jan.novak@techcorp.cz"
                },
                new Uzivatel
                {
                    Jmeno = "Marie Svobodová",
                    FirmaId = firmy[0].FirmaId,
                    Email = "marie.svobodova@techcorp.cz"
                },
                new Uzivatel
                {
                    Jmeno = "Petr Dvořák",
                    FirmaId = firmy[1].FirmaId,
                    Email = "petr.dvorak@designstudio.cz"
                },
                new Uzivatel
                {
                    Jmeno = "Anna Černá",
                    FirmaId = firmy[1].FirmaId,
                    Email = "anna.cerna@designstudio.cz"
                },
                new Uzivatel
                {
                    Jmeno = "Pavel Novotný",
                    FirmaId = firmy[2].FirmaId,
                    Email = "pavel.novotny@consultpro.cz"
                }
            };

            context.Uzivatele.AddRange(uzivatele);
            context.SaveChanges();

            // Vytvoření úkolů
            var ukoly = new Ukol[]
            {
                new Ukol
                {
                    FirmaId = firmy[0].FirmaId,
                    Popis = "Implementace nového modulu pro správu uživatelů",
                    Detail = "Vytvořit kompletní CRUD operace pro správu uživatelů včetně autentifikace a autorizace. Použít Entity Framework Core a implementovat API endpointy.",
                    DatumZadani = DateTime.Now.AddDays(-5),
                    Priorita = "Vysoká",
                    Stav = "V řešení",
                    TerminVyreseni = DateTime.Now.AddDays(10),
                    VlozilUzivatelId = uzivatele[0].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-5)
                },
                new Ukol
                {
                    FirmaId = firmy[0].FirmaId,
                    Popis = "Oprava chyby v reportování",
                    Detail = "Při generování měsíčních reportů dochází k chybě při výpočtu součtů. Nutné identifikovat a opravit.",
                    DatumZadani = DateTime.Now.AddDays(-3),
                    Priorita = "Kritická",
                    Stav = "Nový",
                    TerminVyreseni = DateTime.Now.AddDays(2),
                    VlozilUzivatelId = uzivatele[1].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-3)
                },
                new Ukol
                {
                    FirmaId = firmy[1].FirmaId,
                    Popis = "Design nového loga pro klienta",
                    Detail = "Vytvořit 3 varianty loga pro společnost XYZ včetně barevných variant a aplikací na různé materiály.",
                    DatumZadani = DateTime.Now.AddDays(-7),
                    Priorita = "Střední",
                    Stav = "Dokončeno",
                    TerminVyreseni = DateTime.Now.AddDays(-1),
                    DatumUzavreni = DateTime.Now.AddDays(-1),
                    VlozilUzivatelId = uzivatele[2].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-7)
                },
                new Ukol
                {
                    FirmaId = firmy[1].FirmaId,
                    Popis = "Příprava prezentace pro klienta",
                    Detail = "Vytvořit PowerPoint prezentaci s návrhy reklamní kampaně včetně mockupů a cenové kalkulace.",
                    DatumZadani = DateTime.Now.AddDays(-2),
                    Priorita = "Vysoká",
                    Stav = "V řešení",
                    TerminVyreseni = DateTime.Now.AddDays(3),
                    VlozilUzivatelId = uzivatele[3].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-2)
                },
                new Ukol
                {
                    FirmaId = firmy[2].FirmaId,
                    Popis = "Analýza trhu pro nový produkt",
                    Detail = "Provést důkladnou analýzu konkurence a tržního potenciálu pro nový produkt klienta. Vytvořit detailní report s doporučeními.",
                    DatumZadani = DateTime.Now.AddDays(-10),
                    Priorita = "Střední",
                    Stav = "V řešení",
                    TerminVyreseni = DateTime.Now.AddDays(5),
                    VlozilUzivatelId = uzivatele[4].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-10)
                },
                new Ukol
                {
                    FirmaId = firmy[3].FirmaId, // Osobní úkol
                    Popis = "Aktualizace dokumentace API",
                    Detail = "Aktualizovat Swagger dokumentaci pro všechny API endpointy a přidat příklady použití.",
                    DatumZadani = DateTime.Now.AddDays(-1),
                    Priorita = "Nízká",
                    Stav = "Nový",
                    TerminVyreseni = DateTime.Now.AddDays(14),
                    VlozilUzivatelId = uzivatele[0].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-1)
                }
            };

            context.Ukoly.AddRange(ukoly);
            context.SaveChanges();

            // Přiřazení zadavatelů a řešitelů
            var zadatele = new Zadatel[]
            {
                new Zadatel { UkolId = ukoly[0].UkolId, UzivatelId = uzivatele[0].UzivatelId },
                new Zadatel { UkolId = ukoly[1].UkolId, UzivatelId = uzivatele[1].UzivatelId },
                new Zadatel { UkolId = ukoly[2].UkolId, UzivatelId = uzivatele[2].UzivatelId },
                new Zadatel { UkolId = ukoly[3].UkolId, UzivatelId = uzivatele[3].UzivatelId },
                new Zadatel { UkolId = ukoly[4].UkolId, UzivatelId = uzivatele[4].UzivatelId },
                new Zadatel { UkolId = ukoly[5].UkolId, UzivatelId = uzivatele[0].UzivatelId }
            };

            var resitele = new Resitel[]
            {
                new Resitel { UkolId = ukoly[0].UkolId, UzivatelId = uzivatele[1].UzivatelId },
                new Resitel { UkolId = ukoly[1].UkolId, UzivatelId = uzivatele[0].UzivatelId },
                new Resitel { UkolId = ukoly[2].UkolId, UzivatelId = uzivatele[3].UzivatelId },
                new Resitel { UkolId = ukoly[3].UkolId, UzivatelId = uzivatele[2].UzivatelId },
                new Resitel { UkolId = ukoly[4].UkolId, UzivatelId = uzivatele[4].UzivatelId },
                new Resitel { UkolId = ukoly[5].UkolId, UzivatelId = uzivatele[1].UzivatelId }
            };

            context.Zadatele.AddRange(zadatele);
            context.Resitele.AddRange(resitele);
            context.SaveChanges();

            // Přidání některých checklistových položek
            var checklistPolozky = new ChecklistPolozka[]
            {
                new ChecklistPolozka
                {
                    UkolId = ukoly[0].UkolId,
                    Nazev = "Návrh databázového schématu",
                    Popis = "Vytvořit ER diagram a SQL skripty",
                    Stav = 1, // dokončeno
                    Priorita = 1,
                    VlozilUzivatelId = uzivatele[0].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-4),
                    DatumSplneni = DateTime.Now.AddDays(-3)
                },
                new ChecklistPolozka
                {
                    UkolId = ukoly[0].UkolId,
                    Nazev = "Implementace API endpointů",
                    Popis = "CRUD operace pro uživatele",
                    Stav = 0, // nedokončeno
                    Priorita = 2,
                    Termin = DateTime.Now.AddDays(5),
                    VlozilUzivatelId = uzivatele[0].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-4)
                },
                new ChecklistPolozka
                {
                    UkolId = ukoly[3].UkolId,
                    Nazev = "Výběr šablon a barev",
                    Popis = "Definovat barevné schéma prezentace",
                    Stav = 1,
                    Priorita = 1,
                    VlozilUzivatelId = uzivatele[3].UzivatelId,
                    VlozenDatum = DateTime.Now.AddDays(-1),
                    DatumSplneni = DateTime.Now.AddDays(-1)
                }
            };

            context.ChecklistPolozky.AddRange(checklistPolozky);
            context.SaveChanges();
        }
    }
}