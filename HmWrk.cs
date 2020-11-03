using System;


namespace HomeWork {

    public class HW_1     //6
    {
        //1
        public static void Questionnaire()
        {
            string fName, lName;
            int y, h, m;

            Console.WriteLine("Введите имя:");
            fName = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            lName = Console.ReadLine();

            Console.WriteLine("Введите возраст:");
            try
            {
                y = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                y = 0;
            }

            Console.WriteLine("Введите рост:");
            try
            {
                h = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                h = 0;
            }

            Console.WriteLine("Введите вес:");
            try
            {
                m = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                m = 0;
            }

            Console.WriteLine("Конкатенация или сложение строк:");
            Console.WriteLine("Имя: " + fName + ", фамилия: " + lName + ", возраст: " + y + ", рост: " + h + ", вес: " + m + "\n");

            Console.WriteLine("с использование форматирования:");
            Console.WriteLine("Имя: {0}, фамилия: {1}, возраст: {2}, рост: {3}, вес: {4}\n", fName, lName, y, h, m);

            Console.WriteLine("используя вывод со знаком '$':");
            Console.WriteLine($"Имя: {fName}, фамилия: {lName}, возраст: {y}, рост: {h}, вес: {m}");
        }

        //2
        public static void IMT()
        {
            int m;
            float h;
            string st;

            Console.WriteLine("Введите вес");
            try
            {
                m = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                m = 0;           
            }

            Console.WriteLine("Введите рост в метрах, например '1,65'");
            st = Console.ReadLine();
            try
            {
                h = float.Parse(st.Replace('.', ','));
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                h = 0;           
            }

            Console.WriteLine(m / (h * h));
        }

        //3
        public static void DistanceHW()
        {
            int x1, x2, y1, y2;

            Console.WriteLine("Введите координату x1");
            try
            {
                x1 = int.Parse(Console.ReadLine());
            }
            catch 
            {
                Console.WriteLine("  значение некорректно!");
                x1 = 0;
            }

            Console.WriteLine("Введите координату x2");
            try
            {
                x2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                x2 = 0;
            }

            Console.WriteLine("Введите координату y1");
            try
            {
                y1 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                y1 = 0;            
            }

            Console.WriteLine("Введите координату y2");
            try
            {
                y2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                y2 = 0;
            }


            double m = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine(m);
        }

        //4
        public static void ExVar() {
            int one, two;

            Console.WriteLine("Введите значение первой переменной");
            try
            {
                one = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                one = 0;
            }
            Console.WriteLine("Введите значение второй переменной");
            try
            {
                two = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("  значение некорректно!");
                two = 0;
            }

            ExWith(one, two);
            ExWithout(one, two);

        }
        private static void ExWith(int one, int two)
        {
            int tmp;

            Console.WriteLine("Метод с использованием третьей переменной:");
            Console.WriteLine($"до обмена one - {one}, two - {two}");
            tmp = two;
            two = one;
            one = tmp;
            Console.WriteLine($"после обмена one - {one}, two - {two}");
        }
        private static void ExWithout(int one, int two)
        {
            Console.WriteLine("Метод без использования третьей переменной:");
            Console.WriteLine($"до обмена one - {one}, two - {two}");
            one += two;
            two = (two - one) * -1;
            one -= two;
            Console.WriteLine($"после обмена one - {one}, two - {two}");
        }

        //5
        public static void ShowCenterScreen()
        {
            string fName = "Валентин";
            string lName = "Прямов";
            string City = "п.Берещино";
            string fullSt = $"Имя: {fName}, фамилия: {lName}, город: {City}";
            int tp = Console.WindowHeight / 2;
            int lf = (Console.WindowWidth - fullSt.Length) / 2;

            Console.Clear();
            Console.SetCursorPosition(lf, tp);
            Console.WriteLine(fullSt);
         }
        public static void PrintHW()
        {
            int x, y;

            Console.WriteLine("Введите сообщение:");
            string ms = Console.ReadLine();

            Console.WriteLine("Введите координату по оси X:");
            try
            {
                x = int.Parse(Console.ReadLine());
            }
            catch
            {
                x = 0;           
            }

            Console.WriteLine("Введите координату по оси Y:");
            try
            {
                y = int.Parse(Console.ReadLine());
            }
            catch
            {
                y = 0;
            }

            Console.Clear();
            if (x + ms.Length > Console.WindowWidth)
            {
                Console.WriteLine("Текст был смещен влево, т.к. он выходил за пределы координат консоли");
                x = Console.WindowWidth - ms.Length;
            }
            
            Console.SetCursorPosition(x, y);
            Console.WriteLine(ms);
        }

    }

}
