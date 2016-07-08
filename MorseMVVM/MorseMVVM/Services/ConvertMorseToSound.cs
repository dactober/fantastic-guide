using MorseLibrary;

namespace MorseMVVM.Services
{
    public class ConvertMorseToSnd : IConvertMorseToSound
    {
        public void ConvertToSnd(string MessageMorse)
        {
            ConvertMorseToSound cmts = new ConvertMorseToSound(MessageMorse);
        }
    }
}