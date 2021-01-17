using System;
using System.Collections.Generic;
using System.Text;

namespace Personnel
{
    class BaseEmployee
    {
        protected string Surname { get; init; }
        protected string Name { get; init; }
        protected string MiddleName { get; init; }
        protected string Position { get; set; }
        public BaseEmployee(string surname, string name, string middleName, string position)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            Position = position;
        }
       
        /*abstract public double AverageMonthlySalary();
        protected virtual double FactorPay()
        {
            ListPosition pos = new ListPosition();
            pos.Load("position.csv");
            for (int i = 0; i < pos.Count; i++)
            {
                if (pos[i].Pos == this.position) return pos[i].FactorPay;
            }
            return -1;
        }
        public static int FioUp(BaseEmployee w1, BaseEmployee w2)          // Метод для сравнения по ФИО (сортировка по возрастанию)
        {
            int compare = String.Compare(w1.Surname_, w2.Surname_);
            if (compare == 0)
            {
                compare = String.Compare(w1.Name_, w2.Name_);
                if (compare == 0) compare = String.Compare(w1.MiddleName_, w2.MiddleName_);
            }
            return compare;
        }
        public static int FioDown(BaseEmployee w1, BaseEmployee w2)          // Метод для сравнения по ФИО (сортировка по убыванию)
        {
            int compare = String.Compare(w1.Surname_, w2.Surname_) * (-1);
            if (compare == 0)
            {
                compare = String.Compare(w1.Name_, w2.Name_) * (-1);
                if (compare == 0) compare = String.Compare(w1.MiddleName_, w2.MiddleName_) * (-1);
            }
            return compare;
        }
        public string ToString(BaseEmployee w)
        {
            return this.Surname_ + " " + this.Name_ + " " + this.MiddleName_ + " " + this.Position_;
        }*/

    }
}
