using System;
using System.Text;
using System.IO;


namespace HomeWork
{
    class TestCreateFile
    {
        public void Create(int mode = 0)
        {
            StreamWriter sw = new StreamWriter("test.dat", false, Encoding.UTF8);   //для кирилицы

            if (mode == 0)
                sw.WriteLine("12646\n45321\n54684\ndsdgs\n");
            else
                sw.WriteLine("root\nGeekBrains");

            sw.Flush();
            sw.Close();
        }

    }

    //1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000
    //   включительно. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно
    //   число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива
    //   из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
    public struct SimpleArray
    {
        int[] Arr;

        void ArrInit() 
        {
            Random rnd = new Random();
            for (int i = 0; i < Arr.Length; i++)
                Arr[i] = rnd.Next(-10000, 10000);
        }

        public SimpleArray(int count)    //конструктор с защитой от дурака
        {
            if (count <= 0) count = 1;
            
            Arr = new int[count];
            ArrInit();
        }

        public void ArrayWithTwo()
        {
            if (Arr.Length == 0) return;
            int result = 0;
            for (int i = 0; i < Arr.Length; i++)
                if (i+1 < Arr.Length  &&  Arr[i]%3 == 0  && Arr[i+1] % 3 == 0) result++; 

            Console.WriteLine($"Кол-во пар элементов массива: {result}\n");
        }

        public void Print()    
        {
            for (int i = 0; i < 10; i++)
                Console.Write($" [{i}] {Arr[i]};");
        }

        public void Demo() 
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы эксемпляра класса Hw:");
            ArrayWithTwo();
            Print();
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }

    //2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной размерности
    //      и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которые возвращают сумму
    //      элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент
    //      массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. В Main
    //      продемонстрировать работу класса.
    //   б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    class MyArray
    {
        public int MaxInd;                //индекс в котором хранится максимальное значение,
        public int MinInd;                // а тут минимальное
        private int[] Arr;

        public MyArray(int count, int start = 0, int step = 1)
        {
            if (count <= 0) count = 1;
            Arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                Arr[i] = start;           //создать массив заданной размерности,
                start += step;            //  и заполняющий массив числами от начального значения с заданным шагом
            }

        }
        public MyArray(string path)       //перегруженный конструктор, загружает в массив данные из файла
        {
            LoadFile(path);
        }

