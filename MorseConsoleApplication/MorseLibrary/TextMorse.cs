namespace MorseLibrary
{
    public class TextMorse
    {
        private static string[] mass;

        public TextMorse()
        {
        }

        public TextMorse(string text)
        {
            mass = new string[text.Length];
            int j = 0, i = 0;
            while (j < text.Length)
            {
                if (text[j] != ' ')
                {
                    mass[i] += text[j];
                }
                else
                {
                    i++;

                    if (j + 1 != text.Length)
                        if (text[j] == ' ' && text[j + 1] == ' ')
                        {
                            j++;

                            mass[i] = " ";
                            i++;
                        }
                }

                j++;
            }
        }

        static public MorseSymbEnum[] Text
        {
            get; set;
        }

        public TextMorse(MorseSymbEnum[] text)
        {
            Text = text;
        }

        public static bool TryParse(string text, out TextMorse text1)
        {
            TextMorse Morse = new TextMorse(text);
            SymbMorse symb;
            bool b = true;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    b = SymbMorse.TryParse(mass[i], out symb);
                    if (b == false)
                        break;
                }
            }
            if (b == true)
                text1 = Parse(text);
            else text1 = null;

            return b;
        }

        static public TextMorse Parse(string text)
        {
            TextMorse t = new TextMorse(Alphabet.ToEnumText(text, true));
            return t;
        }

        static public string ConvertTo(string text)
        {
            string str = "";
            for (int i = 0; i < text.Length; i++)
            {
                str += SymbMorse.ConvertTo(text[i].ToString(), i, text.Length);
            }

            return str;
        }

        public override string ToString()
        {
            string s = "";

            SymbMorse b;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    b = new SymbMorse(mass[i]);
                    s += b.ToString();
                }
                else break;
            }

            return s;
        }
    }
}