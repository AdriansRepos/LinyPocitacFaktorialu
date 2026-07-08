using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinyPocitacFaktorialu
{
    /// <summary>
    /// Simuluje "líného" pracovníka, který počítá faktoriály.
    /// Odmlouvá, unaví se po několika výpočtech a pamatuje si
    /// už jednou spočítané hodnoty.
    /// </summary>
    class LinyFaktorial
    {
        private readonly Dictionary<int, int> jizSpocitane = [];
        private readonly Random rng = new();

        private int pocetVypoctu = 0;
        private int pocetOdmitnuti = 0;

        /// <summary>
        /// Spočítá faktoriál zadaného čísla. Podle nálady a historie
        /// předchozích výpočtů může odmítnout, otálet, nebo použít
        /// dříve uložený výsledek.
        /// </summary>
        /// <param name="cislo">Číslo, jehož faktoriál se má spočítat.</param>
        /// <returns>Výsledný faktoriál, nebo -1 při odmítnutí/neplatném vstupu.</returns>
        public int Faktorial(int cislo)
        {
            if (cislo < 0)
            {
                VypisBarevne("Neumím záporné čísla, to je na mně moc práce.", ConsoleColor.Red);
                pocetOdmitnuti++;
                return -1;
            }

            // Už tohle číslo počítal dřív
            if (jizSpocitane.TryGetValue(cislo, out int ulozenyVysledek))
            {
                VypisBarevne("Už jsem to jednou počítal, tady máš.", ConsoleColor.Yellow);
                return ulozenyVysledek;
            }

            if (JeVikend() && rng.NextDouble() < 0.40)
            {
                VypisBarevne("Je víkend. Dneska fakt ne.", ConsoleColor.Red);
                pocetOdmitnuti++;
                return -1;
            }

            if (pocetVypoctu >= 3)
            {
                VypisBarevne("Jsem unavený. Už toho bylo dost.", ConsoleColor.Red);
                pocetOdmitnuti++;
                return -1;
            }

            if (rng.Next(0, 5) == 0)
            {
                VypisBarevne("Dneska se mi nechce.", ConsoleColor.Red);
                pocetOdmitnuti++;
                return -1;
            }

            if (!ReagujPodleVelikosti(cislo))
            {
                pocetOdmitnuti++;
                return -1; // odmítl kvůli velikosti čísla
            }

            AnimacePremysleni(cislo);

            int vysledek = SpocitejFaktorial(cislo);
            jizSpocitane[cislo] = vysledek;
            pocetVypoctu++;

            VypisBarevne("No dobře, že jsi to ty, tak jsem ti to spočítal.", ConsoleColor.Green);
            return vysledek;
        }

        /// <summary>
        /// Zobrazí náladovou hlášku podle velikosti čísla.
        /// U velmi velkých čísel má 50% šanci výpočet rovnou odmítnout.
        /// </summary>
        /// <returns>False, pokud výpočet odmítá kvůli velikosti čísla.</returns>
        private bool ReagujPodleVelikosti(int cislo)
        {
            if (cislo <= 5)
            {
                VypisBarevne("Meh, to dám levou zadní.", ConsoleColor.Yellow);
            }
            else if (cislo <= 15)
            {
                VypisBarevne("Tohle nezvládnu... ale dobře, zkusím to.", ConsoleColor.Yellow);
            }
            else if (cislo <= 30)
            {
                VypisBarevne("Pane bože… to je moc! Jsi normální? Vždyť mi shoří procesor!!! Naposled!", ConsoleColor.Yellow);
            }
            else
            {
                if (rng.NextDouble() < 0.50)
                {
                    VypisBarevne("Tohle počítat nebudu!!!", ConsoleColor.Yellow);
                    return false;
                }
                VypisBarevne("Pane bože… to je obří číslo! Ale dobře… snad to dám...", ConsoleColor.Yellow);
            }

            return true;
        }

        private static int SpocitejFaktorial(int cislo)
        {
            int vysledek = 1;
            for (int i = 1; i <= cislo; i++)
                vysledek *= i;
            return vysledek;
        }

        private static bool JeVikend()
        {
            var dnes = DateTime.Now.DayOfWeek;
            return dnes == DayOfWeek.Saturday || dnes == DayOfWeek.Sunday;
        }

        private static void VypisBarevne(string text, ConsoleColor barva)
        {
            Console.ForegroundColor = barva;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Animace "přemýšlení" – pohybující se blok v konzoli.
        /// Délka animace roste s velikostí zadaného čísla.
        /// </summary>
        private static void AnimacePremysleni(int cislo)
        {
            const int delka = 20;
            int pozice = 0;
            int smer = 1;
            int cykly = Math.Clamp(cislo * 2, 10, 120);

            Console.Write("\u001b[?25l"); // schovat kurzor

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

            Console.Write("\u001b[?25h"); // ukázat kurzor
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Vypíše statistiky línosti za celý běh programu.
        /// </summary>
        public void Statistiky()
        {
            Console.WriteLine($"\nStatistiky línosti:");
            Console.WriteLine($"- Počet výpočtů: {pocetVypoctu}");
            Console.WriteLine($"- Počet odmítnutí: {pocetOdmitnuti}");
        }
    }
}