using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    class SaveToFile
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        public void Save(string code)
        {
            Console.WriteLine((string)path);
            using StreamWriter file = new($"{path}/KodHTML.txt");
            file.WriteAsync(code);
            Console.WriteLine("Zapisano kod do pliku.");
        }
    }
}
