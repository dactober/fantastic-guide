using System;

namespace MorseLibrary
{
    public class SymbMorse
    {
        static public string Code
        {
            get; set;
        }

        public SymbMorse(string code)
        {
            Code = code;
        }

        public SymbMorse()
        {
        }

        public MorseSymbEnum[] Symb
        {
            get; set;
        }

        public SymbMorse(MorseSymbEnum[] symb)
        {
            Symb = symb;
        }

        static public bool TryParse(string code, out SymbMorse symb)
        {
            bool с = true;

            if (Alphabet.ToEnum(code, false) != null)
            {
            }
            else
            {
                с = false;
            }

            if (с == true)
                symb = Parse(code);
            else symb = null;

            return с;
        }

        static public SymbMorse Parse(string code)
        {
            SymbMorse Mors = new SymbMorse(Alphabet.ToEnum(code, false));
            return Mors;
        }

        static public string ConvertTo(string symbol, int i, int lenght)
        {
            int j = 0;

            while (j < Alphabet.charactersR.Count)
            {
                if (symbol == " ")
                {
                    Code = Alphabet.codeMorse[j];

                    break;
                }
                else
                {
                    if (symbol.ToUpper() == Alphabet.charactersR[j].ToString())
                    {
                        Code = Alphabet.codeMorse[j];
                        if (i + 1 != lenght)
                            Code += " ";
                        break;
                    }
                }

                j++;
            }
            if (Code == "")
                throw new Exception("Неверный символ!");

            return Code;
        }

        public override string ToString()
        {
            int j = 0;

            while (j < Alphabet.codeMorse.Count)
            {
                if (Code == " ")
                {
                    Code = Alphabet.charactersR[j++].ToString();
                    Code += Code;
                    break;
                }
                if (Code == Alphabet.codeMorse[j])
                {
                    Code = Alphabet.charactersR[j].ToString();

                    break;
                }
                j++;
            }
            return Code;
        }
    }
}