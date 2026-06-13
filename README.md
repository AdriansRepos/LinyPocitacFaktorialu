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
- animace
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
Ve skutečnosti jen natahuje čas.

### Dramatické hlášky
Občas zahlásí něco jako:
„Tohle nezvládnu… ale dobře, zkusím to.“

### Cache
Když už to jednou spočítal, tak to znovu dělat nebude.
Protože proč by měl.

### Statistiky línosti
Počítá, kolikrát odmítl a kolikrát se překonal.

---

## Ovládání

- Spusť program.
- Zadej číslo.
- Doufej, že se mu chce.
- Pokud ne, zkus to znovu.
- Pokud tě to přestane bavit, napiš konec.

Na konci program vypíše:
„No konečně máš dobrý nápad.“  
A dá ti 3 sekundy na zamyšlení nad životem.

---
## Ukázka kódu

```csharp
private void AnimacePremysleni()
{
    string[] anim = { ".", "..", "...", "...." };
    foreach (var a in anim)
    {
        Console.Write($"\rPřemýšlím{a}");
        Thread.Sleep(1000);
    }
    Console.Write("\r                \r");
}

private bool JeVikend()
{
    var dnes = DateTime.Now.DayOfWeek;
    return dnes == DayOfWeek.Saturday || dnes == DayOfWeek.Sunday;
}

public int Faktorial()
{
    // Víkendový režim
    if (JeVikend())
    {
        Console.WriteLine("Je víkend. Dneska fakt ne.");
        pocetOdmítnutí++;
        return -1;
    }

    // Únava po 3 výpočtech
    if (pocetVypoctu >= 3)
    {
        Console.WriteLine("Jsem unavený. Už toho bylo dost.");
        pocetOdmítnutí++;
        return -1;
    }

    // Náhodná lenost
    if (rng.Next(0, 5) == 0)
    {
        Console.WriteLine("Dneska se mi nechce.");
        pocetOdmítnutí++;
        return -1;
    }
```
---

## Ukázka chování

Zadej číslo: 5
Přemýšlím...
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
Ale líný faktoriál?
To je umění.

---

## Licence

Projekt je licencován pod FňukLicense 1.0:

- „Můžeš to používat, ale nesmíš se divit, když to nebude fungovat.“

---

## Bonus: Co všechno verze 1.0.0 obsahuje

- víkendový režim
- únava
- nálady
- dramatické výstupy
- cache
- počítadlo odmítnutí
- počítadlo výpočtů
- sarkasmus
- pasivní agresivita
- a hlavně: lenost

## Verze 1.1.0 obsahuje navíc
- animace přemýšlení
- barevné hlášky podle typu

## Verze 1.2.0
- opraveno víkendové počítání na náhodnost 40% odmítnutí počítání o víkendu
- opravena chyba, kdy po zadání záporného čísla aplikace už nepadá
- oprava chyby, kde při záporném čísle program vypisoval dvě hlášky místo jedné

## Verze 1.3.0
- dopracovaný cyklus animace přemýšlení - čím větší císlo, tím déle přemýšlí
- při přemýšlení se schová kurzor, po dokončení přemýšlení se zjeví

## Verze 1.4.0
- přidáno remcání na velké čísla
- při číslech nad 31 je 50% sance odmítnutí výpočtu faktoriálu