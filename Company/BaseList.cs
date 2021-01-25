using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Company
{
    abstract class BaseList<T>
    {
        protected List<T> list;
        protected string FileName { get; set; }
        protected string Company { get; set; }
        public BaseList(string company)
        {
            list = new List<T>();
            Company = company;
            
        }
        public BaseList()
        {
            list = new List<T>();
            Company = "Example";
            
        }
        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(list));
        }
        public abstract void Load(string company);
        
        public void Add(T obj)
        {
            list.Add(obj);
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        public int Count
        {
            get { return list.Count; }
        }

        public void Sort()
        {
            list.Sort();
        }
        public abstract bool Exists(T obj);

        
        
    }
}
