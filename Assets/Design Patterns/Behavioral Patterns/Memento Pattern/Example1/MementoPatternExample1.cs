using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Memento.Example1
{
    public class MementoPatternExample1 : MonoBehaviour
    {
        Caretaker caretaker = new Caretaker();
        Originator originator = new Originator();

        int savedFiles = 0, currentArticle = 0;

        void Start()
        {
            originator.article = "1:----";
            Save();
            originator.article = "2:----";
            Save();
            originator.article = "3:----";
            Save();
            originator.article = "4:----";
            Save();

            Undo();
            Undo();
            Undo();
            Redo();
        }

        void Save()
        {
            caretaker.Add(originator.Save());
            savedFiles = caretaker.savedCount;
            currentArticle = savedFiles;
        }

        void Undo()
        {
            if (currentArticle > 0)
                currentArticle -= 1;

            Memento prev = caretaker.Get(currentArticle);
            originator.Restore(prev);
            Debug.LogError(originator.article);
        }

        void Redo()
        {
            if (currentArticle < savedFiles)
                currentArticle += 1;

            Memento next = caretaker.Get(currentArticle);
            originator.Restore(next);
            Debug.LogError(originator.article);
        }
    }



    class Memento
    {
        public string article { get; protected set; }

        public Memento(string article)
        {
            this.article = article;
        }
    }

    class Originator
    {
        public string article;

        public Memento Save()
        {
            return new Memento(article);
        }

        public void Restore(Memento memento)
        {
            this.article = memento.article;
        }
    }

    class Caretaker
    {
        List<Memento> savedHistory = new List<Memento>();

        public int savedCount => savedHistory.Count;

        public void Add(Memento memento)
        {
            savedHistory.Add(memento);
        }

        public Memento Get(int index)
        {
            return savedHistory[index];
        }
    }
}