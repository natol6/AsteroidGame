using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4_task_2
{
    class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public User(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }
        public override string ToString()
        {
            return "Имя: " + Name +", Фамилия: " + SurName +".";
        }
    }
}
