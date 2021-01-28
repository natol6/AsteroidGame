using System;
using System.Collections.Generic;
using System.Linq;

/*
 *Урок 4. Задание 3.
 *а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
b. * Развернуть обращение к OrderBy с использованием делегата .

 */

namespace Lesson_4_task_3
{
    class Program
    {
        public delegate int Odb(KeyValuePair<string, int> kvp);
        static void Main(string[] args)
        {
            //Исходный код программы
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            //Использование лямбда-выражения
            Dictionary<string, int> dict1 = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d1 = dict1.OrderBy(d => d.Value);
            Console.WriteLine("Сортировка с использованием лямбда-выражения в запросе linq:");
            foreach (var pair in d1)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            //Использование делегата
            //public delegate KeyValuePair<TKey,TValue>.Value Odb(KeyValuePair<TKey, TValue>);
            Odb sort = delegate (KeyValuePair<string, int> pair) { return pair.Value; };
            Dictionary<string, int> dict2 = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d2 = dict2.OrderBy(dict2 => sort);
            Console.WriteLine("Сортировка с использованием развернутого делегата в запросе linq:");
            foreach (var pair in d2)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

        }
    }
}
