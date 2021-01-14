using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class Player: IComparable<Player>
    {
        public string Nik { get; set; }
        public DateTime DateRecord { get; set; }
        public int Record { get; set; }
        public Player()
        {
            Nik = "Инкогнито";
            DateRecord = DateTime.Now;
            Record = 0;
        }
        public Player(string nik, DateTime dateRecord, int record)
        {
            Nik = nik;
            DateRecord = dateRecord;
            Record = record;
        }
        
        public bool Equals(Player p1, Player p2)
        {
            if (p1 == null || p2 == null) return false;
            else return p1.Nik == p2.Nik && p1.DateRecord == p2.DateRecord && p1.Record == p2.Record;
        }
        public int CompareTo(Player p)
        {
            if (this.Record > p.Record)
                return 1;
            if (this.Record < p.Record)
                return -1;
            else
                return 0;
        }
    }
}
