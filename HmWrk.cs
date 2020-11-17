using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace HomeWork
{

    //1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов,
    //   содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //   а) без использования регулярных выражений;
    //   б) с использованием регулярных выражений.
    class SimpleLogin
    {
        string log;
        public delegate bool LoginMetod(string str);     //делегат с сигнатурой bool(string)

        public void Login(LoginMetod metod)              //  в качестве ссылки на анонимный метод metod
        {
            if (metod == null) return;

            Console.WriteLine("Введите логин...\n" +
                              "условия для корректности логина:\n" +
                              "от 2 до 10 символов, только латинские символы или цифры\n, цифра не первый символ");
            while (true)
            {
                log = Console.ReadLine();
                if (metod(log))         //передаем аргумент и запускаем метод по ссылке
                    break;
                else
                    Console.WriteLine("Логин некорректен! Повторите ввод.");
            }

            Console.WriteLine("Логин корректен!");

        }           

        bool CheckLogin(string str)
        {
            if (str.Length < 2 || str.Length > 10)
            {
                Console.WriteLine("Количество символов в логине не соответствует требованиям!");
                return false;
            }

            //check isDigitOrLetter
            for (int i=0; i<str.Length; i++)
            {
                if ((str[i] < '0' || str[i] > '9') && (str[i] < 'a' || str[i] > 'z') && (str[i] < 'A' || str[i] > 'Z')) 
                {
                    Console.WriteLine("В логине присутствуют недопустимые символы!");
                    return false;
                }
            }

            if (char.IsDigit(str[0])) 
            {
                Console.WriteLine("Первый символ - цифра!");
                return false;
            }
            
            return true;

        }
        bool CheckLoginRegex(string str) 
        {
            Regex reg = new Regex(@"^[a-zA-Z\\x][0-9a-zA-Z]{1,9}");
            return reg.IsMatch(str);       
        }

        public void SimpleLoginDemo()
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы класса SimpleLogin:\n");
            Console.WriteLine("  без использования регулярных выражений:");
            Login(CheckLogin);
            Console.WriteLine("  c использованием регулярных выражений:");
            Login(CheckLoginRegex);
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }


    //2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    //   а) Вывести только те слова сообщения, которые содержат не более n букв.
    //   б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //   в) Найти самое длинное слово сообщения.
    //   г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //   Продемонстрируйте работу программы на текстовом файле с вашей программой.
    class Message
    {

        public static void CorrectDemo() 
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы класса Message:\n");
            Console.WriteLine("Введите символы, разделенные пробелами, для обработки:");

            string str = Console.ReadLine();
            string[] arr = str.Split(' ');

            CorrA(arr);
            CorrB(arr);
            CorrC(arr);

            Console.WriteLine("\nДемонстрация закончена.");
        }

        static void CorrA(string[] arr)
        {
            Console.WriteLine("Введите число.\n Будут выведены слова не превышающих длину данного числа.");
            string str = Console.ReadLine();

            int.TryParse(str, out int n);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length <= n) Console.WriteLine(arr[i]);
            }

        }
        static void CorrB(string[] arr)
        {
            Console.WriteLine("Введите символ.\n Будут выведены все слова не заканчивающие на данный символ.");
            char chr = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            for (int i = 0; i < arr.Length; i++) 
            {
                if (arr[i][arr[i].Length-1] != chr) Console.WriteLine(arr[i]);
            }

        }
        static void CorrC(string[] arr) 
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Самое(ые) длинное(ые) слово(а) сообщения:\n");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > count) count = arr[i].Length;
            }

            for (int i = 0; i < arr.Length; i++) 
            {
                if (sb.Length != 0) sb.Append(", ");
                if (arr[i].Length == count) sb.Append(arr[i]);
            }

            Console.WriteLine(sb);

        }

    }


    //3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
    //   а) с использованием методов C#;
    //   б) * разработав собственный алгоритм.
    //   Например: badc являются перестановкой abcd.
    class Swop 
    {
        //варианта а нет
        // только вариант б, иногда быстрее сделать что-то свое, чем искать
        public bool isSwop(string first, string second)
        {
            int a = 0;
            int b = 0; 

            //просто считаем их коды, и сравниваем
            for (int i = 0; i < first.Length; i++) a += first[i];
            for (int i = 0; i < second.Length; i++) b += second[i];

            if (a != b) Console.WriteLine("Не равны!");
            else Console.WriteLine("Равны!");

            return a == b; 
        }

        public void SwopDemo()
        {
            string[] str = new string[2];

            Console.Clear();
            Console.WriteLine("Демонстрация работы класса Swop:");
            Console.WriteLine(" проверим является ли слово перестановкой другого слова:\n");
            Console.WriteLine("Введите первое и второе слова, разделенные пробелом");
            string word = Console.ReadLine();
            str = word.Split(' ');
            Console.WriteLine("собственный алгоритм:");
            isSwop(str[0], str[1]);
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }


    //4. Задача ЕГЭ.
    //  * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается
    //  количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
    //  <Фамилия> <Имя> <оценки>, где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов,
    //  <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки>
    //  разделены одним пробелом.
    //  Пример входной строки: Иванов Петр 4 5 3
    //  Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу
    //  учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

    class EG    //может работать не только в системе от 3 до 5 баллов, но и с другими, например оценки могут быть от 0 до 100 и более
    {
        struct List
        {
            public string fName;  //имя
            public string lName;  //фамилия
            public int[] dig;     //массив оценок
            public float sred;    //средний балл
            public void SetSredBall()    //находим средний балл
            {
                float tmp = 0;
                int count = 0;

                for (int i = 0; i < dig.Length; i++) 
                {
                    tmp += dig[i];
                    count++;
                }

                sred = tmp / count;

            }
        }

        List[] lst;
        float Min1Ball = 10000;
        float Min2Ball = 10000;
        float Min3Ball = 10000;

        public void Prog(string path) 
        {
            if (!File.Exists(path) || File.ReadAllLines(path).Length == 0)
            {
                Console.WriteLine("Файл не найден, либо в нем нет информации");
                return;
            }

            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            int.TryParse(sr.ReadLine(), out int N);
            lst = new List[N];

            for (int i = 0; i < N; i++)
            {
                string s = sr.ReadLine();
                string[] str = s.Split(' ');

                lst[i].fName = str[0];
                lst[i].lName = str[1];
                lst[i].dig = new int[3];
                int.TryParse(str[2], out lst[i].dig[0]);
                int.TryParse(str[3], out lst[i].dig[1]);
                int.TryParse(str[4], out lst[i].dig[2]);
                lst[i].SetSredBall();
                if (lst[i].sred < Min1Ball) Min1Ball = lst[i].sred;       //находим самый минимальный средний балл

            }

            sr.Close();

            //находим минимальный средний балл, но больше чем предыдущий минимум
            SetMin(Min1Ball, ref Min2Ball);
            SetMin(Min2Ball, ref Min3Ball);

            int c = 3;

            //выводим имя и фамилию, у которых самый низкий средний балл, по условия задачи их моэет быть больше 3, если их меньше 3, то
            //  запускаем следующий метод, с другим наименьшим средним баллом, их так же, по условию задачи, может быть 
            //  больше чем остаток (int с), будем выводить всех кто равен этому среднему баллу
            //  ну и наконец, если остаток все еще не 0, и мы запускаем с третьем наименьшим балло, то поступаем эдентично предыдущим случаям
            PrintValue(Min1Ball, ref c);
            PrintValue(Min2Ball, ref c);    
            PrintValue(Min3Ball, ref c);
        }

        void SetMin(float MinSource, ref float MinRef)      //находим минимальный средний балл, но он должен быть больше чем MinSource
        {
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i].sred < MinRef && lst[i].sred > MinSource) MinRef = lst[i].sred;
            }
            
        }
        void PrintValue(float min, ref int c)        
        {                                            
            if (min == 10000 || c <= 0) return;             //выходим если переменная min не имеет минимального среднего балла
                                                            //  такая ситуация может быть, если например там у всех средний балл 4 или 5
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i].sred == min)
                {
                    Console.WriteLine($"{lst[i].fName} {lst[i].lName}, средний балл: {lst[i].sred}");
                    c--;
                }

            }

        }

        //может быть алгорит непонятен, но я постарался закоментить все ступени
        public void EGDemo()
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы класса EG:");
            Prog("test.txt");
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }


    //5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. Например: «Шариковую ручку изобрели в древнем Египте»,
    //   «Да». Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. Игрок отвечает Да или Нет на каждый вопрос
    //   и набирает баллы за каждый правильный ответ. Список вопросов ищите во вложении или воспользуйтесь интернетом.
    class GameTrueOrNot
    {
        struct List
        {
            public string question;
            public string answer;
        }

        readonly static int COUNT_QUESTION_IN_GAME = 5;    //число вопросов в игре, предполагается, что это так же минимальное кол-во вопросов в файле
        List[] _list;                                      
        int[] IndArr = new int[COUNT_QUESTION_IN_GAME];    //индексы _list, которые уже задавались в вопросах
        int point = 0;

        public void GameTrueOrNotInit(string path) 
        {
            if (!File.Exists(path) || File.ReadAllLines(path).Length == 0)
            {
                Console.WriteLine("Файл не найден, либо в нем нет информации");
                return;
            }

            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            int count = File.ReadAllLines(path).Length;           //померили все строки, 
            _list = new List[count];                              // инициализировали массив list'ов

            for (int i = 0; i < count; i++)
            {
                string s = sr.ReadLine();
                string[] str = s.Split(',');

                _list[i].question = str[0];
                _list[i].answer = str[1];
            }

            sr.Close();

            for (int i = 0; i < IndArr.Length; i++)   //по умолчанию все элементы массива = 0, но нам нужны -1
                IndArr[i] = -1;

        }

        public void StartGame() 
        {
            Random rnd = new Random();
            for (int i = 0; i < COUNT_QUESTION_IN_GAME; i++)
            {
                while (true)
                {
                    int n = rnd.Next(_list.Length);
                    if (!IsUse(n))   //проверка на совпадение индексов, если есть свопадение, значит рандомим новый индекс
                    {
                        Console.WriteLine($"\n{_list[n].question}");
                        Console.WriteLine("Да/Нет?");
                        string str = Console.ReadLine();

                        if (str.ToLower().Trim() == _list[n].answer.ToLower().Trim())   //переводим в нижний регистр, и убираем пробелы
                        {
                            AddArr(n);
                            point++;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine($"Ваш счет: {point}!");

        }

        void AddArr(int ind)    //записываем в массив индексы, которые уже использовались в вопросах
        {
            for (int i = 0; i < IndArr.Length; i++)
            {
                if (IndArr[i] == -1)
                {
                    IndArr[i] = ind;
                    break;
                }

            }

        }

        bool IsUse(int ind)     //проверка на совпадение индексов
        {
            for (int i = 0; i < IndArr.Length; i++)
                if (IndArr[i] == ind) return true;

            return false;
        }

        public void GameDemo()
        {
            Console.Clear();
            Console.WriteLine("Демонстрация работы класса GameTrueOrNot:");
            GameTrueOrNotInit("game.txt");
            StartGame();
            Console.WriteLine("\nДемонстрация закончена.");
        }

    }

}
