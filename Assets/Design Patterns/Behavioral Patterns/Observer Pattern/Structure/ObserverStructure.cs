using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Observer
{
    public class ObserverStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "111"));
            subject.Attach(new ConcreteObserver(subject, "222"));
            subject.Attach(new ConcreteObserver(subject, "333"));

            subject.SubjectState = "ABC";
            subject.Notify();

            subject.SubjectState = "123123";
            subject.Notify();
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class Subject
    {
        private List<Observer> observers = new List<Observer>();


        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Dettach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        private string subjectState;

        public string SubjectState
        {
            set { subjectState = value; }
            get { return subjectState; }
        }
    }

    class ConcreteObserver : Observer
    {
        private string name;
        private ConcreteSubject subject;


        public ConcreteSubject Subject
        {
            set { subject = value; }
            get { return subject; }
        }

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            Debug.LogError("Observer " + name + " 's new state is " + subject.SubjectState);
        }
    }
}