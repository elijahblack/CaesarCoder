namespace CesarCoder.Methods
{
    /// <summary>
    /// Шифр гаммированием
    /// </summary>
    class GammaCipher
    {
        /// <summary>
        /// Шифрование гаммированием
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string Coding(string input, int key)
        {
            int A = new PseudoRandomNumberGenerator().A,
                B = new PseudoRandomNumberGenerator().B,
                m = new PseudoRandomNumberGenerator().M;


            string txt = "";

            if (Mathematics.GCD(B, m) == 1)
            {
                foreach (char element in input.ToCharArray())
                {
                    txt += GammaCipherCoding(element, key);
                    key = (key * A + B) % m;
                }
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка: \nНОД = " + Mathematics.GCD(B, m), "Ошибка");

            return txt;
        }

        /// <summary>
        /// Расшифрование гаммированием
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string Encoding(string input, int key)
        {
            int A = new PseudoRandomNumberGenerator().A,
                B = new PseudoRandomNumberGenerator().B,
                m = new PseudoRandomNumberGenerator().M;


            string txt = "";

            if (Mathematics.GCD(B, m) == 1)
            {
                foreach (char element in input.ToCharArray())
                {
                    txt += GammaCipherEncoding(element, key);
                    key = (key * A + B) % m;
                }
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка: \nНОД = " + Mathematics.GCD(B, m), "Ошибка");

            return txt;
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

        /// <summary>
        /// Логика посимвольного расшифрования гаммированием
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает шифрованный символ</returns>
        private static char GammaCipherEncoding(char ch, int key)
        {
            return (char)(ch ^ key); 
        }
    }
}
