using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace AsteroidGame
{
    class Records//: IEnumerable<Records>
    {
        private List<Player> records;
        private readonly string fileName = "Records//records.json";
        private readonly string title = $"{"Игрок:",20}{"Дата:",33}{"Очки:",20}\n\n";
        private readonly string currentWinner = "{0,4}.      {1,-20}   {2,15:d}   {3,10}\n";
        private readonly string currentPlayer = "{0,4}.      {1,-20}   {2,15:d}   {3,10} - Ваш результат\n";
        public Records()
        {
            records = new List<Player>();
        }
        /*IEnumerator<Records> IEnumerable<Records>.GetEnumerator()
        {
            return records.GetEnumerator();
        }*/
        public void Add(Player p)
        {
            records.Add(p);
        }
        public void Remove(int index)
        {
            if (records != null && index < records.Count && index >= 0) records.RemoveAt(index);
        }
        //Индексатор - свойство для доступа к закрытому объекту
        public Player this[int index]
        {
            get { return records[index]; }
        }

        public void Save()
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(records));
        }
        public void Load()
        {
            records = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(fileName));
        }


        public int Count
        {
            get { return records.Count; }
        }

        public void Sort()
        {
            records.Sort();
        }
        public bool Exists(Player p)
        {
            return records.Exists(x => x.Nik == p.Nik && x.DateRecord == p.DateRecord && x.Record == p.Record);
        }
        public string ToString(Player p)
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i] != null)
                {
                    if (records[i].Equals(p)) sb.AppendFormat(currentPlayer, i + 1, records[i].Nik, records[i].DateRecord, records[i].Record);
                    else sb.AppendFormat(currentWinner, i + 1, records[i].Nik, records[i].DateRecord, records[i].Record);
                } 
                
            }
            return sb.ToString();
        }
    }
}
