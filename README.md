# TaskForge

Jednoduchý systém pro evidenci úkolů. Webová aplikace pro firmy na správu úkolů s možností přiřazení řešitelů, checklist položek, příloh a komunikace.

## Funkce
- Správa firem a uživatelů
- Vytváření úkolů s prioritami
- Přiřazování řešitelů k úkolům
- Checklist pro jednotlivé kroky
- Přílohy k úkolům
- Chat komunikace

## Spuštění

### Požadavky
- .NET 8.0 SDK
- VS Code

### Instalace
```bash
# Vytvoř projekt
dotnet new blazorserver -n TaskForge
cd TaskForge

# Přidej balíčky
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Nastav databázi
dotnet ef migrations add InitialCreate
dotnet ef database update

# Spusť aplikaci
dotnet run
```

Otevři prohlížeč na `https://localhost:5001`