using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace HomeWork_8
{
    //1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных,
    //      обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    //   б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические»
    //      улучшения на свое усмотрение.
    //   в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    //   г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
    //   д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).

    public partial class frmTrueOrNotDesigner : Form
    {
        TrueFalse database;
        Form frm2;                  //окно "О программе"
        Label lbl;                  //метка на окне "О программе"

        public frmTrueOrNotDesigner()
        {
            InitializeComponent();
            PrepGame(false);
        }

        void PrepGame(bool mode)  //активируем или деактивируем
        {
            pnlCntrls.Enabled = mode;
            miSave.Enabled = mode;
            miSaveAs.Enabled = mode;
        }

        private void btnMouseEnter(object sender, EventArgs e)    //на все элементы один метод
        {
            if (sender is Button) (sender as Button).ForeColor = Color.DeepSkyBlue;
            if (sender is ToolStripMenuItem) (sender as ToolStripMenuItem).ForeColor = Color.DeepSkyBlue;
        }

        private void btnMouseLeave(object sender, EventArgs e)    //на все элементы один метод
        {
            if (sender is Button) (sender as Button).ForeColor = Color.Black;
            if (sender is ToolStripMenuItem) (sender as ToolStripMenuItem).ForeColor = Color.Black;
        } 


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tboxQuestion.Text == "") return;

            database.Add(tboxQuestion.Text, cboxTrue.Checked);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;

            if (MessageBox.Show("Вы уверены, что хотите удалить последний вопрос?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                database.Remove((int)nudNumber.Value);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;

            }

        }

        private void btnSaveQuest_Click(object sender, EventArgs e)
        {

            if (database == null || (int)nudNumber.Value - 1 >= database.Count) return;

            database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse();
                database.Add("test qustion", false);
                database.Save(sfd.FileName);
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                PrepGame(true);
            };
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse();
                database.Load(ofd.FileName);
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                PrepGame(true);
            }

        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save(database.FileName);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database == null || (int)nudNumber.Value - 1 >= database.Count) return;

            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }

        //в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
        private void miAbout_Click(object sender, EventArgs e)
        {
            if (frm2 == null)  //создаем форму через код, только один раз чтобы не уничтожать и создавать каждый раз
            {                  
                frm2 = new Form();                                      
                frm2.Size = new Size() { Width = 250, Height = 150 };   //инициализируем свойства
                frm2.StartPosition = FormStartPosition.CenterScreen;
                frm2.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm2.MaximizeBox = false;
                frm2.MinimizeBox = false;
                frm2.Text = "О программе";
            }
            if (lbl == null) //создаем метку, так же как и форму - один раз
            {
                lbl = new Label();                                
                lbl.Top = 5;               //инициализируем свойства                             
                lbl.Left = 10;
                lbl.Size = new Size() { Width = 200, Height = 50 };
                lbl.Text = "Автор: Прямов Валентин\nVersion: 1.0\nAll Right Reserved";
                lbl.Parent = frm2;         //указываем парента, т.е. на чем будет располагаться элемент
            }

            frm2.ShowDialog();                             //показваем окно в диалоговом виде

        }

        private void miSaveAs_Click(object sender, EventArgs e)  //пересохранить файл
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) database.Save(sfd.FileName);
        }
    }

    [Serializable]
    public class Question
    {
        string _text;       // Текст вопроса
        bool _trueFalse;    // Правда или нет
                       
        public string Text 
        { 
            get { return _text; }
            set { _text = value; }
        }
        public bool TrueFalse
        {
            get { return _trueFalse; }
            set { _trueFalse = value; }
        }

        public Question() {}
        public Question(string text, bool trueFalse)
        {
            this._text = text;
            this._trueFalse = trueFalse;
        }
    }

    class TrueFalse
    {
        string _fileName;           //путь к файлу
        List<Question> list;        

        public string FileName { get { return _fileName; } }

        public TrueFalse()
        {
            list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }
        public void Save(string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load(string path)
        {
            if (!File.Exists(path)) return;

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
            _fileName = path;
        }
        public int Count
        {
            get { return list.Count; }
        }
    }


    //*Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
    // данный класс нигде в программе не используется, но можно прикрутить его метод к какому-нибудь событию контрола
    class ConvertCsvToXml 
    {
        List<Student> _listCSV;
        public void Example_Event(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы CSV (*.csv)|*.csv";          //фильтруем только для файлов CSV

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(ofd.FileName)) return;

                ReadCSV(ofd.FileName);            
                SaveXML(ofd.FileName);
            }

        }

        void ReadCSV(string FileName)      //считываем данные из файла, и сохраняем их в список
        {
            _listCSV = new List<Student>();        

            string[] rows = File.ReadAllLines(FileName);

            for (int i = 0; i < rows.Length; i++)
            {
                var Elements = rows[i].Split(';');

                Student dataFromCSV = new Student(rows[0], rows[1], rows[2], rows[3], rows[4], int.Parse(rows[5]),
                                                  int.Parse(rows[6]), int.Parse(rows[7]), rows[8]);

                _listCSV.Add(dataFromCSV);
            }
        }

        void SaveXML(string path)          //сохраняем лист со студентами используя сериализацию
        {
            path += ".xml";                //за основу берем то же путь к файлу, но немного изменняем его
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, _listCSV);
            fStream.Close();
        }
    }

    [Serializable]
    class Student      //класс Student из 6-го занятия
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int course;
        public int age;
        public int group;
        public string city;

        public Student(string fn, string ln, string u, string f, string d, int cr, int a, int g, string ct)
        {
            lastName = ln;
            firstName = fn;
            university = u;
            faculty = f;
            department = d;
            course = cr;
            age = a;
            group = g;
            city = ct;
        }
    }

}
