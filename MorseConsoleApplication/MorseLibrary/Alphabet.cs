using System;
using System.Collections.Generic;

namespace MorseLibrary
{
    internal class Alphabet
    {
        static public List<char> charactersR = new List<char>{' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь',
                                                        'Э', 'Ю', 'Я', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0','.',',',';',':','?','!','-','"'};

        static public List<string> codeMorse = new List<string> {" ", ".-", "-...", ".--", "--.",
                                                        "-..", ".", "...-", "--..",
                                                        "..", ".---", "-.-", ".-..",
                                                        "--", "-.", "---", ".--.",
                                                        ".-.", "...", "-", "..-",
                                                        "..-.", "....", "-.-.",
                                                        "---.", "----", "--.-",
                                                        "-.--", "-..-", "..-..",
                                                        "..--", ".-.-", ".----",
                                                        "..---", "...--", "....-",
                                                        ".....", "-....", "--...",
                                                        "---..", "----.", "-----","......",".-.-.-","-.-.-.","---...",
                                                        "..--..","--..--","-....-",".-..-." };

        static public MorseSymbEnum[] ToEnum(string code, bool a)
        {
            for (int i = 0; i < codeMorse.Count; i++)
            {
                if (code == codeMorse[i])
                {
                    a = true;
                    break;
                }
            }
            if (a == true)
            {
                MorseSymbEnum[] symb = new MorseSymbEnum[code.Length * 2];
                int k = 0;
                for (int i = 0; i < code.Length; i++)
                {
                    switch (code[i])
                    {
                        case '.': { symb[k++] = MorseSymbEnum.Point; symb[k++] = MorseSymbEnum.MinSpace; break; }
                        case '-': { symb[k++] = MorseSymbEnum.Dash; symb[k++] = MorseSymbEnum.MinSpace; break; }
                        case ' ':
                            {
                                if (a) { symb[k++] = MorseSymbEnum.Space; symb[k++] = MorseSymbEnum.Space; }
                                else
                                {
                                }
                                break;
                            }
                    }
                }
                return symb;
            }
            else
            {
                throw new IncorrectSymbException("code", code, "Введенного символа не существует в азбуке Морзе");
            }
        }

        static public MorseSymbEnum[] ToEnumText(string code, bool a)
        {
            MorseSymbEnum[] symb = new MorseSymbEnum[code.Length * 2];
            int k = 0;
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case '.': { symb[k++] = MorseSymbEnum.Point; symb[k++] = MorseSymbEnum.MinSpace; break; }
                    case '-': { symb[k++] = MorseSymbEnum.Dash; symb[k++] = MorseSymbEnum.MinSpace; break; }
                    case ' ':
                        {
                            if (a) { symb[k++] = MorseSymbEnum.Space; symb[k++] = MorseSymbEnum.Space; }
                            else
                            {
                            }
                            break;
                        }
                }
            }
            return symb;
        }

        static public string EnumTo(MorseSymbEnum[] symb)
        {
            string s = "";
            for (int i = 0; i < symb.Length; i++)
            {
                switch (symb[i])
                {
                    case MorseSymbEnum.Point: s += '.'; break;
                    case MorseSymbEnum.Dash: s += '-'; break;
                    case MorseSymbEnum.Space: s += ' '; break;
                    case MorseSymbEnum.MinSpace: break;
                    default: throw new Exception("Неверный символ");
                }
            }

            return s;
        }
    }
}