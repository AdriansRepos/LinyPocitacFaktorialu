using LinyPocitacFaktorialu;

string prikaz = "konec";
string vstup;
LinyFaktorial liny = new();

do
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Zadej číslo (nebo raději napiš 'konec', bude to tak lepší pro oba): ");
    Console.ResetColor();

    vstup = Console.ReadLine()!.Trim().ToLower();

    if (vstup == prikaz)
        break;

    if (!int.TryParse(vstup, out int cislo))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Tohle asi není číslo.\n");
        Console.ResetColor();
        continue;
    }

    // === ASYNCHRONNÍ VOLÁNÍ (neblokuje vlákno) ===
    int f = await liny.FaktorialAsync(cislo);

    if (f != -1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{cislo}! = {f}\n");
        Console.ResetColor();
    }

} while (vstup != prikaz);

liny.Statistiky();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\nNo konečně máš dobrý nápad.");
Console.ResetColor();

// Místo Thread.Sleep(3000) uvolníme vlákno:
await Task.Delay(3000);