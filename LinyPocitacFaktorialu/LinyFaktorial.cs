using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinyPocitacFaktorialu
{
    class LinyFaktorial
    {
        private int hodnota;
        private int? ulozenyFaktorial;
        private Random rng = new Random();

        private int pocetVypoctu = 0;
        private int pocetOdmítnutí = 0;

        public LinyFaktorial(int cislo)
        {
            if (cislo < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Neumím záporné čísla, to je na mně moc práce.");
                Console.ResetColor();

                // nastavíme hodnota na 0, aby se program nezhroutil
                hodnota = -1; // označíme jako neplatné
                return;
            }
            hodnota = cislo;
        }


        private void AnimacePremysleni()
        {
            int delka = 20;
            int pozice = 0;
            int smer = 1;

            // schovat kurzor
            Console.Write("\u001b[?25l");

            // počet cyklů podle čísla
            int cykly = Math.Clamp(hodnota * 2, 10, 120);

            for (int t = 0; t < cykly; t++)
            {
                Console.Write("\rPřemýšlím: [");

                for (int i = 0; i < delka; i++)
                {
                    if (i == pozice || i == pozice - 1 || i == pozice + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("█");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write("░");
                    }
                }

                Console.ResetColor();
                Console.Write("]");

                Thread.Sleep(60);

                pozice += smer;

                if (pozice <= 0 || pozice >= delka - 1)
                    smer *= -1;
            }

            // ukázat kurzor
            Console.Write("\u001b[?25h");

            Console.ResetColor();
            Console.WriteLine();
        }



        private bool JeVikend()
        {
            var dnes = DateTime.Now.DayOfWeek;
            return dnes == DayOfWeek.Saturday || dnes == DayOfWeek.Sunday;
        }

        public int Faktorial()
        {
            // Neplatný vstup (záporné číslo)
            if (hodnota < 0)
            {
                pocetOdmítnutí++;
                return -1;
            }
            // Víkendový režim – 40 % šance odmítnutí
            if (JeVikend())
            {
                if (rng.NextDouble() < 0.40) // 40 % odmítnutí
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je víkend. Dneska fakt ne.");
                    Console.ResetColor();
                    pocetOdmítnutí++;
                    return -1;
                }
            }

            // Únava po 3 výpočtech
            if (pocetVypoctu >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Jsem unavený. Už toho bylo dost.");
                Console.ResetColor();
                pocetOdmítnutí++;
                return -1;
            }

            // Náhodná lenost
            if (rng.Next(0, 5) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dneska se mi nechce.");
                Console.ResetColor();
                pocetOdmítnutí++;
                return -1;
            }

            // Už to počítal
            if (ulozenyFaktorial.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Už jsem to jednou počítal, tady máš.");
                Console.ResetColor();
                return ulozenyFaktorial.Value;
            }

            // Animace přemýšlení
            AnimacePremysleni();

            // Dramatická nálada
            if (rng.Next(0, 3) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tohle nezvládnu... ale dobře, zkusím to.");
                Console.ResetColor();
            }

            int vysledek = 1;

            for (int i = 1; i <= hodnota; i++)
            {
                vysledek *= i;
            }

            ulozenyFaktorial = vysledek;
            pocetVypoctu++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("No dobře, že jsi to ty, tak jsem ti to spočítal.");
            Console.ResetColor();

            return vysledek;
        }

        public void Statistiky()
        {
            Console.WriteLine($"\nStatistiky línosti:");
            Console.WriteLine($"- Počet výpočtů: {pocetVypoctu}");
            Console.WriteLine($"- Počet odmítnutí: {pocetOdmítnutí}");
        }
    }
}