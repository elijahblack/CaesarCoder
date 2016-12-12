namespace CaesarCoder.Methods
{
    /// <summary>
    /// Аффинный шифр
    /// </summary>
    class AffineCipher
    {
        /// <summary>
        /// Шифрование аффинным методом 
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="a">Первый ключ шифрования (множитель)</param>
        /// <param name="b">Второй ключ шифрования (приращение)</param>
        /// <returns>Возвращает шифрованный текст</returns>
        public static string Encode(string input, char a, char b)
        {
            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += AffineCipherCoding(element, a, b);

            return txt;
        }

        /// <summary>
        /// Расшифрование методом аффинного шифра
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="a">Первый ключ расшифрования (множитель)</param>
        /// <param name="b">Второй ключ расшифрования (приращение)</param>
        /// <returns>Возвращает расшифрованный текст</returns>
        public static string Decode(string input, char a, char b)
        {
            // получает строку с шифрованным текстом и ключ 
            // возвращает расшифрованный текст

            string txt = "";

            foreach (char element in input.ToCharArray())
                txt += AffineCipherEncoding(element, a, b);

            return txt;
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
                offset = System.Char.IsUpper(ch) ? 'A' : 'a';

                return (char)(((a * (ch - offset) + b) % 26) + offset);
            }
            return (ch);
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
                offset = System.Char.IsUpper(ch) ? 'A' : 'a';
                return (char)(((Reverse(a) * ((ch - offset) - b + 26)) % 26) + offset);
            }
            return (ch);
        }

        /// <summary>
        /// Возвращает число, обратное A по модулю 26
        /// </summary>
        /// <param name="a">Символ, для которого требуется найти обратный номер позиции</param>
        /// <returns></returns>
        private static char Reverse(char a)
        {
            System.Collections.Generic.Dictionary<char, int> ReverseA = new System.Collections.Generic.Dictionary<char, int>()
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
