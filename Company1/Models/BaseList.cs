using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Company1.Models
{
    abstract class BaseList<T>: IEnumerable<T>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected ObservableCollection<T> list;
        protected string FileName { get; set; }
        public string Company { get; set; }
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
        public void Load()
        {
            list = JsonConvert.DeserializeObject<ObservableCollection<T>>(File.ReadAllText(FileName));
        }

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
        public void Clear()
        {
            list.Clear();
        }
        public override int GetHashCode()
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] hashLetter = utf8.GetBytes(Company);
            int hash = 0;
            for (int i = 0; i < hashLetter.Length; i++)
            {
                hash += hashLetter[i] * (int)Math.Pow((double)2, (double)i);
            }
            return hash;
        }

    }
}
