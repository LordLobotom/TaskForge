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
- .NET 9.0 SDK
- VS Code

### Instalace
```bash
# Naklonuj repo
git clone https://github.com/user/TaskForge.git
cd TaskForge

# Nastav databázi
dotnet ef database update

# Spusť aplikaci
dotnet run
```

Otevři prohlížeč na `https://localhost:5001`