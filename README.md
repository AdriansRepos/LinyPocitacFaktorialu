# README – Líný Faktoriál 3.0 (Ultra Fňuk Edition™)

## O projektu

Líný Faktoriál 3.0 je program, který počítá faktoriál…
ale jen když se mu chce.

Je to simulace skutečného života:
někdy makáš, někdy ne, někdy dramatizuješ, někdy máš víkend, někdy se ti prostě nechce.

Program kombinuje:

- faktoriál
- lenost
- nálady
- plně asynchronní animace (`async`/`await`)
- víkendový režim
- únavu
- cache
- dramatické výstupy
- a trochu chaosu

Je to ideální nástroj pro každého, kdo chce spočítat faktoriál, ale zároveň nechce, aby to bylo moc jednoduché.

---

## Jak to funguje

Uživatel zadá číslo.
Program se rozhodne, jestli:
- to spočítá,
- to spočítá, ale bude si stěžovat,
- to odmítne,
- to odmítne, protože je víkend,
- to odmítne, protože už toho má dost,
- to odmítne, protože má špatnou náladu,
- nebo to spočítá, ale jen proto, že jsi to ty.

Je to jako spolupracovat s kolegou, který má pondělí každý den.

---

## Funkce a vlastnosti

### Asynchronní fňukání (`async`/`await`)
Program při čekání a přemýšlení **neblokuje vlákno procesoru**. 
Používá `await Task.Delay()`, takže i když natahuje čas a předstírá práci, 
spotřebovává přesně **0 % CPU**. Lenoší efektivně!

### Lenost (20 % šance)
Program prostě řekne:
„Dneska se mi nechce.“

### Víkendový režim
V sobotu a neděli nepracuje nikdy.
Ani kdybys ho prosil.

### Únava
Po třech výpočtech už má dost a odmítá dál pracovat.

### Animace přemýšlení
Vypadá to, jako že fakt maká.
Ve skutečnosti jen asynchronně natahuje čas.

### Dramatické hlášky
Občas zahlásí něco jako:
„Tohle nezvládnu… ale dobře, zkusím to.“

### Cache
Program si pamatuje výsledek pro každé číslo, které už jednou spočítal – ne jen pro to poslední.
Když zadáš číslo, které už řešil dřív (třeba i o pět pokusů zpátky), prostě ti řekne:
„Už jsem to jednou počítal, tady máš.“
A ani se nenamáhá to počítat znovu. Protože proč by měl.

### Statistiky línosti
Počítá, kolikrát odmítl a kolikrát se překonal.

---

## Ovládání

- Spusť program.
- Zadej číslo.
- Doufej, že se mu chce.
- Pokud ne, zkus to znovu.
- Pokud tě to přestane bavit, napiš `konec`.

Na konci program vypíše:
„No konečně máš dobrý nápad.“  
A dá ti asynchronní 3 sekundy na zamyšlení nad životem.

---
## Ukázka kódu

```csharp
// Asynchronní přemýšlení - uvolňuje vlákno procesoru
private static async Task AnimacePremysleniAsync(int cislo)
{
    int cykly = Math.Clamp(cislo * 2, 10, 120);
    Console.Write("\u001b[?25l"); // schovat kurzor

    for (int t = 0; t < cykly; t++)
    {
        // ... vykreslení animace ...
        
        // Žádný blokující Thread.Sleep! Pěkně asynchronní uvolnění vlákna:
        await Task.Delay(60); 
    }

    Console.Write("\u001b[?25h"); // ukázat kurzor
}

public async Task<int> FaktorialAsync(int cislo)
{
    // Únava po 3 výpočtech
    if (pocetVypoctu >= 3)
    {
        VypisBarevne("Jsem unavený. Už toho bylo dost.", ConsoleColor.Red);
        pocetOdmitnuti++;
        return -1;
    }

    // Spuštění asynchronní animace
    await AnimacePremysleniAsync(cislo);

    int vysledek = SpocitejFaktorial(cislo);
    jizSpocitane[cislo] = vysledek;
    pocetVypoctu++;

    return vysledek;
}
```
---

## Ukázka chování

Ukázka chování
Zadej číslo: 5
Přemýšlím: [████░░░░░░░░░░░░░░░░]
No dobře, že jsi to ty, tak jsem ti to spočítal.
5! = 120

### Nebo taky:
Zadej číslo: 7
Dneska se mi nechce.

### A nebo:
Zadej číslo: 10
Je víkend. Dneska fakt ne.

### A moje oblíbená:
Zadej číslo: 4
Tohle nezvládnu... ale dobře, zkusím to.
No dobře, že jsi to ty, tak jsem ti to spočítal.

---

## Kdy program odmítne pracovat

- je víkend
- je unavený
- má špatnou náladu
- nechce se mu
- už to jednou počítal
- nebo prostě jen tak

---

## Proč to existuje

Protože faktoriál je nudný.
Ale líný, asynchronní faktoriál?
To je umění moderního programování.

---

## Licence

Projekt je licencován pod FňukLicense 1.0:

- „Můžeš to používat, ale nesmíš se divit, když to nebude fungovat.“

---

## Release

**v1.0.0** – První verze. Líný faktoriál s víkendovým režimem, únavou, náladami, dramatickými hláškami, cache a počítadlem odmítnutí/výpočtů.  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.0.0)

**v1.1.0** – Přidána animace přemýšlení a barevné rozlišení hlášek podle typu (odmítnutí, úspěch, remcání).  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.1.0)

**v1.2.0** – Víkendové odmítnutí nově jen s 40% pravděpodobností místo jistoty. Opravena chyba, kdy zadání záporného čísla shazovalo aplikaci. Opravena duplicitní hláška zobrazovaná dvakrát při záporném čísle.  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.2.0)

**v1.3.0** – Animace přemýšlení nyní trvá déle u větších čísel. Kurzor se během přemýšlení schová a po dokončení se opět zobrazí.  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.3.0)

**v1.4.0** – Přidáno remcání při zadání velkého čísla. Čísla nad 31 mají 50% šanci na úplné odmítnutí výpočtu.  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.4.0)

**v1.5.0** – `LinyFaktorial` nyní žije jako jedna instance po celou dobu běhu programu místo vytváření nové instance pro každé zadané číslo – únava a nálada se tak počítají napříč všemi čísly, ne jen pro poslední zadané. Cache rozšířena z jedné uložené hodnoty na `Dictionary<int, int>`, takže si program pamatuje výsledky pro každé dříve zadané číslo zvlášť, ne jen pro to poslední.  
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v1.5.0)

**v2.0.0** – Asynchronní revoluce (async/await). Blokující příkazy Thread.Sleep nahrazeny asynchronním Task.Delay. Aplikace uvolňuje vlákno procesoru během fňukání a animací – spotřebovává 0 % CPU, když nic nedělá. Přidán posuvník (progress bar) animace v konzoli.
[Stáhnout zde](https://github.com/AdriansRepos/LinyPocitacFaktorialu/releases/tag/v2.0.0)