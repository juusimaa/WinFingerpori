using System.Threading.Tasks;

namespace WinFigerpori.Parsers
{
    internal interface IParser
    {
        string Address { get; }

        Task<bool> ParseAsync();
    }
}
