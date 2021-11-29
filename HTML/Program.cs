using System;

namespace HTML
{
    class Program
    {
        private static bool active = true;
        private static HeadBuilder head = new();
        private static BodyBuilder body = new();
        private static string entireCode;
        private static SaveToFile save = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Witaj kreatorze kodu HTML! Program stworzy na początku sekcję HEAD, gdzie możesz skonfigurować plik ze stylami CSS, tytuł strony lub określić system.");
            head.HeadConfigure();

            Console.WriteLine("Program stworzy teraz sekcję BODY dla pozostałej części strony. Możesz teraz dodać treść, obrazki, nagłówki itd.");
            body.BodyConfigure();
            head.EntireCodeEnd();

            Console.WriteLine("Dziękujemy za skorzystanie z programu. Poniżej wyświetli się stworzony kod strony internetowej.\n\n");
            Console.WriteLine($"{head.HeadWrite()}{head.EntireCodeEnd()}");

            do
            {
                Console.WriteLine("Wybierz jedną z poniższych opcji:");
                Console.WriteLine("1. Zmień elementy z sekcji HEAD.");
                Console.WriteLine("2. Zmień elementy z sekcji BODY.");
                Console.WriteLine("3. Wyświetl kod.");
                Console.WriteLine("4. Zapisz do pliku.");
                Console.WriteLine("5. Zakończ działanie programu.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        head.ChangeHead();
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        body.ElementsInBody();
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine(head.HeadWrite());
                        Console.WriteLine(body.BodyWrite());
                        Console.WriteLine(head.EntireCodeEnd());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        entireCode = $"{head.HeadWrite()}\n{body.BodyWrite()}\n{head.EntireCodeEnd()}";
                        save.Save(entireCode);
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        active = false;
                        break;
                }
            } while (active);
        }
    }

    class HeadBuilder
    {
        private HeadBase headCode = new();
        private HeadTitle hTitle = new();
        private HeadLink hLink = new();
        private HeadMeta hMeta = new();

        public void HeadConfigure()
        {
            TitleConfiguration();
            LinkConfiguration();
            MetaConfiguration();
        }

        public void TitleConfiguration()
        {
            Console.WriteLine("Podaj tytuł strony internetowej.");
            hTitle.Title = Console.ReadLine();
        }

        public void LinkConfiguration()
        {
            Console.WriteLine("Podaj ścieżkę do pliku.");
            hLink.Href = Console.ReadLine();
            Console.WriteLine("Podaj typ relacji.");
            hLink.Relationship = Console.ReadLine();
        }

        public void MetaConfiguration()
        {
            Console.WriteLine("Podaj, jakim kodowaniem ma się posługiwać strona internetowa.");
            hMeta.Charset = Console.ReadLine();
        }

        public string HeadWrite()
        {
            headCode.headElements = hTitle.Render() + hLink.Render() + hMeta.Render();
            return headCode.Render();
        }

        public string EntireCodeEnd() => $"</body>\n</html>";

        public void ChangeHead()
        {
            Console.WriteLine("Który element z sekcji HEAD chcesz zmienić:");
            Console.WriteLine("1. Tytuł strony internetowej.");
            Console.WriteLine("2. Link do arkuszu stylu CSS.");
            Console.WriteLine("3. Kodowanie strony internetowej.");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    TitleConfiguration();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    LinkConfiguration();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    MetaConfiguration();
                    break;
            }
        }
    }

    class BodyBuilder
    {
        private string bodyCode;
        private Hr[] hr;
        private Div[] div;
        private HGroup[] hgroup;
        private OrderedListElement[] ol;
        private ListElement[] ul;
        private Paragraph[] p;
        private Image[] img;
        private Audio[] audio;
        private Track[] track;
        private Video[] video;
        private bool[] activeElement;

        public void BodyConfigure()
        {
            Console.WriteLine("Który element z sekcji BODY chcesz zmienić:");
            //bodyCode.headElements = hTitle.Render() + hLink.Render() + hMeta.Render();
            //return;//bodyCode.Render();
        }

        public string BodyWrite() => bodyCode;

        public void ElementsInBody()
        {
            switch ((string)Console.ReadLine().ToUpper())
            {
                case "HR":
                    hr[^1] = new();
                    bodyCode = hr[^1].BaseCode();
                    Console.WriteLine(Hr.Messages.HrMessage);
                    break;
                case "DIV":
                    Console.WriteLine(Div.Messages.EntryMessage);
                    div[^1] = new();
                    div[^1].AddToCode(div[^1].StartOfCode());
                    do
                    {
                        ElementsInBody();
                    } while (activeElement[^1]);
                    div[^1].BaseCode();
                    break;
                case "HGROUP":
                    Console.WriteLine(HGroup.Messages.EntryGroup);
                    hgroup[^1] = new();
                    bodyCode = hgroup[^1].BaseCode();
                    break;
                case "OL":
                    Console.WriteLine(OrderedListElement.Messages.EntryText);
                    ol[^1] = new();
                    ol[^1].AddToCode(ol[^1].StartOfCode());
                    ol[^1].ListText[^1] = Console.ReadLine();
                    OrientedElementsInList();
                    bodyCode = ol[^1].BaseCode();
                    break;
                case "UL":
                    Console.WriteLine(ListElement.Messages.EntryText);
                    ul[^1] = new();
                    ul[^1].AddToCode(ul[^1].StartOfCode());
                    ul[^1].ListText[^1] = Console.ReadLine();
                    ElementsInList();
                    bodyCode = ul[^1].BaseCode();
                    break;
                case "P":
                    p[^1] = new();
                    bodyCode = p[^1].BaseCode();
                    break;
                case "IMAGE":
                    img[^1] = new();
                    bodyCode = img[^1].BaseCode();
                    break;
                case "AUDIO":
                    audio[^1] = new();
                    bodyCode = audio[^1].BaseCode();
                    break;
                case "TRACK":
                    track[^1] = new();
                    bodyCode = track[^1].BaseCode();
                    break;
                case "VIDEO":
                    video[^1] = new();
                    bodyCode = video[^1].BaseCode();
                    break;
                default:
                    break;
            }
        }

        public void ElementsInList()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine(ListElement.Messages.EntryText);
                    ul[^1].ListText[^1] = Console.ReadLine();
                    ElementsInList();
                    break;
                default:
                    break;
            }
        }

        public void OrientedElementsInList()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine(OrderedListElement.Messages.EntryText);
                    ol[^1].ListText[^1] = Console.ReadLine();
                    ElementsInList();
                    break;
                default:
                    break;
            }
        }
    }
}
