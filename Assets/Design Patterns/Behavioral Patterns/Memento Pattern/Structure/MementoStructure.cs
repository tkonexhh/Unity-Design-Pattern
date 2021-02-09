using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Memento
{

    public class MementoStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Originator originator = new Originator();
            originator.State = "On";
            originator.DoSomething();
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.Save();

            originator.State = "Off";
            originator.DoSomething();
            originator.Restore(caretaker.Memento);
            originator.DoSomething();
        }
    }

    class Originator
    {
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public Memento Save()
        {
            return new Memento(state);
        }

        public void Restore(Memento memento)
        {
            state = memento.State;
        }

        public void DoSomething()
        {
            Debug.LogError(state);
        }
    }

    class Memento
    {
        private string state;

        public string State => state;

        public Memento(string state)
        {
            this.state = state;
        }
    }


    class Caretaker
    {
        private Memento _memento;

        // Gets or sets memento
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
