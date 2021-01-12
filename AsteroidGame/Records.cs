using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace AsteroidGame
{
    class Records//: IEnumerable<Player>
    {
        public List<Player> records;
        string fileName;
        public Records()
        {
            records = new List<Player>();
            fileName = "records.json";
        }
        /*public IEnumerator<Player> GetEnumerator()
        {
            return (IEnumerator<Player>)records.GetEnumerator();
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
            string rec = String.Format("            {0}                            {1}                 {2}\n\n", "Игрок:", "Дата:", "Набрано очков:");
            for (int i = 0; i < records.Count; i++)
            {
                if (Player.Equals(records[i], p)) rec += String.Format("{0,4}.      {1,-20}      {2,15:d}    {3,10} - Ваш результат\n", i + 1, records[i].Nik, records[i].DateRecord.Date, records[i].Record);
                else rec += String.Format("{0,4}.      {1,-20}      {2,15:d}    {3,10}\n", i + 1, records[i].Nik, records[i].DateRecord.Date, records[i].Record);
            }
            return rec;
        }
    }
}
