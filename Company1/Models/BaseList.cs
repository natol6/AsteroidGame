using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace Company1
{
    abstract class BaseList<T>: IEnumerable<T>
    {
        protected ObservableCollection<T> list;
        protected string FileName { get; set; }
        protected string Company { get; set; }
        public BaseList(string company)
        {
            list = new ObservableCollection<T>();
            Company = company;

        }
        public BaseList()
        {
            list = new ObservableCollection<T>();
            Company = "Example";

        }
        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(list));
        }
        public abstract void Load(string company);

        public void Add(T obj)
        {
            if (!list.Contains(obj)) list.Add(obj);
        }
        public void Remove(T obj)
        {
            list.Remove(obj);
        }
        public int Count
        {
            get { return list.Count; }
        }

        public bool Contains(T obj) 
        {
            return list.Contains(obj);
        }
        
    }
}
