using AngleSharp.Parser.Html;

namespace WinFigerpori.Parsers
{
    internal class HsParser : IParser
    {
        public void Parse(string address)
        {
            var parser = new HtmlParser();
            var document = parser.Parse(@"https://www.hs.fi/fingerpori/");
        }
    }
}
