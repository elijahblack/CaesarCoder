using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCoder.Methods
{
    class fn
    {
        public static string Encode(string input, string key)
        {
            // если ключ короче 8 символов, наращиваем пробелами
            if (key.Length != 0)
                while (key.Length < 8)
                    key += " ";

            byte[] input_arr = Encoding.Default.GetBytes(input);
            byte[] key_arr = Encoding.Default.GetBytes(key);

            if (input_arr.Length % 8 != 0) 
            {
                byte[] temp = new byte[input_arr.Length + (8 - (input_arr.Length % 8))];
                Array.Copy(input_arr, temp, input_arr.Length);
                input_arr = temp;
            }

            byte[] output_arr = new byte[input_arr.Length];

            for (int i = 0; i < input_arr.Length; i = i + 8)
            {
                byte[] block = new byte[8];
                Array.Copy(input_arr, i, block, 0, 8);

                for (int j = 0; j <= 9; j++)
                {
                    //создаем 2 подблока
                    byte[] subblock_left_arr = new byte[4];
                    Array.Copy(block, subblock_left_arr, 4);
                    byte[] subblock_right_arr = new byte[4];
                    Array.Copy(block, 4, subblock_right_arr, 0, 4);

                    //создаем раундовый ключ
                    byte[] subblock_key_arr = new byte[4];
                    Array.Copy(key_arr, subblock_key_arr, 4);
                    subblock_key_arr = ShiftKeyLeft(key_arr, j);

                    if (j != 9)//если j = 9, то не надо поблоки менять местами
                        block = EncodeBlock(subblock_left_arr, subblock_right_arr, subblock_key_arr, false);
                    else
                        block = EncodeBlock(subblock_left_arr, subblock_right_arr, subblock_key_arr, true);
                }
                //скидываем блок в результирующий массив
                Array.Copy(block, 0, res_arr, i, block.Length);
            }
            return Encoding.Default.GetString(res_arr);
        }

        public static string Decode(string input, string key)
        {

        }

        private static byte[] ShiftKeyLeft(byte[] key_arr, int i)
        {

        }
    }
}
