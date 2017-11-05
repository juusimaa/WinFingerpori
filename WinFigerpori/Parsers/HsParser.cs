using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WinFigerpori.Parsers
{
    internal class HsParser : IParser
    {
        public string Address => @"https://www.hs.fi/fingerpori/";

        public string SavePath { get; set; }

        public Task<bool> ParseAsync()
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                var parser = new HtmlParser();

                var config = Configuration.Default.WithDefaultLoader();

                var document = GetDocument();    
                
                var fileExtensions = new string[] { ".jpg", ".png" };

                var attribs = new string[] { "src", "alt" };

                foreach (var element in document.Result.All)
                {
                    // TODO: there must be better way
                    if (element.TagName.Equals("IMG") && element.Attributes.Length == 2 && element.Attributes[0].Name.Equals("src") && element.Attributes[1].Name.Equals("alt"))
                    {
                        var p = element.Attributes[0].Value;
                        p = p.Substring(2, p.Length - 2);

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(@"https://" + p), SavePath);
                        }

                        return true;
                    }
                }

                return false;
            });

        }

        private async Task<IDocument> GetDocument()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(Address);
            return document;
        }
    }
}
