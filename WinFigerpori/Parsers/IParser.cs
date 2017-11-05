using System.Threading.Tasks;

namespace WinFigerpori.Parsers
{
    internal interface IParser
    {
        string Address { get; }

        string SavePath { get; set; }

        Task<bool> ParseAsync();
    }
}
