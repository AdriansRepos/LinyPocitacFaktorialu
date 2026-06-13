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
                throw new Exception("Neumím záporné čísla, to je moc práce.");

            hodnota = cislo;
        }

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

            // Už to počítal
            if (ulozenyFaktorial.HasValue)
            {
                Console.WriteLine("Už jsem to jednou počítal, tady máš.");
                return ulozenyFaktorial.Value;
            }

            // Animace přemýšlení
            AnimacePremysleni();

            // Dramatická nálada
            if (rng.Next(0, 4) == 0)
                Console.WriteLine("Tohle nezvládnu... ale dobře, zkusím to.");

            int vysledek = 1;

            for (int i = 1; i <= hodnota; i++)
            {
                vysledek *= i;
            }

            ulozenyFaktorial = vysledek;
            pocetVypoctu++;

            Console.WriteLine("No dobře, že jsi to ty, tak jsem ti to spočítal.");
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