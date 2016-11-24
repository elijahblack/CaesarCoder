using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesarCoder
{
    public partial class MainForm : Form
    {
        FileClass File = new FileClass();
        int count = 0;
        Timer timer = new Timer() { Interval = 70  };
        string title = "";


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // всякое визуальное
            KeyLabel2.Visible = false;
            KeyTextBox2.Visible = false;
            timer.Tick += timer_tick;
        }

       
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // открывает файл и заносит текст в верхний textBox
            File.Open();
            OriginalTextBox.Text = File.FileText;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // сохраняет текст из нижнего textBox
            File.Save(EditingTextBox.Text);
        }


        
        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ограничение на ввод только цифр в textBox ключа
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // манипуляции всякими элементами
            // нужно, чтобы я был доволен

            if (MethodComboBox.SelectedIndex == 0)
            {
                // всё до следующего коментария для того, чтобы удалить
                // всё, что не цифры, там где нужны только цифры
                foreach (char element in KeyTextBox1.Text.ToCharArray())
                    if (!Char.IsDigit(element))
                        KeyTextBox1.Text = KeyTextBox1.Text.Replace(element.ToString(), "");


                // скрывает textBox второго ключа за ненадобностью, 
                // скукоживает кнопку и задает ограничение на ввод только цифр
                KeyLabel2.Visible = false;
                KeyTextBox2.Visible = false;

                KeyTextBox1.KeyPress += OnlyNumber_KeyPress;
            }
            if (MethodComboBox.SelectedIndex == 1)
            {
                // выводит textBox второго ключа за надобностью, 
                // разкукоживает кнопку и снимает ограничение на ввод только цифр
                KeyLabel2.Visible = true;
                KeyTextBox2.Visible = true;

                //textBox3.KeyPress -= OnlyNumber_KeyPress;
            }
            if (MethodComboBox.SelectedIndex == 2)
            {
                // всё до следующего коментария для того, чтобы удалить
                // всё, что не цифры, там где нужны только цифры
                foreach (char element in KeyTextBox1.Text.ToCharArray())
                    if (!Char.IsDigit(element))
                        KeyTextBox1.Text = KeyTextBox1.Text.Replace(element.ToString(), "");


                // скрывает textBox второго ключа за ненадобностью, 
                // скукоживает кнопку и задает ограничение на ввод только цифр
                KeyLabel2.Visible = false;
                KeyTextBox2.Visible = false;

                KeyTextBox1.KeyPress += OnlyNumber_KeyPress;
            }
            // GammaReDraw();
        }

        

        private void транслитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // так как кодилки работают только с латиницей, а искать
            // соответствующий текст мне лень, была сделана функция ТРАНСЛИТА,
            // а эта кнопка делает пиу-пиу и переводит кириллицу в латиницу
            OriginalTextBox.Text = FileClass.Translater(OriginalTextBox.Text);
        }

        private void шифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str1 = OriginalTextBox.Text;
            string str2 = "";

            // если строка с ключем не пуста, смотрит на ComboBox, 
            // в котором выбирается метод шифрования
            if (KeyTextBox1.Text != "")
                switch (MethodComboBox.SelectedIndex)
                {
                    case 0: // если выбран первый пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую кодилку и запишет всё в STR2
                        str2 = Coding.CaesarCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 1: // если выбран второй пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую кодилку и запишет всё в STR2
                        if(!("1 3 5 7 9 11 15 17 19 21 23 25").Contains(KeyTextBox1.Text))
                        {
                            var res = MessageBox.Show(@"Ключ должен быть из следующего множества: " 
                                            + Environment.NewLine 
                                            + "[ 1 3 5 7 9 11 15 17 19 21 23 25 ]", 
                                            "Неверный первый ключ");
                            if (res == DialogResult.OK)
                                break;
                        }
                        else
                            str2 += Coding.AffineCipher(str1, (char)(Convert.ToInt32(KeyTextBox1.Text)), (char)(Convert.ToInt32(KeyTextBox2.Text)));
                        break;
                    case 2: // если выбран третий пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую кодилку и запишет всё в STR2
                        str2 = Coding.GammaCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    default:
                        // если будет выбран не первый и не второй ComboBox, то будет тупить,
                        // потому что других там нет
                        MessageBox.Show("эээээээ\n" + MethodComboBox.SelectedIndex, "\"эээээээ\" при шифровании");
                        break;
                }
            // а если строка с ключем пуста, попросит ввести ключ и обзовёт рупожопом
            else MessageBox.Show("Введите ключ", "Рукожоп", MessageBoxButtons.OK);

            // выводит в нижний textBox получившуюся строку
            EditingTextBox.Text = str2;
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str1 = OriginalTextBox.Text;
            string str2 = "";

            // если строка с ключем не пуста, смотрит на ComboBox, 
            // в котором выбирается метод расшифрования
            if (KeyTextBox1.Text != "")
                switch (MethodComboBox.SelectedIndex)
                {
                    case 0: // если выбран первый пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую энкодилку и запишет всё в STR2
                        str2 = _Encoding.CaesarCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 1: // если выбран второй пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую энкодилку и запишет всё в STR2
                        if (!("1 3 5 7 9 11 15 17 19 21 23 25").Contains(KeyTextBox1.Text))
                        {
                            var res = MessageBox.Show(@"Ключ должен быть из следующего множества: "
                                            + Environment.NewLine
                                            + "[ 1 3 5 7 9 11 15 17 19 21 23 25 ]",
                                            "Неверный первый ключ");
                            if (res == DialogResult.OK)
                                break;
                        }
                        else
                            str2 += _Encoding.AffineCipher(str1, (char)(Convert.ToInt32(KeyTextBox1.Text)), (char)(Convert.ToInt32(KeyTextBox2.Text)));
                        break;
                    case 2: // если выбран третий пункт ComboBox'а
                        // прогоняет строку посимвольно через
                        // соответствующую кодилку и запишет всё в STR2
                        str2 = _Encoding.GammaCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    default:
                        // если будет выбран не первый и не второй ComboBox, то будет тупить,
                        // потому что других там нет
                        MessageBox.Show("эээээээ\n" + MethodComboBox.SelectedIndex, "\"эээээээ\" при расшифровании");
                        break;
                }
            // а если строка с ключем пуста, попросит ввести ключ и обзовёт рупожопом
            else MessageBox.Show("Введите ключ", "Рукожоп", MessageBoxButtons.OK);

            // выводит в нижний textBox получившуюся строку
            EditingTextBox.Text = str2;
        }


        private void карусельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // меняет текст в окнах местами
            // потому что руками - лень
            string str = OriginalTextBox.Text;
            OriginalTextBox.Text = EditingTextBox.Text;
            EditingTextBox.Text = str;
        }

        private void карусельСПотерямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // меняет исходный текст с конечным местами
            // и отчищает последний
            OriginalTextBox.Text = EditingTextBox.Text;
            EditingTextBox.Text = "";
        }

        private void стихиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // авторская фишка
            Random rand = new Random();
            string[] poem = new String[] {
                "Никогда не встанут на колени, \nДаже если их захватят в плен. \nГордые и смелые тюлени. \nПотому что у тюленей нет колен.",
                "Никогда не лягут кверху пузом, \nДаже если бросить их в тюрьму, \nСредиземноморские медузы. \nСами догадайтесь, почему. ",
                "Никогда с коленей на ноги не встанут, \nДаже если их скрутить в бараний рог, \nСиние киты — пучин морских титаны. \nНет у них коленей. Как и ног."
                };
            MessageBox.Show(poem[rand.Next(poem.Length)], "Стихи");
            // by_Elijah_Black
        }

        private void кнопкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // тут мне уже стало скучно
            Random rand = new Random();
            title = Text;
            Text = "by Elijah Black";
            // BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            count = count + 1;
            if (count > 35)
            {
                timer.Stop();
                BackColor = DefaultBackColor;
                count = 0;
                Text = title;
            }
        }
    }
}