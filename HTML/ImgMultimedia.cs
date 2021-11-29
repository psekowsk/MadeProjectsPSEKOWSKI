using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    public class Image : Attributes
    {
        public string Alternate { get; set; }
        public static class Messages
        {
            public const string
                EntrySource = "Wpisz ściężkę do pliku:",
                EntryAlt = "Wpisz tekst, który będzie się wyświetlać po najechaniu kursorem na zdjęcie:";
        }

        public override string StartOfCode() => "<img";
        public override string EndOfCode() => "/>";
        public override string BaseCode()
        {
            Console.WriteLine(Messages.EntrySource);
            Source = Console.ReadLine();

            Console.WriteLine(Messages.EntryAlt);
            Alternate = Console.ReadLine();

            AddToCode($"{StartOfCode()} src='{Source}' alt='{Alternate}' {EndOfCode()}");
            return Render();
        }
    }

    public class Audio : Attributes
    {
        public Audio()
        {
            AvailableAttributes.Add("autoplay");
            AvailableAttributes.Add("controls");
            AvailableAttributesWithValues.Add("crossorigin");
            AvailableAttributes.Add("disableremoteplayback");
            AvailableAttributes.Add("loop");
            AvailableAttributes.Add("muted");
            AvailableAttributesWithValues.Add("preload");
        }

        public static class Messages
        {
            public const string
                EntrySource = "Wpisz ściężkę do pliku:",
                EntryAtt = "Wpisz atrybut dla AUDIO:",
                EntryValue = "Podany atrybut wymaga dodatkowej wartości. Wpisz wartość atrybutu:";
        }

        public override string StartOfCode() => "<audio ";
        public override string EndOfCode() => "/>";
        public override string BaseCode()
        {
            Console.WriteLine(Messages.EntrySource);
            Source = Console.ReadLine();

            Console.WriteLine(Messages.EntryAtt);
            string UserAttribute = Console.ReadLine();

            if (CheckAttributes(UserAttribute)) ChosenAttributes[^1] = UserAttribute;
            if (CheckAttributesWithValue(UserAttribute))
            {
                Console.WriteLine(Messages.EntryValue);
                ChosenAttributes[^1] = $"{UserAttribute}='{Console.ReadLine()};'";
            }

            AddToCode($"{StartOfCode()} src='{Source}' {WriteAttributes()}{EndOfCode()}");
            return Render();
        }
    }

    public class Track : Attributes
    {
        public string VideoSource;

        public Track()
        {
            AvailableAttributes.Add("default");
            AvailableAttributesWithValues.Add("kind");
            AvailableAttributes.Add("label");
            AvailableAttributesWithValues.Add("srclang");
        }

        public static class Messages
        {
            public const string
                EntryVideoSource = "Wpisz ścieżkę do pliku filmowego: ",
                EntrySource = "Wpisz ścieżkę do pliku audio:",
                EntryAtt = "Wpisz atrybut dla TRACK:",
                EntryValue = "Podany atrybut wymaga dodatkowej wartości. Wpisz wartość atrybutu:";
        }

        public override string StartOfCode() => $"<video controls src='{VideoSource}'";
        public override string EndOfCode() => $"</video>";
        public override string BaseCode()
        {
            Console.WriteLine(Messages.EntryVideoSource);
            VideoSource = Console.ReadLine();

            Console.WriteLine(Messages.EntrySource);
            Source = Console.ReadLine();

            Console.WriteLine(Messages.EntryAtt);
            string UserAttribute = Console.ReadLine();

            if (CheckAttributes(UserAttribute)) ChosenAttributes[^1] = UserAttribute;
            if (CheckAttributesWithValue(UserAttribute))
            {
                Console.WriteLine(Messages.EntryValue);
                ChosenAttributes[^1] = $"{UserAttribute}='{Console.ReadLine()};'";
            }

            AddToCode($"{StartOfCode()}\n<track src='{Source}' {WriteAttributes()} />\n{EndOfCode()}");
            return Render();
        }
    }
    
    public class Video : Attributes
    {
        public Video()
        {
            AvailableAttributes.Add("autoplay");
            AvailableAttributes.Add("autopictureinpicture");
            AvailableAttributes.Add("controls");
            AvailableAttributesWithValues.Add("controlslist");
            AvailableAttributesWithValues.Add("crossorigin");
            AvailableAttributes.Add("disablepictureinpicture");
            AvailableAttributes.Add("disableremoteplayback");
            AvailableAttributesWithValues.Add("height");
            AvailableAttributes.Add("loop");
            AvailableAttributesWithValues.Add("muted");
            AvailableAttributes.Add("playsinline");
            AvailableAttributes.Add("poster");
            AvailableAttributesWithValues.Add("preload");
            AvailableAttributesWithValues.Add("width");
        }
        public static class Messages
        {
            public const string
                EntrySource = "Wpisz ścieżkę do pliku video:",
                EntryAtt = "Wpisz atrybut dla VIDEO:",
                EntryValue = "Podany atrybut wymaga dodatkowej wartości. Wpisz wartość atrybutu:";
        }

        public override string StartOfCode() => "<video ";
        public override string EndOfCode() => "</video>";
        public override string BaseCode()
        {
            Console.WriteLine(Messages.EntrySource);
            Source = Console.ReadLine();

            Console.WriteLine(Messages.EntryAtt);
            string UserAttribute = Console.ReadLine();

            if (CheckAttributes(UserAttribute)) ChosenAttributes[^1] = UserAttribute;
            if (CheckAttributesWithValue(UserAttribute))
            {
                Console.WriteLine(Messages.EntryValue);
                ChosenAttributes[^1] = $"{UserAttribute}='{Console.ReadLine()};'";
            }

            AddToCode($"{StartOfCode()}{WriteAttributes()} >\n<source src='{Source}'>\n{EndOfCode()}");
            return Render();
        }
    }
}
