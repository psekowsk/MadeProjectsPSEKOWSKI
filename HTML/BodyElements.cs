using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    public abstract class BodyElements
    {
        public string Id { get; set; }
        public StringBuilder code = new();
        public static class Messages { }

        public abstract string StartOfCode();
        public abstract string EndOfCode();
        public void AddToCode(string value) { code.Append($"{value}"); }
        public abstract string BaseCode();
        public string Render() => Convert.ToString(code);
    }

    public abstract class Attributes : BodyElements
    {
        public static List<string> AvailableAttributes { get; set; }
        public static List<string> AvailableAttributesWithValues { get; set; }
        public static List<string> ChosenAttributes { get; set; }
        public string Source { get; set; }

        public static bool CheckAttributes(string UserAttribute)
        {
            if (UserAttribute.Contains(Convert.ToString(AvailableAttributes))) return true;
            else return false;
        }

        public static bool CheckAttributesWithValue(string UserAttribute)
        {
            if (UserAttribute.Contains(Convert.ToString(AvailableAttributesWithValues))) return true;
            else return false;
        }

        public StringBuilder WriteAttributes()
        {
            foreach (string x in ChosenAttributes)
            {
                code.Append($"{x} ");
            }
            return code;
        }

        public string ReturnAttribute(string Attribute, string Value) => $"{Attribute}='{Value}'";
    }
}
