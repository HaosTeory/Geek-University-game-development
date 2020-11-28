using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HomeWork_8
{
    //2. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».

    public partial class frmTrueOrNotGame : Form
    {
        int GameIterator;          //индекс для database
        int Count;                 //кол-во угаданных вопросов
        TrueFalse database;
        public frmTrueOrNotGame()
        {
            InitializeComponent();
            pnlPanel.Enabled = false;
        }

        private void btnMouseEnter(object sender, EventArgs e)      
        {
            if (sender is Button) (sender as Button).ForeColor = Color.DeepSkyBlue;
            if (sender is ToolStripMenuItem) (sender as ToolStripMenuItem).ForeColor = Color.DeepSkyBlue;
        }

        private void btnMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button) (sender as Button).ForeColor = Color.Black;
            if (sender is ToolStripMenuItem) (sender as ToolStripMenuItem).ForeColor = Color.Black;
        }

        private void miNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void NewGame()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.ReadAllLines(ofd.FileName).Length == 0)
                {
                    MessageBox.Show("Файл пуст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                };

                database = new TrueFalse();
                database.Load(ofd.FileName);
                pnlPanel.Enabled = true;
                GameIterator = 0;
                Count = 0;
                NextQuestion();    //запускает цикл вопросов
            }

        }

        void StopGame() 
        {
            rtbQuestion.Clear();
            pnlPanel.Enabled = false;
            MessageBox.Show($"Ваш результат: {Count} из {GameIterator}.", "Игра закончена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void NextQuestion() 
        {
            if (GameIterator >= database.Count) StopGame();
            else rtbQuestion.Text = database[GameIterator].Text;          
        }

        private void btnClick(object sender, EventArgs e)      //метод для события для кнопок btnTrue b btnFalse
        {
            bool mode = (sender as Button).Name == "btnTrue";
            if (database[GameIterator].TrueFalse == mode) Count++;
            GameIterator++;
            NextQuestion();
        }

    }
}
