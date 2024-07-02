using System.IO;

namespace SimpleLineLibrary.Utils
{
    internal sealed class MessageBuilder
    {
        private readonly List<string> _page;
        private readonly string _enter;
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

        public MessageBuilder StartBlock(string text = "")
        {
            WriteLine(text);
            _tabs++;
            return this;
        }

        public MessageBuilder CloseBlock()
        {
            _tabs = _tabs - 1 > -1 ? _tabs - 1 : 0;

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