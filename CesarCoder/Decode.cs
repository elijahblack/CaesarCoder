using CaesarCoder.Methods;
using System;
using System.Text;

namespace CaesarCoder
{
    /// <summary>
    /// Расшифрование
    /// </summary>
    class Decode
    {
        /// <summary>
        /// Расшифрование методом Цезаря
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string CaesarCipher(string input, int key)
        {
            return Methods.CaesarCipher.Decode(input, key);
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
            return Methods.AffineCipher.Decode(input, a, b);
        }

        /// <summary>
        /// Расшифрование гаммированием
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string GammaCipher(string input, int key)
        {
            return Methods.GammaCipher.Decode(input, key);
        }

        //
        public static string FeistelNetwork(string input, string key)
        {
            return Methods.FeistelNetwork.Decode(input, key);
        }

        /// <summary>
        /// Расшифрование при помощи алгоритма RC4
        /// </summary>
        /// <param name="input">Расшифруемый текст</param>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        public static string RC4(string input, string key)
        {
            return Encoding.ASCII.GetString(new RC4(Encoding.ASCII.GetBytes(key)).Decode(Encoding.ASCII.GetBytes(input)));
        }
    }
}
