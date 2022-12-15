using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CaesarEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            key.Text = "Введите ключ";
            key.ForeColor = Color.Gray;
        }

        #region Закрытие формы
        private void LabelClose_Click(object sender, EventArgs e) => Application.Exit();
        private void LabelClose_MouseEnter(object sender, EventArgs e) => labelClose.ForeColor = Color.Red; 
        private void LabelClose_MouseLeave(object sender, EventArgs e) => labelClose.ForeColor = Color.White;
        #endregion

        #region Перемещение формы 
        Point point;
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e) => point = new Point(e.X, e.Y);
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }
        private void Panel2_MouseDown(object sender, MouseEventArgs e) => point = new Point(e.X, e.Y);
        private void Label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }
        private void Label5_MouseDown(object sender, MouseEventArgs e) => point = new Point(e.X, e.Y);
        #endregion

        #region Подсказки для пользователя

        /// <summary>
        /// Подсказка "Введите текст"
        /// </summary>
        private void Text_MouseEnter(object sender, EventArgs e)
        {
            if (text.Text == "Введите текст")
            {
                text.Text = " ";
                text.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Подсказка "Введите текст"
        /// </summary>
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            if (text.Text == " ")
            {
                text.Text = "Введите текст";
                text.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Подсказка "Введите ключ"
        /// </summary>
        private void Key_MouseEnter(object sender, EventArgs e)
        {
            if (key.Text == "Введите ключ")
            {
                key.Text = " ";
                key.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Подсказка "Введите ключ"
        /// </summary>
        private void Key_MouseLeave(object sender, EventArgs e)
        {
            if (key.Text == " ")
            {
                key.Text = "Введите ключ";
                key.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Кнопки

        /// <summary>
        /// Отчистка всех полей
        /// </summary>>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            text.Text = " ";
            key.Text = " ";
            Result.Text = " ";
            LanguageBox.SelectedIndex = -1;
        } 

        /// <summary>
        /// Выполнение алгоритма
        /// </summary>   
        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string Text = text.Text;
                int Key = Convert.ToInt32(key.Text);
                int number;
                int bias;
                string res;
                int j;

                char[] alphabet =
                {
                  'а', 'б', 'в', 'г', 'д',
                  'е', 'ё', 'ж', 'з', 'и',
                  'й', 'к', 'л', 'м', 'н',
                  'о', 'п', 'р', 'с', 'т',
                  'у', 'ф', 'х', 'ц', 'ч',
                  'ш', 'щ', 'ъ', 'ы', 'ь',
                  'э', 'ю', 'я'
                };
                char[] Alphabet =
                { 
                  'А', 'Б', 'В', 'Г', 'Д',
                  'Е', 'Ё', 'Ж', 'З', 'И',
                  'Й', 'К', 'Л', 'М', 'Н',
                  'О', 'П', 'Р', 'С', 'Т',
                  'У', 'Ф', 'Х', 'Ц', 'Ч',
                  'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',
                  'Э', 'Ю', 'Я'
                };

                char[] english_alphabet =
                {
                  'a', 'b', 'c', 'd', 'e',
                  'f', 'g', 'h', 'i', 'j',
                  'k', 'l', 'm', 'n', 'o',
                  'p', 'q', 'r', 's', 't',
                  'u', 'v', 'w', 'x', 'y',
                  'z',
                };
                char[] English_Alphsbet =
                {
                  'A', 'B', 'C', 'D', 'E',
                  'F', 'G', 'H', 'I', 'J',
                  'K', 'L', 'M', 'N', 'O',
                  'P', 'Q', 'R', 'S', 'T',
                  'U', 'V', 'W', 'X', 'Y',
                  'Z'
                };

                char[] txt = Text.ToCharArray();
                int selected = LanguageBox.SelectedIndex;

                switch (selected)
                {
                    case 0:
                        {                            
                            if (Key >= 33)
                                MessageBox.Show("Ключ не может быть больше 32!");
                            else
                            {
                                for (int i = 0; i < txt.Length; i++)
                                {
                                    for (j = 0; j < alphabet.Length; j++)
                                    {
                                        if (txt[i] == alphabet[j])
                                            break;
                                    }

                                    if (j != 33)
                                    {
                                        number = j;
                                        bias = number + Key;

                                        if (bias > 32)
                                            bias -= 33;

                                        txt[i] = alphabet[bias];
                                    }
                                }

                                for (int i = 0; i < txt.Length; i++)
                                {
                                    for (j = 0; j < Alphabet.Length; j++)
                                    {
                                        if (txt[i] == Alphabet[j])
                                            break;
                                    }

                                    if (j != 33)
                                    {
                                        number = j;
                                        bias = number + Key;

                                        if (bias > 32)
                                            bias -= 33;

                                        txt[i] = Alphabet[bias];
                                    }
                                }
                                res = new string(txt);
                                Result.Text = Convert.ToString(res);
                                File.WriteAllText("Result.txt", res);
                                MessageBox.Show("Результат ещё записан в файл ''Result.txt''", "Результат");
                            }
                        }
                        break;

                    case 1:
                        {
                            if (Key >= 26)
                                MessageBox.Show("Ключ не может быть больше 25!");
                            else
                            {
                                for (int i = 0; i < txt.Length; i++)
                                {
                                    for (j = 0; j < english_alphabet.Length; j++)
                                    {
                                        if (txt[i] == english_alphabet[j])
                                            break;
                                    }

                                    if (j != 26)
                                    {
                                        number = j;
                                        bias = number + Key;

                                        if (bias > 25)
                                            bias -= 26;

                                        txt[i] = english_alphabet[bias];
                                    }
                                }

                                for (int i = 0; i < txt.Length; i++)
                                {
                                    for (j = 0; j < English_Alphsbet.Length; j++)
                                    {
                                        if (txt[i] == English_Alphsbet[j])
                                            break;
                                    }

                                    if (j != 26)
                                    {
                                        number = j;
                                        bias = number + Key;

                                        if (bias > 25)
                                            bias -= 26;

                                        txt[i] = English_Alphsbet[bias];
                                    }
                                }
                                res = new string(txt);
                                Result.Text = Convert.ToString(res);
                                File.WriteAllText("Result.txt", res);
                                MessageBox.Show("Результат ещё записан в файл ''Result.txt''", "Результат");
                            }
                        }
                        break;
                }
            }
            catch (FormatException) 
            {
                MessageBox.Show("Введенно некорректное значение в поле!", "Ошибка");
            }
        } 
        #endregion

        /// <summary>
        /// Загрузка текста из файла при загрузке формы
        /// </summary>
        private void Form1_Load(object sender, EventArgs e) => text.Text = File.ReadAllText("Text.txt");
    }
}
