using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace CaesarCoder
{
    public partial class MainForm : Form
    {
        FileClass File = new FileClass();
        bool OnlyNumber = false;

        // всё, что создается ниже, нужно для того, чтобы не нужно. 
        int count = 0;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 70 }; int limit = 100; //////////////
        string title = "";
        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.sound);
        


        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // всякое визуальное
            KeyLabel2.Visible = false;
            KeyTextBox2.Visible = false;
            Icon = Properties.Resources.icon;
            timer.Tick += timer_tick;
            soundPlayer.Load();
            pictureBox.Image = Properties.Resources.cat;
            pictureBox.Visible = false;
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

                // устанавливается ограничение на ввод только цифр
                // при поможи хитрых манипуляций
                if (!OnlyNumber)
                {
                    KeyTextBox1.KeyPress += OnlyNumber_KeyPress;
                    OnlyNumber = true;
                }
            }
            else if (MethodComboBox.SelectedIndex == 2)
            {
                // всё до следующего коментария для того, чтобы удалить
                // всё, что не цифры, там где нужны только цифры
                foreach (char element in KeyTextBox1.Text.ToCharArray())
                    if (!Char.IsDigit(element))
                        KeyTextBox1.Text = KeyTextBox1.Text.Replace(element.ToString(), "");

                // устанавливается ограничение на ввод только цифр
                // при поможи хитрых манипуляций
                if (!OnlyNumber)
                {
                    KeyTextBox1.KeyPress += OnlyNumber_KeyPress;
                    OnlyNumber = true;
                }
            }
            // снимает ограничение на ввод цифр, если такое установленно
            else if (OnlyNumber)
            {
                KeyTextBox1.KeyPress -= OnlyNumber_KeyPress;
                OnlyNumber = false;
            }

            // манипуляции полем для второго ключа
            if(MethodComboBox.SelectedIndex != 1 && MethodComboBox.SelectedIndex >= 0)
            {
                // скрывает textBox второго ключа за ненадобностью, 
                // скукоживает кнопку и задает ограничение на ввод только цифр
                KeyLabel2.Visible = false;
                KeyTextBox2.Visible = false;
            }
            else 
            {
                // выводит textBox второго ключа за надобностью, 
                // разкукоживает кнопку и снимает ограничение на ввод только цифр
                KeyLabel2.Visible = true;
                KeyTextBox2.Visible = true;
            }
        }

        


        private void транслитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // так как некоторые кодилки работают только с латиницей, а искать
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
                    case 0: // если выбран [Шифр Цезаря]
                        str2 = Encode.CaesarCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 1: // если выбран [Аффинный шифр]
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
                            str2 += Encode.AffineCipher(str1, (char)(Convert.ToInt32(KeyTextBox1.Text)), (char)(Convert.ToInt32(KeyTextBox2.Text)));
                        break;
                    case 2: // если выбран [Гаммирование]
                        str2 = Encode.GammaCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 3: // если выбран [Сеть Фейстеля]
                        str2 = Encode.FeistelNetwork(str1, KeyTextBox1.Text);
                        break;
                    case 4: // если выбран [RC4]
                        str2 = Encode.RC4(str1, KeyTextBox1.Text);
                        break;
                    default:
                        // если будет выбран не существующий ComboBox, то будет тупить,
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
                    case 0: // если выбран [Шифр Цезаря]
                        str2 = Decode.CaesarCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 1: // если выбран [Аффинный шифр]
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
                            str2 += Decode.AffineCipher(str1, (char)(Convert.ToInt32(KeyTextBox1.Text)), (char)(Convert.ToInt32(KeyTextBox2.Text)));
                        break;
                    case 2: // если выбран [Гаммирование]
                        str2 = Decode.GammaCipher(str1, Convert.ToInt32(KeyTextBox1.Text));
                        break;
                    case 3: // если выбран [Сеть Фейстеля]
                        str2 = Decode.FeistelNetwork(str1, KeyTextBox1.Text);
                        break;
                    case 4: // если выбран [RC4]
                        str2 = Decode.RC4(str1, KeyTextBox1.Text);
                        break;
                    default:
                        // если будет выбран несуществующий ComboBox, то будет тупить,
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
            
            title = Text;
            Text = "by Elijah Black";
            soundPlayer.Play();
            //timer.Start();

            //new Thread(() =>
            //{
            //    thread();
            //}).Start();

            //var timer = new System.Threading.Timer(thread, new AutoResetEvent(false), 0, 70);
        }

         
        //private void thread(Object stateInfo)
        //{
        //    Random rand = new Random();
        //    FormBorderStyle = FormBorderStyle.None;
        //    BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    OriginalTextBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    EditingTextBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    MethodComboBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    KeyTextBox1.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    if (KeyTextBox2.Visible) KeyTextBox2.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        //    MainMenuStrip.BackColor = стихиToolStripMenuItem.ForeColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

        //    pictureBox.Visible = pictureBox.Visible ? false : true;

        //    count = count + 1;
        //    if (count > limit)
        //    {
        //        //timer.Stop();
        //        FormBorderStyle = FormBorderStyle.Sizable;
        //        BackColor = DefaultBackColor;
        //        OriginalTextBox.BackColor = SystemColors.Window;
        //        EditingTextBox.BackColor = SystemColors.Window;
        //        MethodComboBox.BackColor = SystemColors.Window;
        //        KeyTextBox1.BackColor = SystemColors.Window;
        //        if (KeyTextBox2.Visible) KeyTextBox2.BackColor = SystemColors.Window;
        //        MainMenuStrip.BackColor = DefaultBackColor;
        //        стихиToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
        //        pictureBox.Visible = false;
        //        count = 0;
        //        Text = title;
        //        soundPlayer.Stop();
        //    }
        //}

        private void timer_tick(object sender, EventArgs e)
        {
            //Random rand = new Random();
            //FormBorderStyle = FormBorderStyle.None;
            //BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //OriginalTextBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //EditingTextBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //MethodComboBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //KeyTextBox1.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //if (KeyTextBox2.Visible) KeyTextBox2.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //MainMenuStrip.BackColor = стихиToolStripMenuItem.ForeColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            //pictureBox.Visible = pictureBox.Visible ? false : true;

            //count = count + 1;
            //if (count > limit)
            //{
            //    timer.Stop();
            //    FormBorderStyle = FormBorderStyle.Sizable;
            //    BackColor = DefaultBackColor;
            //    OriginalTextBox.BackColor = SystemColors.Window;
            //    EditingTextBox.BackColor = SystemColors.Window;
            //    MethodComboBox.BackColor = SystemColors.Window;
            //    KeyTextBox1.BackColor = SystemColors.Window;
            //    if (KeyTextBox2.Visible) KeyTextBox2.BackColor = SystemColors.Window;
            //    MainMenuStrip.BackColor = DefaultBackColor;
            //    стихиToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            //    pictureBox.Visible = false;
            //    count = 0;
            //    Text = title;
            //    soundPlayer.Stop();
            //}
        }
    }
}