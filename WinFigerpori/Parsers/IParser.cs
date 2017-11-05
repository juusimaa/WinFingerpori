namespace WinFigerpori.Parsers
{
    internal interface IParser
    {
        string Address { get; }

        void ParseAsync();
    }
}
