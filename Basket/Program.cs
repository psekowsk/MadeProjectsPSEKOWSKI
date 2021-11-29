using System;
using System.Collections.Generic;

namespace Basket
{
    class Program
    {
        private static List<string> basket = new List<string>();
        public static string[] products = { "Iphone", "Samsung_Galaxy", "Xiaomi", "OnePlus", "Oppo" };
        private static bool active = true;

        static void Main(string[] args)
        {
            do
            {
                MainMenu();
            } while (active);
        }

        static void MainMenu()
        {
            Console.WriteLine("Katalog produktów:");
            WriteProducts();
            WriteInstructions();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddProduct();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    RemoveProduct();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    basket.Clear();
                    Console.Clear();
                    Console.WriteLine("Wyczysczono koszyk.\n");
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ShowBasket();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    active = false;
                    break;
            }
        }

        static void RemoveProduct()
        {
            Console.WriteLine($"Wpisz nazwę produktu:");
            string userProduct = Console.ReadLine();
            Console.Clear();

            basket.RemoveAll(p => p.Contains(userProduct));

            Console.WriteLine($"Usunięto wszystkie produkty o nazwie {userProduct}");
        }

        static void AddProduct()
        {
            Console.WriteLine($"Wpisz nazwę produktu:");
            string userProduct = Console.ReadLine();
            Console.Clear();
            bool added = false;

            foreach (string name in products)
            {
                if (userProduct == name)
                {
                    basket.Add(userProduct);
                    added = true;
                }
            }

            if (added) Console.WriteLine($"Dodano produkt o nazwie {userProduct}.");
            else Console.WriteLine($"Podano nieprawidłową nazwę.");
        }
        
        static void ShowBasket()
        {
            Console.Clear();
            Console.WriteLine("Twój Koszyk:");
            Byte Index = 1;

            foreach (string product in basket)
            {
                Console.WriteLine($"{Index}. {product}");
            }
            Console.WriteLine("Naciśnij dowolny przycisk, aby wrócić do menu głównego.");
            Console.ReadKey();
        }

        static void WriteProducts()
        {
            Byte Index = 1;
            foreach (string name in products)
            {
                Console.WriteLine($"{Index++}. {name}");
            }
        }

        static void WriteInstructions()
        {
            Console.WriteLine("Wciśnij odpowiedni klawisz w zależności od akcji, którą chcesz wykonać:");
            Console.WriteLine("1. Dodaj produkt do koszyka.");
            Console.WriteLine("2. Usuń produkt z koszyka.");
            Console.WriteLine("3. Usuń wszystkie produkty z koszyka.");
            Console.WriteLine("4. Pokaż koszyk.");
            Console.WriteLine("5. Wyjdź z programu.");
        }
    }
}
