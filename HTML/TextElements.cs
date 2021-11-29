using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    public abstract class TextElements : BodyElements
    {
        public string Text { get; set; }
    }

    public class Hr : BodyElements
    {
        public static class Messages
        {
            public const string
                HrMessage = "Dodano linię poziomę do kodu.";
        }
        public override string StartOfCode() => "<hr>";
        public override string EndOfCode() => "";
        public override string BaseCode()
        {
            AddToCode(StartOfCode());
            return Render();
        }
    }

    public class Div : BodyElements
    {
        private bool[] activeElement;
        public static class Messages
        {
            public const string
                EntryMessage = "Wybierz opcję, która zostanie wpisana wewnątrz DIV-a:";
        }
        public override string StartOfCode() => "<div>";
        public override string EndOfCode() => "</div>";
        public override string BaseCode()
        {
            AddToCode(EndOfCode());
            return Render();
        }
    }

    public class HGroup : TextElements
    {
        public byte NumberOfGroup { get; set; }
        public static class Messages
        {
            public const string
                EntryGroup = "Podaj wielkość nagłówka [1-6]:",
                EntryText = "Podaj tekst do nagłówka:",
                WrongGroup = "Podano nieprawidłową wartość.";
        }

        public override string StartOfCode() => $"<h{NumberOfGroup}>";
        public override string EndOfCode() => $"</h{NumberOfGroup}>";
        public override string BaseCode()
        {
            byte value;
            do 
            {
                if (!byte.TryParse(Console.ReadLine(), out value)) Console.WriteLine(Messages.WrongGroup);
            } while (value <= 0 || value > 6);

            NumberOfGroup = value;
            Console.WriteLine(HGroup.Messages.EntryText);
            Text = Console.ReadLine();
            AddToCode($"{StartOfCode()}{Text}{EndOfCode()}");
            return Render();
        }
    }

    public class OrderedListElement : BodyElements
    {
        public string[] ListText;
        public static class Messages
        {
            public const string
                EntryText = "Wpisz tekst dla elementu listy OL LI.:",
                Choice = "Wybierz jedną z poniższych opcji:\n1. Dodaj kolejny element listy LI.\nDowolny inny przycisk - Zakończ listę";
        }
        public override string StartOfCode() => $"<ol>";
        public override string EndOfCode() => $"</ol>";
        public override string BaseCode()
        {
            WriteAttributes();
            AddToCode(EndOfCode());
            return Render();
        }

        public StringBuilder WriteAttributes()
        {
            foreach (string x in ListText)
            {
                code.Append($"<li>{x}</li>");
            }
            return code;
        }
    }

    public class ListElement : BodyElements
    {
        public string[] ListText;
        public static class Messages
        {
            public const string
                EntryText = "Wpisz tekst dla elementu listy UL LI.:",
                Choice = "Wybierz jedną z poniższych opcji:\n1. Dodaj kolejny element listy LI.\nDowolny inny przycisk - Zakończ listę";
        }
        public override string StartOfCode() => $"<ul>";
        public override string EndOfCode() => $"</ul>";
        public override string BaseCode()
        {
            WriteAttributes();
            AddToCode(EndOfCode());
            return Render();
        }

        public StringBuilder WriteAttributes()
        {
            foreach (string x in ListText)
            {
                code.Append($"<li>{x}</li>");
            }
            return code;
        }
    }

    public class Paragraph : TextElements
    {
        public override string StartOfCode() => $"<p>";
        public override string EndOfCode() => $"</p>";
        public override string BaseCode()
        {
            Text = Console.ReadLine();
            AddToCode($"{StartOfCode()}{Text}{EndOfCode()}");
            return Render();
        }
    }
}
