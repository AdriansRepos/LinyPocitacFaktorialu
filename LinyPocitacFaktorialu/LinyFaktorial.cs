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
                throw new Exception("Neumím záporné čísla, to je na mně moc práce.");
            }
            hodnota = cislo;
        }

        private void AnimacePremysleni()
        {
            int delka = 20;      // délka lišty
            int pozice = 0;      // aktuální pozice světla
            int smer = 1;        // 1 = doprava, -1 = doleva

            for (int t = 0; t < 40; t++) // počet cyklů animace
            {
                Console.Write("\rPřemýšlím: [");

                for (int i = 0; i < delka; i++)
                {
                    if (i == pozice || i == pozice - 1 || i == pozice + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan; // světle modrá
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

                Thread.Sleep(60); // rychlost animace

                // pohyb světla
                pozice += smer;

                if (pozice <= 0 || pozice >= delka - 1)
                    smer *= -1; // změna směru
            }

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
            // Víkendový režim
            if (JeVikend())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je víkend. Dneska fakt ne.");
                Console.ResetColor();
                pocetOdmítnutí++;
                return -1;
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
            if (rng.Next(0, 4) == 0)
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