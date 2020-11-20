using System;
using System.IO;
using System.Collections.Generic;



namespace HomeWork
{
    //1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). Продемонстрировать работу на функции
    //   с функцией a*x^2 и функцией a*sin(x).
    public class TableFunctions
    {
        public delegate double Fun(double x, double y);

        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double x, double a)
        {
            return a * x * x;
        }
        public static double MyFuncSin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        public void DemoDlg() 
        {
            Console.WriteLine("Таблица функции MyFunc:");     
            Table(MyFunc, -2, 2);

            Console.WriteLine("Таблица функции Sin:");
            Table(MyFuncSin, -2, 2);      

            Console.WriteLine("Таблица функции x^2:");
            Table(delegate (double x, double y) { return x * x; }, 0, 3); 

        }

    }

    //2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //   а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
    //   б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
    //   в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.

    class MinFnc
    {
        //словарь с делегатами, инициализируем словарь с использованием лямбда-выражениями с сигнатурой делегата
        private Dictionary<int, Func<double, double>> _dict = new Dictionary<int, Func<double, double>>
        {
            { 0, (double x)=>{ return x * x - 50 * x + 10; }    },
            { 1, (double x)=>{ return x * x + 50 * x - 10; }    },
            { 2, (double x)=>{ return x * x + 0.5f * x;    }    },
        };

        struct Prop
        {
            double fStart;
            double fFinish;
            double fStep;
            int fMode;

            public double Start
            {
                get{return fStart;}

            }
            public double Finish
            {
                get { return fFinish; }

            }
            public double Step
            {
                get { return fStep; }

            }
            public int Mode
            {
                get { return fMode; }

            }

            public void StartInit(string s) 
            {
                double.TryParse(s, out fStart);
            }
            public void FinishInit(string s)
            {
                double.TryParse(s, out fFinish);
            }
            public void StepInit(string s)
            {
                double.TryParse(s, out fStep);
            }
            public void ModeInit(string s)
            {
                int.TryParse(s, out fMode);
            }

        }
 
        void SaveFunc(string fileName, double start, double finish, double step, Func<double, double> dlg)
        {
            if (dlg == null)
            {
                Console.WriteLine("Ссылка на метод отсутствует!"); 
                return;
            }
            if (step == 0)
            {
                Console.WriteLine("Шаг не может быть равен 0!");
                return;           //если шаг = 0, будет зацикливание
            }

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (start <= finish)
            {              
                bw.Write(dlg(start));
                start += step;               
            }
            bw.Close();
            fs.Close();
        }
        List<double> Load(string fileName)
        {
            List<double> _list = new List<double>();

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < min) _list.Add(d);
            }
            bw.Close();
            fs.Close();
            return _list;           // возвращаем массив значений
        }
        void Print(List<double> lst) 
        {
            foreach (var cc in lst)
                Console.WriteLine(cc);
        }

        public void ExcutionMinFnc() 
        {
            string[] str;

            Console.Clear();
            Console.WriteLine("Введите начало, конец, шаг, режим функции (от 0 до 2) через пробел");
            string s = Console.ReadLine();
            Console.Clear();
            str = s.Split(' ');

            Prop pr = new Prop();
            
            pr.StartInit(str.Length > 1 ? str[0] : "0");
            pr.FinishInit(str.Length > 2 ? str[1] : "0");
            pr.StepInit(str.Length > 3 ? str[2] : "0");
            pr.ModeInit(str.Length > 4 ? str[3] : "0");

            SaveFunc("data.bin", pr.Start, pr.Finish, pr.Step, _dict.ContainsKey(pr.Mode) ? _dict[pr.Mode] : null);
            Print(Load("data.bin"));
        }

    }

    //3. Переделать программу «Пример использования коллекций» для решения следующих задач:
    //   а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    //   б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
    //   в) отсортировать список по возрасту студента;
    //   г) * отсортировать список по курсу и возрасту студента;
    //   д) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;

        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class Students 
    {
        int NameFilter(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }
        int AgeFilter(Student st1, Student st2)
        {
            return String.Compare(Convert.ToString(st1.age), Convert.ToString(st2.age));
        }
        int CourceAndAgeFilter(Student st1, Student st2)
        {
            return String.Compare(Convert.ToString(st1.course + st1.age), Convert.ToString(st2.course + st2.age));
        }

        public void StudentsExecute()
        {
            int bakalavr = 0;
            int magistr = 0;
            int course = 0;
            int[] CourceArr = new int[6];                //инфа по курсам

            if (!File.Exists("students_6.csv"))
            {
                Console.WriteLine("Файл не найден!");
                return;
            }

            List<Student> list = new List<Student>();    // Создаем список студентов
            List<Func<Student, Student, Int32>> _filters = new List<Func<Student, Student, int>>(3);

            _filters.Add(NameFilter);
            _filters.Add(AgeFilter);
            _filters.Add(CourceAndAgeFilter);


            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                    if (int.Parse(s[4]) == 5 || int.Parse(s[4]) == 6) course++;           //кол-во на 5 и 6 курсах
                    if (int.Parse(s[8]) >= 18 && int.Parse(s[8]) <= 20) CourceArr[int.Parse(s[4])-1]++;   //от 18 до 20 лет на каждом курсе

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            if (list.Count == 0) 
            {
                Console.WriteLine("Файл с данными пуст!");
                return;
            }

            Console.WriteLine("Как отфильтровать?  0 - FirstName, 1 - Age, 2 - Course And Age");
            string str = Console.ReadLine();

            int.TryParse(str, out int mode);

            if (mode < 0) mode = 0;
            else if (mode > _filters.Count-1) mode = _filters.Count-1;     //если что-то с клавы ввели не так

            list.Sort(new Comparison<Student>(_filters[mode]));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine($"Студентов на 5 и 6 курсах: {course}") ;
            for (int i = 0; i < CourceArr.Length; i++)
                Console.WriteLine($"На {i+1} курсе: {CourceArr[i]} человек.");
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();

        }

    }

}
