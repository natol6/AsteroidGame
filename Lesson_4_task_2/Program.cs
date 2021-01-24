using System;
using System.Collections.Generic;
using System.Linq;

/*
 Урок 4. Задание 2.
Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
для целых чисел;
* для обобщенной коллекции;
** используя Linq.
 */


namespace Lesson_4_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создаем список целых чисел
            List<int> intList = new List<int>();
            Random rnd = new Random();
            Console.WriteLine("Сгенерированный массив целых чисел:\n");
            for (int i = 0; i < 30; i++)
            {
                intList.Add(rnd.Next(1, 11));
                Console.Write($"{intList[i]} ");
            }
            //Для списка целых чисел создаем частотный массив целых чисел
            int max = intList[0];
            for (int i = 1; i < intList.Count; i++)
            {
                if (intList[i] > max) max = intList[i];
            }
            int[] freqArr = new int[max +1];
            for (int i = 0; i < intList.Count; i++)
            {
                freqArr[intList[i]] += 1;
            }
            //выводим результат подсчета
            Console.WriteLine("\n\nЧастота повторений элементов в массиве целых чисел (выполнено с помощью частотного массива):\n");
            for (int i = 0; i < freqArr.Length; i++)
            {
                if(freqArr[i] > 0) Console.WriteLine($"{i} - {freqArr[i]} ");
            }
            //2. В качестве примера создадим список User
            List<User> userList = new List<User>();
            int j;
            Console.WriteLine("Сгенерированный список людей:\n");
            for (int i = 0; i < 30; i++)
            {
                j = rnd.Next(1, 11);
                userList.Add(new User($"Имя-{j}", $"Фамилия-{j}"));
                Console.WriteLine($"{i + 1}. {userList[i].ToString()}");
                
            }
            //Для обобщенного списка создаем частотный словарь, где ключем будет строковое представление объекта
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string str;
            for (int i = 0; i < userList.Count; i++)
            {
                str = userList[i].ToString();
                if (dic == null || !dic.ContainsKey(str)) dic.Add(str, 1);
                else dic[str] += 1;
            }
            //выводим результат подсчета
            Console.WriteLine("\n\nЧастота повторений людей в списке (выполнено с помощью частотного словаря):\n");
            foreach (KeyValuePair<string, int> us in dic)
            {
                Console.WriteLine($"{us.Key} - {us.Value}");
            }
            //3. Применим linq для подсчета количества повторений в целочисленном массиве
            var intQuantity = from intQ in intList
                              group intQ by intQ into q
                              orderby q.Key
                              select new { Value = q.Key, Count = q.Count() };
                              
                //intList.GroupBy(x => x).OrderBy(x => x);
            Console.WriteLine("\n\nЧастота повторений элементов в массиве целых чисел (выполнено с помощью запроса linq):\n");
            foreach (var i in intQuantity)
            {
                Console.WriteLine($"{i.Value} - {i.Count}");
            }
            var userQuantity = from user in userList
                               group user by user.ToString() into us
                               orderby us.Key
                               select new { UserToStr = us.Key, Count = us.Count() };
            Console.WriteLine("\n\nЧастота повторений людей в списке (выполнено с помощью запроса linq):\n");
            foreach (var i in userQuantity)
            {
                Console.WriteLine($"{i.UserToStr} - {i.Count}");
            }
        }
    }
}
