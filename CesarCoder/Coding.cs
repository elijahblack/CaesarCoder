using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CesarCoder
{
    /// <summary>
    /// Шифрование
    /// </summary>
    class Coding
    {
        /// <summary>
        /// Шифрование методом Цезаря
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string CaesarCipher(string input, int key)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += Coding.CaesarCipherCoding(element, key);

            return txt;
        }

        /// <summary>
        /// Шифрование аффинным методом 
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="a">Первый ключ шифрования</param>
        /// <param name="b">Второй ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string AffineCipher(string input, char a, char b)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += Coding.AffineCipherCoding(element, a, b);

            return txt;
        }
        
        /// <summary>
        /// Шифрование гаммированием
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
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
                    txt += Coding.GammaCipherCoding(element, key);
                    key = (key * A + B) % m;
                }
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка: \nНОД = " + Mathematics.GCD(B, m), "Ошибка" );

            return txt;            
        }



        /// <summary>
        /// Логика посимвольного шифрования методом Цезаря
        /// </summary>
        /// <param name="ch">Шифруемый символ</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный символ</returns>
        private static char CaesarCipherCoding(char ch, int key)
        {
            return (char)(ch + key);
        }

        /// <summary>
        /// Логика посимвольного шифрования афинным шифром
        /// </summary>
        /// <param name="ch">Шифруемый символ</param>
        /// <param name="a">Первый ключ шифрования</param>
        /// <param name="b">Второй ключ шифрования</param>
        /// <returns>Возвращает зашифрованный символ</returns>
        private static char AffineCipherCoding(char ch, char a, char b)
        {
            char offset;

            if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
            {
                offset = Char.IsUpper(ch) ? 'A' : 'a';

                return (char)(((a * (ch - offset) + b) % 26) + offset);
            }
            return (ch);
        }

        /// <summary>
        /// Логика посимвольного шифрования гаммированием
        /// </summary>
        /// <param name="ch">Шифруемый символ</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный символ</returns>
        private static char GammaCipherCoding(char ch, int key)
        {
            return (char)(ch ^ key);
        }
    }
}