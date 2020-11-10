using System;

namespace HomeWork
{
    //Задание №1
    // а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
    // б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;
    struct Complex
    {
        public double re;   //действительная часть 
        public double im;   //мнимая часть

        public Complex(double im, double re)            //создадим конструктор для инициализации данных
        {
            this.im = im;
            this.re = re;
        }

        public Complex Plus(in Complex x)               //передаем структуру в виде константной ссылки
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }           
        public Complex Minus(in Complex x)
        {
            Complex y;
            y.im = re - x.im;
            y.re = re - x.re;
            return y;
        }
        public Complex Multi(in Complex x)
        {
            Complex y;
            y.re = re * x.re - im * x.im;
            y.im = im * x.re + re * x.im;
            return y;
        }
        public Complex Division(in Complex x)
        {
            Complex y;
            if (x.im != 0 && x.re != 0)        //если произедение im и re равно 0,
            {
                y.im = (re * x.re + im * x.im) / (x.re * x.re + x.im * x.im);   // то в знаменатели будет 0, а на ноль делить нельзя
                y.re = (im * x.re - re * x.im) / (x.re * x.re + x.im * x.im);
            }
            else
            {
                y.im = im;
                y.re = re;
            }

            return y;
        }

        public override string ToString()
        {
            return re + "+" + im + "i";
        }
        public void DemoComplex()
        {
            Complex complex1 = new Complex(1, 1);           //данные по умолчанию
            Complex complex2 = new Complex(2, 2);   

            Console.WriteLine("\nДемонстрация метода Plus:");
            Complex result = complex1.Plus(in complex2);
            Console.WriteLine(result.ToString());

            Console.WriteLine("\nДемонстрация метода Minus:");
            result = complex1.Minus(in complex2);
            Console.WriteLine(result.ToString());

            Console.WriteLine("\nДемонстрация метода Multi:");
            result = complex1.Multi(in complex2);
            Console.WriteLine(result.ToString());

            Console.WriteLine("\nДемонстрация метода Division:");
            result = complex1.Division(in complex2);
            Console.WriteLine(result.ToString());
        }

    }

    //Задание №2
    // а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
    //    Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран,
    //    используя tryParse;
    // б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
    //    При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
    public class Hw
    {
        public void Cls()
        {
            Console.Clear();
        }

        public void Loop()
        {
            int Result = 0;

            Console.WriteLine("Введи число\n" +
                              "в сумму чисел учитываются положительные, нечетные числа: ");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out int Value);    //тут и так все исключения обрабатываются, 
                if (Value == 0)                                     //  если не может конвертировать вернет 0
                    break;
                else if (Value > 0 && Value % 2 != 0)
                    Result += Value;

            };
            Console.WriteLine($"\nСумма введенных чисел: {Result}");

        }
    }

    //Задание №3
    // 3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
    //    Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу,
    //    демонстрирующую все разработанные элементы класса.
    //    ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    //    Добавить упрощение дробей.
    public struct Fractions
    {
        int n;              //целая часть
        int c;              //числитель
        int z;              //знаменатель
        public int C        //свойство: числитель (целое число)
        {                   
            get { return c; }                           //хоть дробь типа 0/4 существует, по сути это просто 0, 
            set { if (value != 0) c = value; }          //  но мы таких дробей не допустим
        }                                               
        public int Z        //свойство: знаменатель (натуральное число)
        {                   
            get { return z; }                      //вместо написания проверки знаменателя, напишем сеттер с обработкой так лучше думаю,
            set { if (value > 0) z = value; }      //  чем в каждом методе вызывать метод проверки на исключение
        }                                          

        public Fractions(int c = 1, int z = 1)
        {
            n = 0;
            this.c = c;
            this.z = z;
        }

        int GetNOK(in int f, in int s)      //НОК - наименьшее общее кратное
        {
            int i = f > s ? f : s;          //начнем с наибольшего из двух

            //тупо перебираем значения от i, пока не найдем НОК, это проще чем придумывать какой-то супер алгоритм и потеть, пусть процессор потеет,
            //  хотя для него это пустяки
            while (true)
            {
                if (i % f == 0 && i % s == 0)
                    return i;
                else i++;
            }

        }

        void Simple()                       //упрощение дробей: т.е дробь 7/21 - это 1/3, и с выделением целой части, например 8/5 - это 1 целая 3/5
        {
            if (c > z)
            {
                n = c / z;
                c -= z * n;
            }

            if (c == 0)
            {
                z = 0;
            }
            else
            {
                int[] Arr = { 7, 5, 3, 2 };
                int i = 0;

                while (i < Arr.Length)
                {
                    if (c % Arr[i] == 0 && z % Arr[i] == 0)
                    {
                        c /= Arr[i];
                        z /= Arr[i];
                    }
                    else i++;

                }
            }
        }


        public Fractions Plus(ref Fractions x)
        {
            Fractions tmp = new Fractions();
 
            if (z == x.z)       //с одинаковыми знаменателями
            {
                tmp.c = c + x.c;
                tmp.z = z;
            }
            else                //с разными знаменателями
            {
                int nok = GetNOK(z, x.z);
                int n1 = nok/z;             //приведение относительно НОК для числителя первой дроби
                int n2 = nok/x.z;           //приведение относительно НОК для числителя второй дроби

                tmp.c = c*n1 + x.c*n2;
                tmp.z = nok;                //приведение знаменателя к НОК
            }
                  
            tmp.Simple();
            return tmp;
        }
        public Fractions Minus(ref Fractions x)    //алгоритм эдентичен сложению, почти
        {
            Fractions tmp = new Fractions();

            if (z == x.z)
            {
                tmp.c = c - x.c;
                tmp.z = z;
            }
            else
            {
                int nok = GetNOK(z, x.z);
                int n1 = nok / z;
                int n2 = nok / x.z;

                tmp.c = c * n1 - x.c * n2;
                tmp.z = nok;
            }


            tmp.Simple();
            return tmp;
        }
        public Fractions Multi(ref Fractions x)
        {
            Fractions tmp = new Fractions();

            tmp.c = c * x.c;
            tmp.z = z * x.z;
            tmp.Simple();
            return tmp;
        }
        public Fractions Division(ref Fractions x)  //алгоритм эдентичен умножению, почти
        {
            Fractions tmp = new Fractions();

            tmp.c = c * x.z;
            tmp.z = z * x.c;
            tmp.Simple();
            return tmp;
        }


        public string Print()
        {
            //выводим целую часть| числитель/знаменатель
            string sn = n != 0 ? $"{n}|" : "";
            string sc = c != 0 ? $"{c}/" : "";
            string sz = z != 0 ? $"{z}"  : "";
            return $"{sn} {sc}/{sz}";
        }

        public void DemoFractions()
        {
            Fractions one = new Fractions(z:2);           //по именованому аргументу
            Fractions two = new Fractions(z:6);
            
            Console.WriteLine("\nСложение дробей:");
            Fractions result = one.Plus(ref two);
            Console.WriteLine(result.Print());
            
            Console.WriteLine("\nВычитание дробей:");
            result = one.Minus(ref two);
            Console.WriteLine(result.Print());
            
            Console.WriteLine("\nУмножение дробей:");
            result = one.Multi(ref two);
            Console.WriteLine(result.Print());
            
            Console.WriteLine("\nДеление дробей:");
            result = one.Division(ref two);
            Console.WriteLine(result.Print());
            
        }

    }

}
