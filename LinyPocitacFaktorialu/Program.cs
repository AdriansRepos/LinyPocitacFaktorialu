using LinyPocitacFaktorialu;

string prikaz = "konec";
string vstup = "";

do
{
    Console.Write("Zadej číslo (nebo raději napiš 'konec', bude to tak lepší pro oba): ");
    vstup = Console.ReadLine()!.Trim().ToLower();

    if (vstup == prikaz)
        break;

    if (!int.TryParse(vstup, out int cislo))
    {
        Console.WriteLine("Tohle asi není číslo.\n");
        continue;
    }

    LinyFaktorial liny = new LinyFaktorial(cislo);
    int f = liny.Faktorial();

    if (f != -1)
        Console.WriteLine($"{cislo}! = {f}\n");

} while (vstup != prikaz);

// Hláška na konec
Console.WriteLine("\nNo konečně máš dobrý nápad.");
Thread.Sleep(3000);