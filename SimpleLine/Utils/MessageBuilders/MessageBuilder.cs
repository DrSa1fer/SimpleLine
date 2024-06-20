using System.IO;

namespace SimpleLineLibrary.Utils.MessageBuilders
{
    internal class MessageBuilder
    {
        private List<string> _page;
        private string _enter;
        private int _tabs;

        public MessageBuilder()
        {
            _enter = Environment.NewLine;
            _page = new();
            _tabs = 0;            
        }

        public MessageBuilder AddHeader(string header)
        {
            WriteLine($">> {header}", 0);
            return this;
        }

        public MessageBuilder AddFooter(string footer)
        {
            WriteLine($">> {footer}", 0);
            return this;
        }

        public MessageBuilder StartBlock(string text = "", bool newLine = true)
        {
            if (newLine)
            {
                WriteLine("", 0);
            }
            
            WriteLine(text);
            _tabs++;
            return this;
        }

        public MessageBuilder CloseBlock()
        {
            _tabs--;
            return this;
        }        
        
        public MessageBuilder WriteLine(string text)
        {
            _page.Add($"{new string(' ', _tabs * 4)}{text}");
            return this;
        }

        public MessageBuilder WriteLine(string text, int tabs)
        {
            _page.Add($"{new string(' ', tabs * 4)}{text}");
            return this;
        }

        public MessageBuilder SkipLine()
        {
            WriteLine("", 0);
            return this;
        }

        public void Print(TextWriter tw)
        {
            tw.WriteLine(ToString());
        }

        public override string ToString()
        {
            return string.Join(_enter, _page);
        }
    }
}