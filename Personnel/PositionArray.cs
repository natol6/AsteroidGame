using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Personnel
{
    class PositionArray
    {
        private List<Position> positions;
        private string FileName { get; set; }
        private string Company { get; set; }
        private readonly string title = $"{"№ п/п",5}    {"Должность:",-20}    {"Коэффициент оплаты труда:"}\n\n";
        private readonly string position = "{0,4}.    {1,-20}    {2:F4,-10}\n";
        public PositionArray(string company)
        {
            positions = new List<Position>();
            Company = company;
            FileName = "StaffingTable//Pos_" + Company + ".json";
        }
        public PositionArray()
        {
            positions = new List<Position>();
            Company = "Example";
            FileName = "CollectivesOfEnterprises//Pos_" + Company + ".json";
        }
        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(positions));
        }
        public void Load(string company)
        {
            positions = JsonConvert.DeserializeObject<List<Position>>(File.ReadAllText("CollectivesOfEnterprises//Pos_" + Company + ".json"));
        }
        public void Add(Position pos)
        {
            positions.Add(pos);
        }
        public void Remove(int index)
        {
            if (positions != null && index < positions.Count && index >= 0) positions.RemoveAt(index);
        }
        public int Count
        {
            get { return positions.Count; }
        }

        public void Sort()
        {
            positions.Sort();
        }
        public bool Exists(Position pos)
        {
            return positions.Exists(x => x.Position_ == pos.Position_ && Math.Abs(x.FactorPay - pos.FactorPay) < 0.0001);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < positions.Count; i++)
            {
                if (positions[i] != null)
                {
                    sb.AppendFormat(position, i + 1, positions[i].Position_, positions[i].FactorPay);
                }

            }
            return sb.ToString();
        }
    }
}
