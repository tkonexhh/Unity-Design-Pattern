using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Strategy
{
    public class StrategyPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SortedList list = new SortedList();
            list.Add("Jone");
            list.Add("Jone");
            list.Add("Jone");
            list.SetSortStrategy(new PopSort());
            list.Sort();
            list.SetSortStrategy(new QuickSort());
            list.Sort();
        }
    }


    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Debug.LogError("QuickSort------");
        }
    }

    class PopSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Debug.LogError("PopSort------");
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Debug.LogError("MergeSort------");
        }
    }

    class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortStrategy.Sort(list);
        }
    }
}