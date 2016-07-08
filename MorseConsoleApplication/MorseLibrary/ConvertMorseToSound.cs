using System;
using System.Threading;

namespace MorseLibrary
{
    public class ConvertMorseToSound
    {
        private string _message;
        private int currind;
        private Thread t;

        public ConvertMorseToSound(string message)
        {
            _message = message;
            currind = 0;
            t = new Thread(ConvertTo);
            StartConvertion();
        }

        internal void StartConvertion()
        {
            t.Start();
        }

        private void ConvertTo()
        {
            while (currind < _message.Length)
            {
                switch (_message[currind])
                {
                    case '.':
                        {
                            Console.Beep(1000, 100);
                            Thread.Sleep(100);

                            currind++;
                        }
                        break;

                    case '-':
                        {
                            Console.Beep(1000, 300);
                            Thread.Sleep(100);

                            currind++;
                        }
                        break;

                    case ' ':
                        {
                            if (_message[currind + 1] == ' ')
                            {
                                Thread.Sleep(700);
                                currind += 2;
                            }
                            else
                            {
                                Thread.Sleep(300);
                                currind++;
                            }
                        }
                        break;
                }
            }
        }
    }
}