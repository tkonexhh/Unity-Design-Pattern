using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DesignPattern.Flyweight
{
    public class FlyweightPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            FlyweightFactory factory = new FlyweightFactory(
                new Car() { Owner = "111", Number = "A123", Color = "White" },
                new Car() { Owner = "222", Number = "B123", Color = "Black" },
                new Car() { Owner = "333", Number = "C123", Color = "Blue" });

            Car newCar = new Car() { Owner = "4444", Number = "fdsgsfg", Color = "Yellow" };
            var flyweight = factory.GetFlyweight(newCar);
            flyweight.Operation(newCar);
            //第二次获得就是flyweight
            flyweight = factory.GetFlyweight(newCar);
            flyweight.Operation(newCar);

            //查找一个在之前已经存在的
            Car oldCar = new Car() { Owner = "111", Number = "A123", Color = "White" };
            flyweight = factory.GetFlyweight(oldCar);
            flyweight.Operation(oldCar);
        }
    }

    class Car
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
    }

    class Flyweight
    {
        private Car _SharedState;
        public Car sharedCar => _SharedState;

        public Flyweight(Car car)
        {
            _SharedState = car;
        }

        public void Operation(Car uniqueState)
        {
            Debug.LogError(_SharedState.Owner + "%" + uniqueState.Owner);
        }


    }

    class FlyweightFactory
    {
        private List<Flyweight> flyweights = new List<Flyweight>();

        public FlyweightFactory(params Car[] cars)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                flyweights.Add(new Flyweight(cars[i]));
            }
        }

        public string GetKey(Car car)
        {
            string key = "Owner:" + car.Owner + "-Number" + car.Number + "-Color:" + car.Color;
            return key;
        }

        public Flyweight GetFlyweight(Car car)
        {
            string key = GetKey(car);
            if (flyweights.Where(t => GetKey(t.sharedCar) == key).Count() == 0)
            {
                Debug.LogError("Not Found");
                flyweights.Add(new Flyweight(car));
            }
            else
            {
                Debug.LogError("Founded");
            }

            return flyweights.Where(t => GetKey(t.sharedCar) == key).FirstOrDefault();
        }
    }
}