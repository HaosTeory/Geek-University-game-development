using System;
using System.Collections.Generic;
using HomeWork;

class Program
{
    private delegate void Action();

    static void Main()
    {
        TableFunctions tf = new TableFunctions();
        MinFnc mf = new MinFnc();
        Students std = new Students();

        Dictionary<string, Action> _list = new Dictionary<string, Action>
        {
            { "1", tf.DemoDlg                     },
            { "2", mf.ExcutionMinFnc              },
            { "3", std.StudentsExecute            },
            { "q", () => { Environment.Exit(0); } },
        };


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                              "1 - Демонстрация первого задания (TableFunctions)\n" +
                              "2 - Демонстрация второго задания (MinFnc)\n" +
                              "3 - Демонстрация третьего задания (Students)\n" +
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
