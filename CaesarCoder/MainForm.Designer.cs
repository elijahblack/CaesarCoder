namespace CaesarCoder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OriginalTextBox = new System.Windows.Forms.TextBox();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расшифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карусельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карусельСПотерямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.транслитToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кнопкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стихиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodsGroupBox = new System.Windows.Forms.GroupBox();
            this.KeyLabel2 = new System.Windows.Forms.Label();
            this.KeyLabel1 = new System.Windows.Forms.Label();
            this.KeyTextBox2 = new System.Windows.Forms.TextBox();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.KeyTextBox1 = new System.Windows.Forms.TextBox();
            this.EditingTextBox = new System.Windows.Forms.TextBox();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.OriginalLabel = new System.Windows.Forms.Label();
            this.EditingLabel = new System.Windows.Forms.Label();
            this.MainMenuStrip.SuspendLayout();
            this.MethodsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalTextBox
            // 
            this.OriginalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OriginalTextBox.Location = new System.Drawing.Point(3, 20);
            this.OriginalTextBox.Multiline = true;
            this.OriginalTextBox.Name = "OriginalTextBox";
            this.OriginalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OriginalTextBox.Size = new System.Drawing.Size(480, 132);
            this.OriginalTextBox.TabIndex = 1;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.магияToolStripMenuItem,
            this.карусельToolStripMenuItem,
            this.карусельСПотерямиToolStripMenuItem,
            this.транслитToolStripMenuItem,
            this.кнопкаToolStripMenuItem,
            this.стихиToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(683, 24);
            this.MainMenuStrip.TabIndex = 2;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // магияToolStripMenuItem
            // 
            this.магияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шифроватьToolStripMenuItem,
            this.расшифроватьToolStripMenuItem});
            this.магияToolStripMenuItem.Name = "магияToolStripMenuItem";
            this.магияToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.магияToolStripMenuItem.Text = "Магия";
            // 
            // шифроватьToolStripMenuItem
            // 
            this.шифроватьToolStripMenuItem.Name = "шифроватьToolStripMenuItem";
            this.шифроватьToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.шифроватьToolStripMenuItem.Text = "Шифровать";
            this.шифроватьToolStripMenuItem.Click += new System.EventHandler(this.шифроватьToolStripMenuItem_Click);
            // 
            // расшифроватьToolStripMenuItem
            // 
            this.расшифроватьToolStripMenuItem.Name = "расшифроватьToolStripMenuItem";
            this.расшифроватьToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.расшифроватьToolStripMenuItem.Text = "Расшифровать";
            this.расшифроватьToolStripMenuItem.Click += new System.EventHandler(this.расшифроватьToolStripMenuItem_Click);
            // 
            // карусельToolStripMenuItem
            // 
            this.карусельToolStripMenuItem.Name = "карусельToolStripMenuItem";
            this.карусельToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.карусельToolStripMenuItem.Text = "Карусель";
            this.карусельToolStripMenuItem.Click += new System.EventHandler(this.карусельToolStripMenuItem_Click);
            // 
            // карусельСПотерямиToolStripMenuItem
            // 
            this.карусельСПотерямиToolStripMenuItem.Name = "карусельСПотерямиToolStripMenuItem";
            this.карусельСПотерямиToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.карусельСПотерямиToolStripMenuItem.Text = "Карусель с потерями";
            this.карусельСПотерямиToolStripMenuItem.Click += new System.EventHandler(this.карусельСПотерямиToolStripMenuItem_Click);
            // 
            // транслитToolStripMenuItem
            // 
            this.транслитToolStripMenuItem.Name = "транслитToolStripMenuItem";
            this.транслитToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.транслитToolStripMenuItem.Text = "Транслит";
            this.транслитToolStripMenuItem.Click += new System.EventHandler(this.транслитToolStripMenuItem_Click);
            // 
            // кнопкаToolStripMenuItem
            // 
            this.кнопкаToolStripMenuItem.Name = "кнопкаToolStripMenuItem";
            this.кнопкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.кнопкаToolStripMenuItem.Text = "Кнопка";
            this.кнопкаToolStripMenuItem.Click += new System.EventHandler(this.кнопкаToolStripMenuItem_Click);
            // 
            // стихиToolStripMenuItem
            // 
            this.стихиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.стихиToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.стихиToolStripMenuItem.Name = "стихиToolStripMenuItem";
            this.стихиToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.стихиToolStripMenuItem.Text = "Стихи";
            this.стихиToolStripMenuItem.Click += new System.EventHandler(this.стихиToolStripMenuItem_Click);
            // 
            // MethodsGroupBox
            // 
            this.MethodsGroupBox.Controls.Add(this.KeyLabel2);
            this.MethodsGroupBox.Controls.Add(this.KeyLabel1);
            this.MethodsGroupBox.Controls.Add(this.KeyTextBox2);
            this.MethodsGroupBox.Controls.Add(this.MethodComboBox);
            this.MethodsGroupBox.Controls.Add(this.KeyTextBox1);
            this.MethodsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.MethodsGroupBox.Name = "MethodsGroupBox";
            this.MethodsGroupBox.Size = new System.Drawing.Size(167, 103);
            this.MethodsGroupBox.TabIndex = 4;
            this.MethodsGroupBox.TabStop = false;
            this.MethodsGroupBox.Text = "Методы";
            // 
            // KeyLabel2
            // 
            this.KeyLabel2.AutoSize = true;
            this.KeyLabel2.Location = new System.Drawing.Point(6, 76);
            this.KeyLabel2.Name = "KeyLabel2";
            this.KeyLabel2.Size = new System.Drawing.Size(42, 13);
            this.KeyLabel2.TabIndex = 9;
            this.KeyLabel2.Text = "Ключ 2";
            // 
            // KeyLabel1
            // 
            this.KeyLabel1.AutoSize = true;
            this.KeyLabel1.Location = new System.Drawing.Point(6, 50);
            this.KeyLabel1.Name = "KeyLabel1";
            this.KeyLabel1.Size = new System.Drawing.Size(33, 13);
            this.KeyLabel1.TabIndex = 8;
            this.KeyLabel1.Text = "Ключ";
            // 
            // KeyTextBox2
            // 
            this.KeyTextBox2.Location = new System.Drawing.Point(51, 73);
            this.KeyTextBox2.Name = "KeyTextBox2";
            this.KeyTextBox2.Size = new System.Drawing.Size(110, 20);
            this.KeyTextBox2.TabIndex = 7;
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "Шифр Цезаря",
            "Аффинный шифр",
            "Гаммирование",
            "Сеть Фейстеля",
            "RC4"});
            this.MethodComboBox.Location = new System.Drawing.Point(7, 20);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(154, 21);
            this.MethodComboBox.TabIndex = 6;
            this.MethodComboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // KeyTextBox1
            // 
            this.KeyTextBox1.Location = new System.Drawing.Point(51, 47);
            this.KeyTextBox1.Name = "KeyTextBox1";
            this.KeyTextBox1.Size = new System.Drawing.Size(110, 20);
            this.KeyTextBox1.TabIndex = 5;
            // 
            // EditingTextBox
            // 
            this.EditingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditingTextBox.Location = new System.Drawing.Point(3, 20);
            this.EditingTextBox.Multiline = true;
            this.EditingTextBox.Name = "EditingTextBox";
            this.EditingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EditingTextBox.Size = new System.Drawing.Size(480, 139);
            this.EditingTextBox.TabIndex = 5;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplitContainer.Location = new System.Drawing.Point(185, 27);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.OriginalLabel);
            this.MainSplitContainer.Panel1.Controls.Add(this.OriginalTextBox);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.EditingLabel);
            this.MainSplitContainer.Panel2.Controls.Add(this.EditingTextBox);
            this.MainSplitContainer.Size = new System.Drawing.Size(486, 311);
            this.MainSplitContainer.SplitterDistance = 145;
            this.MainSplitContainer.TabIndex = 6;
            // 
            // OriginalLabel
            // 
            this.OriginalLabel.AutoSize = true;
            this.OriginalLabel.Location = new System.Drawing.Point(4, 4);
            this.OriginalLabel.Name = "OriginalLabel";
            this.OriginalLabel.Size = new System.Drawing.Size(89, 13);
            this.OriginalLabel.TabIndex = 2;
            this.OriginalLabel.Text = "Исходный текст";
            // 
            // EditingLabel
            // 
            this.EditingLabel.AutoSize = true;
            this.EditingLabel.Location = new System.Drawing.Point(1, 4);
            this.EditingLabel.Name = "EditingLabel";
            this.EditingLabel.Size = new System.Drawing.Size(88, 13);
            this.EditingLabel.TabIndex = 6;
            this.EditingLabel.Text = "Конечный текст";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 350);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MethodsGroupBox);
            this.Controls.Add(this.MainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(611, 228);
            this.Name = "MainForm";
            this.Text = "Магическая магия мистера Мэджика";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MethodsGroupBox.ResumeLayout(false);
            this.MethodsGroupBox.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox OriginalTextBox;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox MethodsGroupBox;
        private System.Windows.Forms.TextBox KeyTextBox1;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.ToolStripMenuItem магияToolStripMenuItem;
        private System.Windows.Forms.TextBox EditingTextBox;
        private System.Windows.Forms.ToolStripMenuItem транслитToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шифроватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расшифроватьToolStripMenuItem;
        private System.Windows.Forms.TextBox KeyTextBox2;
        private System.Windows.Forms.Label KeyLabel2;
        private System.Windows.Forms.Label KeyLabel1;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Label OriginalLabel;
        private System.Windows.Forms.Label EditingLabel;
        private System.Windows.Forms.ToolStripMenuItem карусельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem карусельСПотерямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кнопкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стихиToolStripMenuItem;
    }
}

