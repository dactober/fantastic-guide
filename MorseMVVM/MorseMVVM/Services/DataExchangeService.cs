using MorseLibrary;

namespace MorseMVVM.Services
{
    public class DataExchangeService : IDataExchangeService
    {
        public string GetMorseText(string text)
        {
            return TextMorse.ConvertTo(text);
        }

        public string GetText(string morsecode)
        {
            TextMorse Tm = new TextMorse();

            TextMorse.TryParse(morsecode, out Tm);

            return Tm.ToString();
        }
    }
}