using System;
using System.Collections.Generic;
using HomeWork;

class Program
{
    private delegate void Action();  

    static void Main()
    {
        SimpleArray fc = new SimpleArray(10);
        MyArray Arr = new MyArray(20, step: 7);
        Account acc = new Account();
        TwoLevelArray tla = new TwoLevelArray(5);

        Dictionary<string, Action> _list = new Dictionary<string, Action>
        {
            { "1", fc.Demo                        },        
            { "2", Arr.Demo                       },
            { "3", acc.Demo                       },
            { "4", tla.Demo                       },
            { "q", () => { Environment.Exit(0); } },
        };

        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                              "1 - Демонстрация первого задания (SimpleArray)\n" +
                              "2 - Демонстрация второго задания (MyArray)\n" +
                              "3 - Демонстрация третьего задания (Account)\n" +
                              "4 - Демонстрация четвертого задания (TwoLevelArray)\n" +
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
