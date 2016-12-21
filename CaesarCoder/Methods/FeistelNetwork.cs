using System;
using System.Text;

namespace CaesarCoder.Methods
{
    /// <summary>
    /// Сеть Фейстеля
    /// </summary>
    class FeistelNetwork
    {
        /// <summary>
        /// Шифрование сетью Фейстеля
        /// </summary>
        /// <param name="input">Шифруемая строка</param>
        /// <param name="key">Ключ</param>
        /// <returns>Возвращает шифрованную строку</returns>
        public static string Encode(string input, string key)
        {
            if (key.Length != 0 && key.Length < 8)
                while (key.Length < 8)
                {
                    key += " ";
                }

            //if (key.Length < 8)
            //    throw new ArgumentException("У вас слишком короткий строка");

            byte[] input_arr = Encoding.Default.GetBytes(input);
            byte[] key_arr = Encoding.Default.GetBytes(key);

            //если длина не кратна 64 битам (8 байтам)
            int diff = input_arr.Length % 8;
            if (diff != 0)
            {
                byte[] temp = new byte[input_arr.Length + (8 - diff)];
                Array.Copy(input_arr, temp, input_arr.Length);
                input_arr = temp;
            }

            byte[] res_arr = new byte[input_arr.Length];
            //шифруем по блокам
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

        /// <summary>
        /// Манипуляции блоками при шифровании
        /// </summary>
        /// <param name="subblock_left_arr"></param>
        /// <param name="subblock_right_arr"></param>
        /// <param name="subblock_key_arr"></param>
        /// <param name="isLast"></param>
        /// <returns></returns>
        private static byte[] EncodeBlock(byte[] subblock_left_arr, byte[] subblock_right_arr, byte[] subblock_key_arr, bool isLast)
        {
            int subblock_left = BitConverter.ToInt32(subblock_left_arr, 0);
            int subblock_right = BitConverter.ToInt32(subblock_right_arr, 0);
            int subblock_key = BitConverter.ToInt32(subblock_key_arr, 0);

            //xor
            subblock_left = subblock_left ^ subblock_key;
            subblock_left_arr = BitConverter.GetBytes(subblock_left);

            byte[] tmp = new byte[2]; 
            Array.Copy(subblock_left_arr, tmp, 2); 
            Int16 left = BitConverter.ToInt16(tmp, 0); 
            Array.Copy(subblock_left_arr, 2, tmp, 0, 2); 
            Int16 right = BitConverter.ToInt16(subblock_left_arr, 2); 

            //xor
            subblock_right = Shift(left, right) ^ subblock_right;
            subblock_right_arr = BitConverter.GetBytes(subblock_right);

            //меняем или не меняем подблоки местами при объединении
            byte[] res_arr = new byte[8];
            if (!isLast)
            {
                Array.Copy(subblock_right_arr, res_arr, 4);
                Array.Copy(subblock_left_arr, 0, res_arr, 4, 4);
            }
            else
            {
                Array.Copy(subblock_left_arr, res_arr, 4);
                Array.Copy(subblock_right_arr, 0, res_arr, 4, 4);
            }
            return res_arr;
        }

        /// <summary>
        /// Расшифрование сетью Фейстеля
        /// </summary>
        /// <param name="input">Расшифруемая строка</param>
        /// <param name="key">Ключ расшифрования</param>
        /// <returns></returns>
        public static string Decode(string input, string key)
        {
            if (key.Length != 0)
                while (key.Length < 8)
                {
                    key += " ";
                }

            //if (key.Length < 8)
            //    throw new ArgumentException("У вас слишком короткий строка");

            byte[] output_arr = Encoding.Default.GetBytes(input);
            byte[] key_arr = Encoding.Default.GetBytes(key);
            byte[] res_arr = new byte[output_arr.Length];
/*
            //если длина не кратна 64 битам (8 байтам)
            int diff = output_arr.Length % 8;
            if (diff != 0)
            {
                byte[] temp = new byte[output_arr.Length + (8 - diff)];
                Array.Copy(output_arr, temp, output_arr.Length);
                output_arr = temp;
            }
            byte[] res_arr = new byte[output_arr.Length];*/
            //throw new ArgumentException("Incorrect input string!");
            //начинаем с конца
            for (int i = output_arr.Length - 8; i >= 0; i = i - 8)
            {
                byte[] block = new byte[8];
                Array.Copy(output_arr, i, block, 0, 8);
                //применяем раундовые ключи в обратном порядке
                for (int j = 9; j >= 0; j--)
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

                    if (j != 0)//если j = 0, то не надо поблоки менять местами
                        block = DecodeBlock(subblock_left_arr, subblock_right_arr, subblock_key_arr, false);
                    else
                        block = DecodeBlock(subblock_left_arr, subblock_right_arr, subblock_key_arr, true);
                }
                //скидываем блок в результирующий массив
                Array.Copy(block, 0, res_arr, i, block.Length);
            }
            return Encoding.Default.GetString(res_arr);
        }

