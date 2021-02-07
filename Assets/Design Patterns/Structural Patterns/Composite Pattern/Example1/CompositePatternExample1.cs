using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Composite
{
    public class CompositePatternExample1 : MonoBehaviour
    {

        void Start()
        {
            InventoryMgr inventoryMgr = new InventoryMgr();
            Bag bag_Main = new Bag();
            bag_Main.AddItem(new Item(1));
            bag_Main.AddItem(new Item(2));
            inventoryMgr.AddItem(new Item(4));
            inventoryMgr.AddItem(bag_Main);
            float value = inventoryMgr.GetAllValue();
            Debug.LogError("Value:" + value);

        }


    }
    //WOW中的背包 大背包可以装小背包  背包都可以装道具 现在要快速计算背包的总价值
    interface IItem
    {
        float GetValue();
    }

    class Item : IItem
    {
        protected float value;

        public Item(float value)
        {
            this.value = value;
            Debug.LogError(this.value);
        }

        public virtual float GetValue()
        {
            return value;
        }
    }

    class Bag : Item
    {
        private List<Item> items = new List<Item>();

        public Bag() : base(0) { }

        public override float GetValue()
        {
            value = 0;
            foreach (var item in items)
            {
                value += item.GetValue();
            }

            return value;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }

    class InventoryMgr
    {
        private List<Item> items = new List<Item>();
        public float GetAllValue()
        {
            float value = 0;
            foreach (var item in items)
            {
                value += item.GetValue();
            }

            return value;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }

}