using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class Entry<T>
    {
        public T? Data { get; set;}
        public string Key { get; private set; }
        public Entry<T>? Next;

        public Entry(string key, T? data)
        {
            Key = key;
            Data = data;
        }
    }
    public class MyHashTable<T>
    {
        private Entry<T>?[] Buckets;
        private const int MAX_SIZE = 256;

        public int Count { get; private set; }

        public MyHashTable()
        {
            Buckets = new Entry<T>[MAX_SIZE];
        }

        public void Add(string key, T? data)
        {
            Entry<T> entry;

            if(Count > 0 && GetEntry(key) != null)
                return;

            int hash = Hash(key);

            entry = new(key, data);

            entry.Next = Buckets[hash];

            Buckets[hash] = entry;

            Count++;
        }

        public T? this[string key]
        {
            get { return Get(key); }
            set
            {
                Entry<T>? entry = GetEntry(key);
                if(entry != null) 
                {
                    entry.Data = value;
                    return;
                }
                Add(key, value);
            }
        }

        public void Remove(string key)
        {
            ref Entry<T>? entry = ref Buckets[Hash(key)];

            while(entry != null)
            {
                if(entry.Key == key)
                {
                    entry = entry.Next;
                    Count--;
                    return;
                }
                entry = ref entry.Next;
            }
        }

        public T? Get(string key)
        {
            Entry<T>? entry = GetEntry(key);

            if(entry != null)
                return entry.Data;
            return default;
        }

        private Entry<T>? GetEntry(string key)
        {
            int hash;

            if(Count == 0)
                return null;

            hash = Hash(key);

            for(Entry<T>? entry = Buckets[hash]; entry != null; entry = entry.Next)
                if(entry.Key == key)
                    return entry;

            return null;
        }

        private int Hash(string key)
        {
            int hash = 5381;

            foreach(char c in key)
                hash = ((hash << 5) + hash) + c;

            hash &= 0xFF;

            return hash;
        }
    }
}