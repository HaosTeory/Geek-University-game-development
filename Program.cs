using System;
using System.Collections.Generic;
using HomeWork;


//учел замечания, избавился от статики, поправил синтаксис
class Program
{
    private delegate void Action();         //объявим делегат с сигнатурой void(void)

    static void Main()
    {
        Hw HmWr = new Hw();                     //создаем экземпляры классов
        Complex cm = new Complex();
        Fractions fr = new Fractions();
         
        Dictionary<string, Action> _list = new Dictionary<string, Action>  
        {
            { "1", cm.DemoComplex                 },        //словарь с ссылками на методы
            { "2", HmWr.Loop                      },        
            { "3", fr.DemoFractions               },
            { "q", () => { Environment.Exit(0); } },
        };


        while (true)
        {
            HmWr.Cls();
            Console.WriteLine("Для запуска опр. метода наберите одно из следующих значений:\n" +
                              "1 - Демонстрация структуры Complex\n" +
                              "2 - цикл подсчета сумму всех нечетных положительных чисел\n" +
                              "3 - Демонстрация класса Fractions(дроби)\n" +
                              "для выхода нажмите 'q'\n");


            string R = Console.ReadLine();
            R = R.ToLower();
            HmWr.Cls();

            if (_list.ContainsKey(R))
                _list[R]();                   //вызов метода по ключу R
            else
                Console.WriteLine("Недопустимое значение");

            Console.WriteLine("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();
        };

    }

}
