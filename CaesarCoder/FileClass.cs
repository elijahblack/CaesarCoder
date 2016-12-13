using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CaesarCoder
{
    class FileClass
    {
        // Класс для удобного взаимодействия с файлами

        public string FileName { get; set; }
        public string FileText { get; set; }


        /// <summary>
        /// Открытие файла через диалог
        /// </summary>
        public void Open()
        {
            string str = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            openFileDialog1.Title = "Открыть файл";

            //if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                //return;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // получаем выбранный файл
                FileName = openFileDialog1.FileName;
                // читаем файл в строку
                FileText = System.IO.File.ReadAllText(FileName, Encoding.GetEncoding(1251));
            }
        }

        /// <summary>
        /// Сохранение файла через диалог
        /// </summary>
        /// <param name="Text">Сохраняемый текст</param>
        public void Save(string Text)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            saveFileDialog1.Title = "Сохранить файл";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, Text);
            }
        }


        /// <summary>
        /// Метод перевода кириллицы в латиницу методом старого доброго транслита
        /// </summary>
        /// <param name="str">Переводимый текст</param>
        /// <returns></returns>
        public static string Translater(string str)
        {
            string txt = "";

            foreach (char element in str.ToCharArray())
                txt += Dictionary(element);

            return txt;
        }

        /// <summary>
        /// Словарик для посимвольного транслита
        /// </summary>
        /// <param name="ch">Переводимый символ</param>
        /// <returns></returns>
        private static string Dictionary(char ch)
        {
            Dictionary<char, string> letters = new Dictionary<char, string>();

            letters.Add('а', "a");
            letters.Add('б', "b");
            letters.Add('в', "v");
            letters.Add('г', "g");
            letters.Add('д', "d");
            letters.Add('е', "e");
            letters.Add('ё', "yo");
            letters.Add('ж', "zh");
            letters.Add('з', "z");
            letters.Add('и', "i");
            letters.Add('й', "j");
            letters.Add('к', "k");
            letters.Add('л', "l");
            letters.Add('м', "m");
            letters.Add('н', "n");
            letters.Add('о', "o");
            letters.Add('п', "p");
            letters.Add('р', "r");
            letters.Add('с', "s");
            letters.Add('т', "t");
            letters.Add('у', "u");
            letters.Add('ф', "f");
            letters.Add('х', "h");
            letters.Add('ц', "c");
            letters.Add('ч', "ch");
            letters.Add('ш', "sh");
            letters.Add('щ', "shh");
            letters.Add('ь', "");
            letters.Add('ы', "y");
            letters.Add('ъ', "'");
            letters.Add('э', "je");
            letters.Add('ю', "ju");
            letters.Add('я', "ja");

            if (letters.ContainsKey(ch) || letters.ContainsKey(Char.ToLower(ch)))
            {
                if (Char.IsLower(ch))
                    return letters[ch];
                else if (Char.IsUpper(ch))
                    return letters[Char.ToLower(ch)].ToUpper();
            }

            return ch.ToString();
        }
    }
}
