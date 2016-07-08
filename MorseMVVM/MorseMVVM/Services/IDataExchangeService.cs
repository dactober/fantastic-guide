namespace MorseMVVM.Services
{
    public interface IDataExchangeService
    {
        string GetMorseText(string text);

        string GetText(string morsecode);
    }
}