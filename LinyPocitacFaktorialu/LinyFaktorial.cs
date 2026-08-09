namespace LinyPocitacFaktorialu
{
    class LinyFaktorial
    {
        private readonly Dictionary<int, int> jizSpocitane = [];
        private readonly Random rng = new();

        private int pocetVypoctu = 0;
        private int pocetOdmitnuti = 0;

        // Podle konvencí v C# se asynchronní metody pojmenovávají s příponou "Async"
        public async Task<int> FaktorialAsync(int cislo)
        {
            if (cislo < 0)
            {
                VypisBarevne("Neumím záporné čísla, to je na mně moc práce.", ConsoleColor.Red);
                pocetOdmitnuti++;
                return -1;
            }

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
                return -1;
            }

            // === CEKAME NA ANIMACI ASYNCHRONNĚ ===
            await AnimacePremysleniAsync(cislo);

            int vysledek = SpocitejFaktorial(cislo);
            jizSpocitane[cislo] = vysledek;
            pocetVypoctu++;

            VypisBarevne("No dobře, že jsi to ty, tak jsem ti to spočítal.", ConsoleColor.Green);
            return vysledek;
        }

        private bool ReagujPodleVelikosti(int cislo)
        {
            if (cislo <= 5)
                VypisBarevne("Meh, to dám levou zadní.", ConsoleColor.Yellow);
            else if (cislo <= 15)
                VypisBarevne("Tohle nezvládnu... ale dobře, zkusím to.", ConsoleColor.Yellow);
            else if (cislo <= 30)
                VypisBarevne("Pane bože… to je moc! Jsi normální? Vždyť mi shoří procesor!!! Naposled!", ConsoleColor.Yellow);
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

        // Animace je teď plně asynchronní
        private static async Task AnimacePremysleniAsync(int cislo)
        {
            const int delka = 20;
            int pozice = 0;
            int smer = 1;
            int cykly = Math.Clamp(cislo * 2, 10, 120);

            Console.Write("\u001b[?25l");

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
                
                // === TADY JE TA MAGIE ===
                // Místo Thread.Sleep(60) použijeme uvolňující Task.Delay:
                await Task.Delay(60);

                pozice += smer;
                if (pozice <= 0 || pozice >= delka - 1)
                    smer *= -1;
            }

            Console.Write("\u001b[?25h");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void Statistiky()
        {
            Console.WriteLine($"\nStatistiky línosti:");
            Console.WriteLine($"- Počet výpočtů: {pocetVypoctu}");
            Console.WriteLine($"- Počet odmítnutí: {pocetOdmitnuti}");
        }
    }
}