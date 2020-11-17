using System;
using System.Collections.Generic;
using HomeWork;

class Program
{
    private delegate void Action();

    static void Main()
    {
        SimpleLogin sl = new SimpleLogin();
        Swop sw = new Swop();
        EG eg = new EG();
        GameTrueOrNot game = new GameTrueOrNot();

        Dictionary<string, Action> _list = new Dictionary<string, Action>
        {
            { "1", sl.SimpleLoginDemo             },
            { "2", Message.CorrectDemo            },
            { "3", sw.SwopDemo                    },
            { "4", eg.EGDemo                      },
            { "5", game.GameDemo                  },
            { "q", () => { Environment.Exit(0); } },
        };

        

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                              "1 - Демонстрация первого задания (SimpleLogin)\n" +
                              "2 - Демонстрация второго задания (Message)\n" +
                              "3 - Демонстрация третьего задания (Swop)\n" +
                              "4 - Демонстрация четвертого задания (EG)\n" +
                              "5 - Демонстрация пятого задания (GameTrueOrNot)\n" +
                              "для выхода нажмите 'q'\n");


            string R = Console.ReadLine();
            R = R.ToLower();
            Console.Clear();

            if (_list.ContainsKey(R))
                _list[R]();
            else
                Console.WriteLine("Недопустимое значение");

            Console.WriteLine("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();
        };

    }

}
