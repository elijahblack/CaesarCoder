using CaesarCoder.Methods;
using System;
using System.Text;

namespace CaesarCoder
{
    /// <summary>
    /// Шифрование
    /// </summary>
    class Encode
    {
        /// <summary>
        /// Шифрование методом Цезаря
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string CaesarCipher(string input, int key)
        {
            return Methods.CaesarCipher.Encode(input, key);
        }

        /// <summary>
        /// Шифрование аффинным методом 
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="a">Первый ключ шифрования (множитель)</param>
        /// <param name="b">Второй ключ шифрования (приращение)</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string AffineCipher(string input, char a, char b)
        {
            return Methods.AffineCipher.Encode(input, a, b);
        }
        
        /// <summary>
        /// Шифрование гаммированием
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string GammaCipher(string input, int key)
        {
            return Methods.GammaCipher.Encode(input, key);            
        }

        //
        public static string FeistelNetwork(string input, string key)
        {
            return Methods.FeistelNetwork.Encode(input, key);
        }

        /// <summary>
        /// Шифрование при помощи алгоритма RC4
        /// </summary>
        /// <param name="input">Шифруемый текст</param>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        public static string RC4(string input, string key)
        {
            //BitConverter.ToString();
            //new RC4(BitConverter.GetBytes(key))
            return Encoding.ASCII.GetString(new RC4(Encoding.ASCII.GetBytes(key)).Encode(Encoding.ASCII.GetBytes(input)));
        }
    }
}