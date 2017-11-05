using AngleSharp;
using AngleSharp.Parser.Html;
using System.Linq;

namespace WinFigerpori.Parsers
{
    internal class HsParser : IParser
    {
        public string Address => @"https://www.hs.fi/fingerpori/";

        public async void ParseAsync()
        {
            var parser = new HtmlParser();

            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync(Address);

            var fileExtensions = new string[] { ".jpg", ".png" };

            var attribs = new string[] { "src", "alt" };

            foreach (var element in document.All)
            {
                if (element.TagName.Equals("IMG") && element.Attributes.Length == 2 && element.Attributes[0].Name.Equals("src") && element.Attributes[1].Name.Equals("alt"))
                {
                    var p = element.Attributes[0].Value;
                    continue;
                }
            }
        }
    }
}
