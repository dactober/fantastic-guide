using System;

namespace MorseLibrary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s, v = ""; int z;
            Console.WriteLine("Перевести на язык морзе(0), перевести с языка морзе(1)");
            z = int.Parse(Console.ReadLine());
            Console.Write("Введите предложение - ");
            s = Console.ReadLine();

            TextMorse a;

            switch (z)
            {
                case 0:
                    {
                        v = TextMorse.ConvertTo(s);
                        Console.Write(v);
                    }
                    break;

                case 1:
                    {
                        if (TextMorse.TryParse(s, out a))
                        {
                            Console.Write(a);
                        }
                    }
                    break;
            }

            Console.Read();
        }
    }
}