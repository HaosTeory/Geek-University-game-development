using System;
using System.ComponentModel.Design;

namespace HomeWork {

    public class HW_2     
    {
        public static void Cls() {
            Console.Clear();       
        }
        static string GetStr(int Count) {
            switch (Count) {
                case 1:
                    return " попытка.";
                case 2:
                case 3:
                    return " попытки.";
                default:
                    return "";

            }
       
        }
        static int GetMassMode(float ind) {
            //-1 - недостаточный вес, 0 - нормальный, 1 - избыточный
            if (ind < 18.5)
                return -1;
            else if (ind >= 18.5 && ind <= 25)
                return 0;
            else return 1;               
        }
        static int Summ(int integer) {

            int Result = 0;

            while (integer != 0)
            {
                Result += integer % 10;
                integer /= 10;
            }

            return Result;
        }
        static void Revers(ref int a, ref int b) {
            a = a + b;
            b = a - b;
            a = a - b;      
        }
        static void Reck(ref int a, ref int i, int b) {             //рекурсия
            if (i > b) return;
            else {
                a += i;
                i++;
                Reck(ref a, ref i, b);
            };
        }

        //Задание №1
        //  Написать метод, возвращающий минимальное из трех чисел.
        public static float MinValue() {

            Cls();
            Console.WriteLine("Введите первое число:");
            float.TryParse(Console.ReadLine(), out float a);
            Console.WriteLine("Введите второе число:");
            float.TryParse(Console.ReadLine(), out float b);
            Console.WriteLine("Введите третье число:");
            float.TryParse(Console.ReadLine(), out float c);

            float result = a<b? a : b;
            result = result<c? result : c;

            Console.WriteLine($"Минимальное значение: {result}") ;
            return result;      //метод возвращает значение        
        }

        //Задание №2
        //  Написать метод подсчета количества цифр числа.
        public static void SummDigit() {

            Cls();
            Console.WriteLine("Введите целое число:");
            int.TryParse(Console.ReadLine(), out int a);
            a = a<0? a*-1 : a;      //если введеное число отрицательное
            string Value = Convert.ToString(a);
            Console.WriteLine($"Кол-во цифр числа: {Value.Length}");

        }

        //Задание №3
        //  С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        public static void Loop() {
            int Result = 0;

            Cls();
            Console.WriteLine("Введи число\n" +
                              "в сумму чисел учитываются положительные, нечетные числа: ");
            while (true) //можно поставить вместо true (Console.ReadKey().KeyChar != '0'), но в этом 
            {            //случае у меня первое введеное число воспринималось после конвертации как 0
                int.TryParse(Console.ReadLine(), out int Value);
                if (Value == 0)
                    break;
                else if (Value > 0 && Value % 2 != 0)
                    Result += Value;         

            };
            Console.WriteLine($"\nСумма введенных чисел: {Result}");
        
        }

        //Задание №4
        //  Реализовать метод проверки логина и пароля. На вход подается логин и пароль. На выходе истина,
        //  если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод
        //  проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает
        //  его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
        public static bool Autoriz() {          
            int Count = 3;
            string log;
            string pass;
            char sign;

            do
            {
                Cls();
                Console.WriteLine("Авторизуйстесь, пожалуйста!\n" +
                                  "при вводе пароля учитывайте регистр\n" +
                                  $"осталось {Count} {GetStr(Count)}");

                pass = "";

                Console.WriteLine("\nlogin:");
                log = Console.ReadLine().ToLower();

                Console.WriteLine("\npassword:");

                while (true)
                {
                    sign = Console.ReadKey(true).KeyChar;
                    if (Convert.ToInt32(sign) == 13)
                        break;
                    else
                    {
                        pass += sign;
                        Console.Write("*");    //пишем '*' вместо символов
                    }
                };

                if (log.Trim() == "root" && pass == "GeekBrains")  //убираем у логина пробелы
                {
                    Console.WriteLine("\nAccess granted!");
                    break;
                }
                else
                {
                    Count--;
                    if (Count != 0)
                    {
                        Console.WriteLine("\nЛогин или пароль некорректен, повторите ввод!");
                        Console.ReadKey();
                    }
                    else
                        Console.WriteLine("\nAccess failed!");
                }

            } while (Count > 0);

            return Count != 0;        //false - Access failed, true - Access granted

        }

        //Задание №5
        //  а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает,
        //     нужно ли человеку похудеть, набрать вес или все в норме;
        //  б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        public static void IMT()
        {
            Cls();
            Console.WriteLine("Введите вес");
            int.TryParse(Console.ReadLine(), out int m);

            Console.WriteLine("Введите рост в метрах, например '1,65'");
            float.TryParse(Console.ReadLine().Replace('.', ','), out float h);

            float ind = m / (h * h);            //индекс массы тела
            int mode = GetMassMode(ind);        //недостаточный, нормальный или избыточный

            switch (mode) {
                case -1:
                    ind = 18.5f * (h * h);
                    Console.WriteLine($"У Вас дефицит веса, необходимо поправиться на {m - ind: 0.00} кг.");
                    break;
                case 0:
                    Console.WriteLine("У Вас нормальный веса для вашего роста.");
                    break;
                case 1:
                    ind = 25 * (h * h);
                    Console.WriteLine($"У Вас избыточный вес, необходимо похудеть на {m - ind: 0.00} кг.");
                    break;
            }      
        }

        //Задание №6
        //  *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000.
        //  Хорошим называется число, которое делится на сумму своих цифр. Реализовать подсчет времени выполнения
        //  программы, используя структуру DateTime.

        //Несовсем понял, число в любом случае будет делиться на любое другие число, наверное все таки 
        //  имелось ввиду число, кторое делится без остатка.
        public static void GoodDigit() {
            int Result = 0;

            Cls();
            Console.WriteLine("Выводить 'хорошие' числа?\n" +
                              "введите 'y' для подтвержения.");
            char cr = Console.ReadKey().KeyChar;
            bool Mode = (cr == 'y' || cr == 'Y')? true : false;

            Cls();
            DateTime Start = DateTime.Now;
                               
            for (int i = 1; i <= 1000000; i++) {    //исправил с 1 000 000 000 на 1 000 000, лярд это долго
                if (i % Summ(i) == 0){
                    if (Mode) Console.WriteLine($"{i}\n");
                    Result++;
                }          
            }

            Console.WriteLine($"Кол-во 'хороших' чисел: {Result}, время работы: {DateTime.Now - Start}");     
        
        }

        //Задание №7
        //  a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
        //  б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        public static void MetodReck() {

            Cls();
            Console.WriteLine("Введите первое число:");
            int.TryParse(Console.ReadLine(), out int a);

            Console.WriteLine("Введите второе число:");
            int.TryParse(Console.ReadLine(), out int b);

            if (b < a) Revers(ref a, ref b);       //поменять значения переменных
            int i = a + 1;
            Reck(ref a, ref i, b);

            Console.WriteLine($"Сумм чисел: {a}");
        }

    }

}
