using System;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal baseSalary = 0;
            decimal overtime = 0;
            string written;
            bool active = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Kalkulator wynagrodzeń");

                do
                {
                    Console.WriteLine("Podaj swoją kwotę bazową:");
                    written = Console.ReadLine();
                    decimal.TryParse(written, out baseSalary); //baseSalary = Convert.ToDecimal(written);
                } while (baseSalary == 0);

                do
                {
                    Console.WriteLine("Podaj ile przepracowałeś/przepracowałaś nadgodzin:");
                    written = Console.ReadLine();
                    decimal.TryParse(written, out overtime); //overtime = Convert.ToDecimal(written);
                } while (overtime == 0);

                Console.WriteLine($"Twoje wynagrodzenie za bieżący miesiąc wynosi: {FinalSalary(baseSalary, overtime)}");
                Console.WriteLine("Kontynuować? Wciśnij T, aby przeliczyć następne wynagroczenie.");

                if (Console.ReadLine() != "t") active = false;

            } while (active);
        }

        static decimal FinalSalary(decimal salary, decimal overtime)
        {
            return salary + (overtime * 50);
        }
    }
}
