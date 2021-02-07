using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Adapter
{
    public class AdapterPatternExample : MonoBehaviour
    {

        void Start()
        {
            Car car = new Car();
            Bus bus = new Bus();
            BusAdapter busAdapter = new BusAdapter(bus);
            // busAdapter.DoA();
            // car.DoA();

            CarMgr carMgr = new CarMgr();
            carMgr["car"] = car;
            carMgr["bus"] = busAdapter;
            carMgr.Show();
        }
    }

    public interface ICar
    {
        void DoA();
    }
    //Old Code
    class Car : ICar
    {
        public void DoA()
        {
            Debug.LogError("Car DoA");
        }
    }

    //New Code
    class Bus
    {
        public void DoB()
        {
            Debug.LogError("Bus DoB");
        }
    }

    class BusAdapter : ICar
    {
        private Bus bus;
        public BusAdapter(Bus bus)
        {
            this.bus = bus;
        }

        public void DoA()
        {
            Debug.LogError("Bus DoA");
            bus.DoB();
        }
    }

    class CarMgr
    {
        Dictionary<string, ICar> car = new Dictionary<string, ICar>();

        public ICar this[string key]
        {
            set { car[key] = value; }
            get { return car[key]; }
        }

        public void Show()
        {
            foreach (var key in car.Keys)
            {
                car[key].DoA();
            }
        }
    }
}