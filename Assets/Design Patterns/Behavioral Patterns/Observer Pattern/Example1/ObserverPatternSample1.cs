using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Observer
{
    public class ObserverPatternSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Shop shop = new Shop();
            shop.Attach(new Person("Tom"));
            shop.Attach(new Person("Joe"));

            shop.SendMsg("New Item!!");
        }
    }

    class Person
    {
        string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void Receive(string msg)
        {
            Debug.LogError("Name " + name + " Receive:" + msg);
        }
    }

    class Shop
    {
        private string symbol;
        private List<Person> observers = new List<Person>();

        public void Attach(Person person)
        {
            observers.Add(person);
        }

        public void Detach(Person person)
        {
            observers.Remove(person);
        }

        public void Notify()
        {
            foreach (var person in observers)
            {
                person.Receive(symbol);
            }
        }

        public void SendMsg(string msg)
        {
            symbol = msg;
            Notify();
        }
    }


}