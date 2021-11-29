using System;
using System.Threading;

namespace Kostki
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            int throwCount = 0;
            byte firnumber, secnumber;

            do
            {
                firnumber = Convert.ToByte(rnd.Next(1, 7));
                secnumber = Convert.ToByte(rnd.Next(1, 7));

                Thread.Sleep(100);
                throwCount = Cubes(firnumber, secnumber, throwCount);
            } while (!IsDoubleSix(firnumber, secnumber));

            Console.WriteLine($"Throw count: {throwCount}");
        }

        static int Cubes(byte _fnumber, byte _snumber, int _count)
        {
            Console.WriteLine($"First dice got: {_fnumber}\nSecond dice got: {_snumber}\n");
            return ++_count;
        }

        static bool IsDoubleSix(byte _fnumber, byte _snumber)
        {
            if (_fnumber == 6 && _snumber == 6) return true;
            else return false;
        }
    }
}
