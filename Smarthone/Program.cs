using System;
using System.Collections.Generic;

namespace Smarthone
{
    class Program
    {
        public static List<Smartphone> phone = new();
        private static bool active = true;
        static void Main(string[] args)
        {
            phone.Add(new Smartphone());

            phone[^1].mark = "Samsung";
            phone[^1].model = "Galaxy S99";
            phone[^1].isBatteryOnPlace = true;
            phone[^1].batteryPercentage = 70;
            phone[^1].clientInfo.name = "Mateusz";
            phone[^1].clientInfo.surname = "Tomkowski";
            phone[^1].clientInfo.phoneNumber = 666_555_444;
            phone[^1].value = 1699;

            phone.Add(new Smartphone());

            phone[^1].mark = "Iphone";
            phone[^1].model = "XR";
            phone[^1].isBatteryOnPlace = false;
            phone[^1].batteryPercentage = 0;
            phone[^1].clientInfo.name = "Dorota";
            phone[^1].clientInfo.surname = "Najman";
            phone[^1].clientInfo.phoneNumber = 664_545_454;
            phone[^1].value = 3299;

            do
            {
                Console.WriteLine("Wybierz telefon:");
                foreach (var product in phone)
                {
                    Console.WriteLine($"{product.mark}");
                }
                Console.WriteLine("3.Dodaj smartfon.\nEnter.Wyjście z programu.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        phone[0].ShowParemeters();
                        phone[0].IsCharged70();

                        Console.WriteLine($"Chcesz naładować telefon? Wciśnij ENTER, aby go naładować.");

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Enter:
                                phone[1].Charge();
                                break;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        phone[1].ShowParemeters();
                        phone[1].IsCharged70();

                        Console.WriteLine($"Chcesz naładować telefon? Wciśnij ENTER, aby go naładować.");

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Enter:
                                phone[2].Charge();
                                break;
                        }
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        AddSmartphone();
                        break;
                    case ConsoleKey.Enter:
                        active = false;
                        break;
                }
            } while(active);
        }
        
        public static void AddSmartphone()
        {
            phone.Add(new Smartphone());
            Console.WriteLine("Podaj markę.");
            phone[^1].mark = Console.ReadLine();

            Console.WriteLine("Podaj model.");
            phone[^1].model = Console.ReadLine();

            Console.WriteLine("Podaj informację czy ma baterię.");
            phone[^1].isBatteryOnPlace = bool.Parse(Console.ReadLine());

            Console.WriteLine("Podaj procent naładowania telefonu.");
            phone[^1].batteryPercentage = byte.Parse(Console.ReadLine());

            Console.WriteLine("Podaj imię klienta.");
            phone[^1].clientInfo.name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko klienta.");
            phone[^1].clientInfo.surname = Console.ReadLine();

            Console.WriteLine("Podaj numer telefonu klienta.");
            phone[^1].clientInfo.phoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj wartość telefonu klienta.");
            phone[^1].value = short.Parse(Console.ReadLine());
        }
    }

    class Smartphone
    {
        public string mark { get; set; }
        public string model { get; set; }
        public bool isBatteryOnPlace { get; set; }
        public byte batteryPercentage { get; set; }
        public Client clientInfo = new();
        public short value { get; set; }

        public void ShowParemeters()
        {
            Console.WriteLine($"Dane telefonu klienta {clientInfo.name} {clientInfo.surname}, {clientInfo.phoneNumber}:");
            Console.WriteLine($"Marka: {mark}\nModel: {model}\nCzy posiada baterię: {isBatteryOnPlace}\nPoziom naładowania: {batteryPercentage}%\nSzacunkowa wartość: {value}");
        }

        public void IsCharged70()
        {
            if (batteryPercentage >= 70) Console.WriteLine("Bateria jest naładowana w 70% i wyżej.");
            else Console.WriteLine("Bateria nie jest naładowana w 70%.");
        }

        public void Charge()
        {
            if(batteryPercentage == 100 || isBatteryOnPlace != true)
            {
                Console.WriteLine("Telefon jest w pełni naładowany lub nie ma baterii.");
            }
            else 
            {
                bool correct = false;
                byte batteryCharging = 0;
                do
                {
                    Console.WriteLine("Do ilu procent chcesz naładować baterię?");
                    byte.TryParse(Console.ReadLine(), out batteryCharging);

                    if (batteryCharging != 0) correct = true;
                } while (!correct);

                if(batteryCharging > batteryPercentage)
                {
                    batteryPercentage = batteryCharging;
                    Console.WriteLine($"Bateria została naładowana do {batteryCharging}%.");
                }
                else
                {
                    Console.WriteLine($"Nie można naładować do takiej wartości.");
                }
                
            }
        }
    }

    class Client
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int phoneNumber { get; set; }
    }
} 
