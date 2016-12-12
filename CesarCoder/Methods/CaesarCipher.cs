namespace CaesarCoder.Methods
{
    /// <summary>
    /// Шифр Цезаря
    /// </summary>
    class CaesarCipher
    {
        /// <summary>
        /// Шифрование методом Цезаря
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string Coding(string input, int key)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += CaesarCipherCoding(element, key);

            return txt;
        }

        /// <summary>
        /// Расшифрование методом Цезаря
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string Encoding(string input, int key)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += CaesarCipherEncoding(element, key);

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
        /// Логика расшифрования методом Цезаря
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованый символ</returns>
        private static char CaesarCipherEncoding(char ch, int key)
        {
            return (char)(ch - key);
        }
    }
}
