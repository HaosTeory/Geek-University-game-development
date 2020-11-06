using System;
using HomeWork;   

class Program
{
    static void Main()
    {
        while (true)
        {
            HW_2.Cls();
            Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                              "1 - метод, возвращающий минимальное из трех чисел\n" +
                              "2 - метод подсчета количества цифр числа\n" +
                              "3 - цикл подсчета сумму всех нечетных положительных чисел\n" +
                              "4 - метод проверки логина и пароля\n" +
                              "5 - индекс массы тела\n" +
                              "6 - программу подсчета количества 'Хороших' чисел\n" +
                              "7 - рекурсивный метод подсчета суммы чисел\n" +
                              "для выхода нажмите 'q'\n");


            char R = Console.ReadKey().KeyChar;

            switch (R)
            {
                case '1':
                    HW_2.MinValue();
                    break;
                case '2':
                    HW_2.SummDigit();
                    break;
                case '3':
                    HW_2.Loop();
                    break;
                case '4':
                    HW_2.Autoriz();
                    break;
                case '5':
                    HW_2.IMT();
                    break;
                case '6':
                    HW_2.GoodDigit();
                    break;
                case '7':
                    HW_2. MetodReck();
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Недопустимое значение");
                    break;

            }

            Console.WriteLine("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();
        };

    }

}
