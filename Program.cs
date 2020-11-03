using System;
using HomeWork;   //пространство имен со статическим классом, содержащий статические методами по практической работе к первому занятию

    class Program
    {
        static void Main()
        {
            while (true) {
                char R;

                Console.Clear();
                Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                                  "1 - запуск программы 'Анкета'\n" +
                                  "2 - расчет индекса массы тела\n" +
                                  "3 - расчет расстояния между точками координат\n" +
                                  "4 - обмена значениями между двумя переменными\n" +
                                  "5 - вывод строки в центре экрана\n" +
                                  "6 - вывод строки в заданном месте по координатам\n" +
                                  "для выхода нажмите 'q'\n");

                try
                {
                    R = char.Parse(Console.ReadLine());
                }
                catch
                {
                    R = ' ';
                }

                switch (R) {
                case '1':
                    HW_1.Questionnaire();
                    break;
                case '2':
                    HW_1.IMT();
                    break;
                case '3':
                    HW_1.DistanceHW();
                    break;
                case '4':
                    HW_1.ExVar();
                    break;
                case '5':
                    HW_1.ShowCenterScreen();
                    break;
                case '6':
                    HW_1.PrintHW();
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
