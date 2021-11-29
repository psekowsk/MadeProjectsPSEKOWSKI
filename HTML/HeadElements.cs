using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    public abstract class HeadElements
    {
        public StringBuilder code = new();

        public abstract string Render();
    }

    public class HeadBase : HeadElements
    {
        public string headElements { get; set; }

        public override string Render()
        {
            code = new($"<html>\n<head>{headElements}\n</head>\n<body>");
            return Convert.ToString(code);
        }

        public string EndOfCode()
        {
            code = new($"</body>\n</html>");
            return Convert.ToString(code);
        }
    }

    public class HeadTitle : HeadElements
    {
        public string Title { get; set; }

        public override string Render()
        {
            code = new($"\n<title>{Title}</title>");
            return Convert.ToString(code);
        }
    }

    public class HeadLink : HeadElements
    {
        public string Href { get; set; }
        public string Relationship { get; set; }

        public override string Render()
        {
            code = new($"\n<link href='{Href}' rel='{Relationship}'/>");
            return Convert.ToString(code);
        }
    }

    public class HeadMeta : HeadElements
    {
        public string Charset { get; set; }

        public override string Render()
        {
            code = new($"\n<meta charset='{Charset}'/>");
            return Convert.ToString(code);
        }
    }
}
