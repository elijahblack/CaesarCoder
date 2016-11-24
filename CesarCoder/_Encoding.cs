using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCoder
{
    /// <summary>
    /// Расшифрование
    /// </summary>
    class _Encoding
    {
        /// <summary>
        /// Расшифрование методом Цезаря
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string CaesarCipher(string input, int key)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += _Encoding.CaesarCipherEncoding(element, key);

            return txt;
        }

        /// <summary>
        /// Расшифрование методом аффинного шифра
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="a">Первый ключ расшифрования</param>
        /// <param name="b">Второй ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string AffineCipher(string input, char a, char b)
        {
            // получает строку с шифрованным текстом и ключ 
            // возвращает расшифрованный текст

            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += _Encoding.AffineCipherEncoding(element, a, b);

            return txt;
        }

        /// <summary>
        /// Расшифрование гаммированием
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string GammaCipher(string input, int key)
        {
            int A = new PseudoRandomNumberGenerator().A,
                B = new PseudoRandomNumberGenerator().B,
                m = new PseudoRandomNumberGenerator().M;


            string txt = "";

            if (Mathematics.GCD(B, m) == 1)
            {
                foreach (char element in input.ToCharArray())
                {
                    txt += _Encoding.GammaCipherEncoding(element, key);
                    key = (key * A + B) % m;  
                }
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка: \nНОД = " + Mathematics.GCD(B, m), "Ошибка");

            return txt;
        }



        /// <summary>
        /// Логика расшифрования методом Цезаря
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованый символ</returns>
        private static char CaesarCipherEncoding(char ch, int key)
        {
            return (char)(ch - key);
        }

        /// <summary>
        /// Логика расшифрованияя методом аффинного шифра
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="a">Первый ключ расшифрования</param>
        /// <param name="b">Второй ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный символ</returns>
        private static char AffineCipherEncoding(char ch, char a, char b)
        {
            char offset;

            if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
            {
                offset = Char.IsUpper(ch) ? 'A' : 'a';
                return (char)(((Reverse(a) * ((ch - offset) - b + 26)) % 26) + offset);
            }
            return (ch);
        }

        /// <summary>
        /// Логика посимвольного расшифрования гаммированием
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает шифрованный символ</returns>
        private static char GammaCipherEncoding(char ch, int key)
        {
            return (char)(ch ^ key); // это не работает
        }


        /// <summary>
        /// Возвращает число, обратное A по модулю 26
        /// </summary>
        /// <param name="a">Символ, для которого требуется найти обратный номер позиции</param>
        /// <returns></returns>
        private static char Reverse (char a)
        {
            Dictionary<char, int> ReverseA = new Dictionary<char, int>()
            {
                { (char)(1),    1     },
                { (char)(3),    9     },
                { (char)(5),    21    },
                { (char)(7),    15    },
                { (char)(9),    3     },
                { (char)(11),   19    },
                { (char)(15),   7     },
                { (char)(17),   23    },
                { (char)(19),   11    },
                { (char)(21),   5     },
                { (char)(23),   17    },
                { (char)(25),   25    }
            };

            return (char)ReverseA[a];
        }
    }
}