        /// <summary>
        /// Манипуляция блоками при расшифровании
        /// </summary>
        /// <param name="subblock_left_arr"></param>
        /// <param name="subblock_right_arr"></param>
        /// <param name="subblock_key_arr"></param>
        /// <param name="isLast"></param>
        /// <returns></returns>
        private static byte[] DecodeBlock(byte[] subblock_left_arr, byte[] subblock_right_arr, byte[] subblock_key_arr, bool isLast)
        {
            int subblock_left = BitConverter.ToInt32(subblock_left_arr, 0);
            int subblock_right = BitConverter.ToInt32(subblock_right_arr, 0);
            int subblock_key = BitConverter.ToInt32(subblock_key_arr, 0);

            byte[] tmp = new byte[2];
            Array.Copy(subblock_left_arr, tmp, 2);
            Int16 left = BitConverter.ToInt16(tmp, 0);
            Array.Copy(subblock_left_arr, 2, tmp, 0, 2);
            Int16 right = BitConverter.ToInt16(subblock_left_arr, 2);

            //xor
            subblock_right = Shift(left, right) ^ subblock_right;

            //xor
            subblock_left = subblock_left ^ subblock_key;
            subblock_left_arr = BitConverter.GetBytes(subblock_left);

            subblock_right_arr = BitConverter.GetBytes(subblock_right);

            //меняем или не меняем подблоки местами при объединении
            byte[] res_arr = new byte[8];
            if (!isLast)
            {
                Array.Copy(subblock_right_arr, res_arr, 4);
                Array.Copy(subblock_left_arr, 0, res_arr, 4, 4);
            }
            else
            {
                Array.Copy(subblock_left_arr, res_arr, 4);
                Array.Copy(subblock_right_arr, 0, res_arr, 4, 4);
            }
            return res_arr;
        }

        /// <summary>
        /// Сдвиг
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int Shift(Int16 left, Int16 right)
        {
            //циклический сдвиг влево на 7
            int l = left << 7;
            int r = l >> 16;
            left = (Int16)(l + r);

            //циклический сдвиг вправо на 5
            l = right >> 5;
            r = l << 11;//16-5
            right = (Int16)(l + r);

            //меняем части местами
            int res = (int)left << 16;
            return res + right;
        }
        
        /// <summary>
        /// Манипуляция ключами
        /// </summary>
        /// <param name="key_arr"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static byte[] ShiftKeyLeft(byte[] key_arr, int i)
        {
            byte[] tmp = new byte[4];
            Array.Copy(key_arr, tmp, 4);
            int left = BitConverter.ToInt32(tmp, 0);
            Array.Copy(key_arr, 4, tmp, 0, 4);
            int right = BitConverter.ToInt32(tmp, 0);

            //циклический сдвиг влево на i * 3
            int l_l = left << (i * 3);
            int r_r = right >> (32 - i * 3);
            left = l_l + r_r;

            return BitConverter.GetBytes(left);
        }
    }
}
