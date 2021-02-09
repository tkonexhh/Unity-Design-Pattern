using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Iterator
{
    public class IteratorPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Collection collection = new Collection();
            for (int i = 0; i < 10; i++)
            {
                collection[i] = new Item(i.ToString());
            }

            Iterator iterator = collection.CreateIterator();
            for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Debug.LogError(item.Name);
            }
        }
    }

    class Item
    {
        private string _name;
        public string Name => _name;

        public Item(string name)
        {
            this._name = name;
        }
    }

    class Collection//容器
    {
        private List<Item> itemLst = new List<Item>();

        public int count => itemLst.Count;

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public Item this[int index]
        {
            get { return itemLst[index]; }
            set { itemLst.Add(value); }
        }
    }

    interface IIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

    class Iterator : IIterator
    {
        private Collection collection;
        private int current = 0;

        public Iterator(Collection collection)
        {
            this.collection = collection;
        }

        public Item First()
        {
            current = 0;
            return collection[current];
        }

        public Item Next()
        {
            current++;
            if (!IsDone)
                return collection[current];
            else
                return null;
        }

        public Item CurrentItem
        {
            get { return collection[current]; }
        }

        public bool IsDone
        {
            get { return current >= collection.count; }
        }
    }
}