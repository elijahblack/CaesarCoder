using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCoder.Methods
{
    class FeistelNetwork
    {
        //
        public static string Coding(string input, int key)
        {
            return "";
        }

        //
        public static string Encoding(string input, int key)
        {
            return "";
        }



        ///////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        private static UInt64 FeistelNetworkCrypt(UInt64 data, UInt16 key, int rounds)
        {
            UInt32 left, right, swap;
            int i;

            left = (UInt32)(data & 0xffffffff);
            right = (UInt32)((data >> 32) & 0xffffffff);

            for (i = 0; i < rounds; i++)
            {
                swap = left ^ FGamma(right, key);
                left = right;
                right = swap;
            }

            return (left | ((UInt64)right << 32));
        }

        /// <summary>
        /// Расшифрование
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        private static UInt64 FeistelNetworkDecrypt(UInt64 data, UInt16 key, int rounds)
        {
            UInt32 left, right, swap;
            int i;

            left = (UInt32)(data & 0xffffffff);
            right = (UInt32)((data >> 32) & 0xffffffff);

            for (i = rounds - 1; i >= 0; i--)
            {
                swap = right ^ FGamma(left, key);
                right = left;
                left = swap;
            }

            return (left | ((UInt64)right << 32));
        }



        /// <summary>
        /// Метод, конвертирующий текст в двоичный код
        /// </summary>
        /// <param name="text">Конвертируемый текст</param>
        /// <returns>Возвращает текст, преобразованный в двоичный код</returns>
        private static string ConvertToBin(string text)
        {
            string str = "";

            foreach (char element in text.ToCharArray())
                str += Convert.ToString(element, 2);

            return str;
        }

        private static string sFGamma(string data_half, int key)
        {
            //foreach (char element in )
            return (data_half ^ (key * 0xabcd1234).ToString()); // ??????
        }

        private static UInt32 FGamma(UInt32 data_half, UInt16 key)
        {
            return (data_half ^ ((UInt32)key * 0xabcd1234)); // ??????
        }
    }
}
