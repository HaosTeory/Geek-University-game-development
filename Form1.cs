using System;
using System.Windows.Forms;

namespace HomeWork_7
{
    //2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100,
    //   а человек пытается его угадать за минимальное число попыток. Для ввода данных от человека используется
    //   элемент TextBox.


    public partial class FGuess : Form
    {
        Random rnd = new Random();    //рандом
        int RndDigit;                 //рандомное число
        int TryCount = 0;             //кол-во попыток

        public FGuess()
        {
            InitializeComponent();
            tbEdit.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        void NewGame()             //инициализация новой игры
        {
            MessageBox.Show("Я загадал число, попробуйте угадать!", "Игра началась!");
            RndDigit = rnd.Next(0, 100);
            TryCount = 0;
            lMinMax.Text = " ";
            ChangeEx();                   //изменяет текст контролов
            tbEdit.Enabled = true;
        }

        void ChangeEx() 
        {
            lblCount.Text = TryCount.ToString();
            tbEdit.Text = "0";
        }

        void TextMinMax(int r)      //метка с подсказкой, "меньше, больше"
        {
            if (r < RndDigit)
            {
                lMinMax.Text = "Нужно больше, чем сейчас!";
            }
            else
            {
                lMinMax.Text = "Нужно меньше, чем сейчас!";
            }

        }

        private void tbEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;  //not enter
            int.TryParse(tbEdit.Text, out int r);

            if (r != RndDigit)             //не угадал
            {
                TryCount++;
                TextMinMax(r);
            }
            else                           //угадал
            {
                ShowModal();
            }
            ChangeEx();
        }

        void ShowModal() 
        {
            if (MessageBox.Show($"Ваш счет: {TryCount}!\nНачать новую игру?", "Вы победили!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                NewGame();
            }
            else 
            {
                Close();
            }
        }

        private void tbEdit_KeyUp(object sender, KeyEventArgs e)   //обнулить textBox, если ввели некорректное значение
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || tbEdit.Text == "") tbEdit.Text = "0";
        }

    }

}