        public int Length
        {
            get{ return Arr.Length; }
        }
        public double Sum
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < Arr.Length; i++)
                    sum += Arr[i];

                return sum;
            }
        }
        public int Max
        {
            get
            {
                int max = Arr[0];
                for (int i = 1; i < Arr.Length; i++)
                    if (Arr[i] > max)
                    {
                        max = Arr[i];
                        MaxInd = i;
                    }
                return max;
            }

        }
        public int Min
        {
            get
            {
                int min = Arr[0];
                for (int i = 1; i < Arr.Length; i++)
                    if (Arr[i] < min)
                    {
                        min = Arr[i];
                        MinInd = i;
                    }
                return min;
            }
        }
        public int MaxCount              //количество элементов максимального значения
        {
            get
            {
                int m = Max;
                int result = 0;

                for (int i = 0; i < Arr.Length; i++)
                    if (Arr[i] == m) result++;

                return result;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Arr.Length; i++)
                for (int j = 0; j < Arr.Length - 1; j++)
                    if (Arr[j] > Arr[j + 1])//Сравниваем соседние элементы
                    {
                        //  Обмениваем элементы местами
                        int t = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = t;
                    }
        }
        public void Print()
        {
            for (int i = 0; i < Arr.Length; i++)
                Console.Write($" [{i}] {Arr[i]};");

        }
        public void Inverse()
        {
            for (int i = 0; i < Arr.Length; i++) 
                Arr[i] = Arr[i] * -1;

        }
        public void Multi(int count)
        {
            if (count <= 0) count = 1;

            Random rn = new Random();
            for (int i = 0; i < Arr.Length; i++) 
                Arr[i] *= rn.Next(count);

        }
        public void LoadFile(string path)         //загрузка из файла в массив
        {
            if (string.IsNullOrEmpty(path) && !File.Exists(path))
            {
                Console.WriteLine("Error load file");
                return;
            }
            int i = 0;
            StreamReader sr = new StreamReader(path);
            int count = File.ReadAllLines(path).Length;
            Array.Resize(ref Arr, count);

            while (!sr.EndOfStream) 
            {
                int.TryParse(sr.ReadLine(), out Arr[i]);
                i++;
            }

            sr.Close();

        }
        public void SaveFile(string path)         //сохранение в файл из массив
        {
            if (String.IsNullOrEmpty(path) || Arr.Length == 0) return;

            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);   //для кирилицы

            for (int i = 0; i < Arr.Length; i++)
                sw.WriteLine(Arr[i]);

            sw.Flush();
            sw.Close();

        }

        public void Demo()
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы эксемпляра класса MyArray:");
            Console.WriteLine("  начальный массив:   ");
            Print();
            
            Console.WriteLine("\n\n  смена знаков на противоположные:   ");
            Inverse();
            Print();
            
            Console.WriteLine("\n\n  сортировка:   ");
            Sort();
            Print();
            
            new TestCreateFile().Create();              //создали файл для теста
            
            Console.WriteLine("\n\n  загружаем данные из файла - ");
            LoadFile("test.dat");
            Print();
            
            int i = 3;
            Console.WriteLine($"\n\n  умножение каждого элемента на случайное число от 0 до число {i} - ");
            Multi(i);
            Print();

            
            Console.WriteLine("\n\n   сохраняем данные в файле - ");
            SaveFile("test.dat");
            Print();

            Console.WriteLine("\n\nДемонстрация закончена.");
        }

    }

    //3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.Создайте структуру
    //   Account, содержащую Login и Password.
    public struct Account
    {
        string[] Arr;

        public bool Autoriz(string path)
        {
            Arr = new string[2];

            if (string.IsNullOrEmpty(path) || File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                Arr = File.ReadAllLines(path);
                if (Arr[0].ToLower().Trim() == "root" && Arr[1] == "GeekBrains")
                {
                    Console.WriteLine("Access granted!");
                    return true;
                };
                sr.Close();
            }
            else
            {
                Console.WriteLine($"File {path} not found!");
                return false;
            }

            Console.WriteLine("Access failed!");
            return false;
        }

        public void Demo() 
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы эксемпляра класса Account:");
            new TestCreateFile().Create(1);    //1 - файл со строками root/GeekBrains;  0 - набор чисел 
            Autoriz("test.dat");
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }

    //4. *а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
    //       Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного,
    //       свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
    //       возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
    //   *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //       Дополнительные задачи
    //    в) Обработать возможные исключительные ситуации при работе с файлами.
    class TwoLevelArray            
    {
        MyArray[] Arr;             //массив объектов MyArray, в принципе там уже реализован весь функционал, методы данного класса
                                   //  обернуты вокруг методов MyArray с небольшими дополнениями

        int MinInd;                //индекс минимальноего элемента
        int MaxInd;                //индекс максимального элемента

        public int Min             //свойство, возвращающее минимальный элемент массива
        {
            get
            {
                int min = 10000;
                for (int i = 0; i < Arr.Length; i++)
                {
                    int tmp = Arr[i].Min;
                    if ( tmp < min)
                    {
                        min = tmp;
                        MinInd = i;
                    }

                }
                return min;
            }
        }
        public int Max             //свойство, возвращающее максимальный элемент массива,
        {
            get
            {
                int max = 0;
                for (int i = 0; i < Arr.Length; i++)
                {
                    int tmp = Arr[i].Max;
                    if ( tmp > max)
                    {
                        max = tmp;
                        MaxInd = i;
                    }
                }
                return max;
            }
        }

        public TwoLevelArray(int count, int rand = 10)    //аргументы: длина "основного" массива, диапазон случайностей генератора чисел
        {
            Random rn = new Random();
            Arr = new MyArray[count];                     //массив из "нашего" класса MyArray

            for (int i = 0; i < Arr.Length; i++)          
                Arr[i] = new MyArray(rn.Next(0, rand), step: rn.Next(0, rand));      //рандомная инициализация массивов в массиве, длина от 0 до rand

        }

        public double Summ(int big = 0)                   //метод, который возвращает сумму всех элементов массива,
        {                                                 //  и сумму всех элементов массива больше заданного (опционально)
            double result = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                double s = Arr[i].Sum;
                if (s > big) result += s;
            }

            return result;
        }
        public void MaxValue(out string ind)              //метод, возвращающий номер максимального элемента массива
        {                                                 //  (через параметры, используя модификатор ref или out)
            int m = Max;
            ind = $" {m}, находится в ({MaxInd},{Arr[MaxInd].MaxInd})";
        }

        public void MinValue(out string ind)              //метод, возвращающий номер минимального элемента массива
        {                                                 //  (через параметры, используя модификатор ref или out), нет в задании
            int m = Min;
            ind = $" {m}, находится в ({MinInd},{Arr[MinInd].MinInd})";
        }

        //Обработка возможных исключительных ситуаций при работе с файлами реализована внутри класса MyArray,
        //  данные методы чтения/запси юзают методы чтения/записи MyArray
        public void LoadFile(string path, int ind)        //путь к файлу и индекс массива для записи
        {
            if (ind >= Arr.Length) return;
            Arr[ind].LoadFile(path);          
        }
        public void SaveFile(string path, int ind)        //путь к файлу для записи и индекс массива для записи
        {
            if (ind >= Arr.Length) return;
            Arr[ind].SaveFile(path);
        }

        public void Print()
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write($"[{i}]: ");
                Arr[i].Print();
                Console.Write("\n");
            }
        
        }

        public void Demo()
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы эксемпляра класса TwoLevelArray:");

            Print();

            double d = Summ();
            Console.WriteLine($"Cумма всех элементов массива: {d}");

            MaxValue(out string s);
            Console.WriteLine($"максимальный элемент массива: {s}");

            MinValue(out string m);
            Console.WriteLine($"минимальный элемент массива: {m}");

            Console.WriteLine("\nДемонстрация закончена.");
        }

    }

}
