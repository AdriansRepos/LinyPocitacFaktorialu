using LinyPocitacFaktorialu;

string prikaz = "konec";
string vstup = "";

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

    LinyFaktorial liny = new LinyFaktorial(cislo);
    int f = liny.Faktorial();

    if (f != -1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{cislo}! = {f}\n");
        Console.ResetColor();
    }

} while (vstup != prikaz);

// Hláška na konec
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\nNo konečně máš dobrý nápad.");
Console.ResetColor();
Thread.Sleep(3000);