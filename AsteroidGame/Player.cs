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
            this.Nik = "Инкогнито";
            this.DateRecord = DateTime.Now;
            this.Record = 0;
        }
        public Player(string nik, DateTime dateRecord, int record)
        {
            this.Nik = nik;
            this.DateRecord = dateRecord;
            this.Record = record;
        }
        
        public static bool Equals(Player p1, Player p2)
        {
            return p1.Nik == p2.Nik && p1.DateRecord == p2.DateRecord && p1.Record == p2.Record;
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
