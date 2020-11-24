using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeWork_7
{
    //1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
    //   б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
    //      Игрок должен постараться получить это число за минимальное количество ходов.
    //   в) * Добавить кнопку «Отменить», которая отменяет последние ходы.

    public partial class FDoubler : Form
    {
        Random _rnd = new Random();
        Stack<int> _stack = new Stack<int>();
        int _ComCount = 0;                                //кол-во команд
        int _NeedNum = 0;
        int _Num = 0;

        public FDoubler()  //инициализируем форму
        {
            InitializeComponent();
            AllCntrlDis(false);         //диактивируем все контролы

            lblNeedNum.Text = "0";
            lblNumber.Text = "0";
            lblComCount.Text = "0";
                                        //все наши метки невидимы, до начала игры
            lblNeedNum.Visible = false;
            lblNumber.Visible = false;
            lblComCount.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
        }
 
        void btnCommand_Click(object sender, EventArgs e)      //один эвент на два кнопки
        {
            if ((sender as Button).Name == "btnCommand1")
            {
                ChangeLblNum(_Num += 1);
            }
            else
            {
                ChangeLblNum(_Num *= 2);
            };

            _stack.Push(int.Parse(lblNumber.Text));             //записываем в стек
            ComCountEx(true);                                   //увеличиваем шаг текущего действия
            PrepBtn();
            CheckWin();
        }

        private void btnReset_Click(object sender, EventArgs e)  //обнуляемся
        {
            _stack.Clear();           
            ChangeLblNum(0);          

            _ComCount = 0;
            lblComCount.Text = _ComCount.ToString();
            btnCancel.Enabled = false;
        }

        private void игратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int i = 0;

            _stack.Pop();
            if (_stack.Count != 0) 
                i = _stack.Peek();      //удаляем и выозвращем верхний(последний) записанное число

            ChangeLblNum(i);            //изеняем это значение в метку
            ComCountEx(false);          //отнимаем 1 ход
            PrepBtn();
        }

        void ChangeLblNum(int n) 
        {
            _Num = n;
            lblNumber.Text = n.ToString();
        }

        void AllCntrlDis(bool mode) 
        {
            btnCommand1.Enabled = mode;
            btnCommand2.Enabled = mode;
            btnReset.Enabled = mode;
            btnCancel.Enabled = mode;
        }

        void ComCountEx(bool mode) 
        {
            if (mode) _ComCount++;
            else _ComCount--;
            lblComCount.Text = _ComCount.ToString();
        }

        void PrepBtn() 
        {
            btnCancel.Enabled = (_stack.Count != 0);
        }

        void CheckWin() 
        {
            if (_NeedNum == _Num) 
                if (MessageBox.Show($"Кол-во ходов: {_ComCount}!\nНачать новую игру?", "Вы победили!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    NewGame();
                }
                else
                {
                    Close();
                }
        }

        void NewGame()          //инициализация новой игры
        {
            _NeedNum = _rnd.Next(0, 100);
            _stack.Clear();

            ChangeLblNum(0);

            lblNeedNum.Text = _NeedNum.ToString();
            lblComCount.Text = "0";

            lblNeedNum.Visible = true;
            lblNumber.Visible = true;
            lblComCount.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;

            MessageBox.Show($"Вы должны получить это число: {_NeedNum}", "Удвоитель");

            AllCntrlDis(true);
            PrepBtn();

        }
    }


}
