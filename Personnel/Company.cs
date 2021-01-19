using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Company
    {
        public string Title { get; set; }
        private StafArray _staff;
        private PositionArray _positions;
        public Company(string title)
        {
            Title = title;
            _staff = new StafArray(title);
            _positions = new PositionArray(title);
        }
        public Company()
        {
            Title = "Example";
            _staff = new StafArray("Example");
            _positions = new PositionArray("Example");
        }
        public static double FactorPay(string pos)
        {
            return 1; //надо реализовать метод
        }
        public void Save()
        {
            _staff.Save();
            _positions.Save();
        }
        public void Load()
        {
            _staff.Load(Title);
            _positions.Load(Title);
        }
        public void Add_Staff(BaseEmployee empl)
        {
            _staff.Add(empl);
        }
        public void Add_Position(Position pos)
        {
            _positions.Add(pos);
        }
        public void Remove_Staff(int index)
        {
            _staff.Remove(index);
        }
        public void Remove_Position(int index)
        {
            _positions.Remove(index);
        }
        public void Sort_Staff()
        {
            _staff.Sort();
        }
        public void Sort_Position()
        {
            _positions.Sort();
        }
        public bool Exists_Staff(BaseEmployee empl)
        {
            return _staff.Exists(empl);
        }
        public bool Exists_Position(Position pos)
        {
            return _positions.Exists(pos);
        }
        public string ToString_Staff()
        {
            return _staff.ToString();
        }
        public string ToString_Position()
        {
            return _positions.ToString();
        }

    }
}
