namespace CaesarCoder.Methods
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
        public static string Encode(string input, int key)
        {
            int A = new PseudoRandomNumberGenerator().A,
                B = new PseudoRandomNumberGenerator().B,
                m = new PseudoRandomNumberGenerator().M;


            string txt = "";

            if (Mathematics.GCD(B, m) == 1)
            {
                foreach (char element in input.ToCharArray())
                {
                    txt += GammaCipherEncode(element, key);
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
        public static string Decode(string input, int key)
        {
            int A = new PseudoRandomNumberGenerator().A,
                B = new PseudoRandomNumberGenerator().B,
                m = new PseudoRandomNumberGenerator().M;


            string txt = "";

            if (Mathematics.GCD(B, m) == 1)
            {
                foreach (char element in input.ToCharArray())
                {
                    txt += GammaCipherDecode(element, key);
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
        private static char GammaCipherEncode(char ch, int key)
        {
            return (char)(ch ^ key);
        }

        /// <summary>
        /// Логика посимвольного расшифрования гаммированием
        /// </summary>
        /// <param name="ch">Расшифруемый символ</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns>Возвращает шифрованный символ</returns>
        private static char GammaCipherDecode(char ch, int key)
        {
            return (char)(ch ^ key); 
        }
    }
}
