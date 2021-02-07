using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Builder
{
    public class BuilderPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            VehicleTest test;
            VehicleBuilder vehicle = new ShipBuilder();
            test = new VehicleTest(vehicle);
            test.Test();

            vehicle = new CarBuilder();
            test = new VehicleTest(vehicle);
            test.Test();
        }


    }

    class VehicleTest
    {
        private VehicleBuilder builder;

        public VehicleTest(VehicleBuilder builder)
        {
            this.builder = builder;
        }

        public void Test()
        {
            builder.BuildFrame();
            builder.BuildEngine();
            builder.BuildWheels();
            builder.BuildDoors();
            builder.Vehicle.Show();
        }
    }

    class Vehicle
    {
        private string name;
        private Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehicle(string name)
        {
            this.name = name;
        }

        public string this[string key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void Show()
        {
            Debug.LogError("------------");
            Debug.LogError("Name:" + name);
            Debug.LogError("Frame" + parts["frame"]);
            Debug.LogError("Engine" + parts["engine"]);
            Debug.LogError("Wheel" + parts["wheels"]);
            Debug.LogError("Door" + parts["doors"]);
        }
    }

    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle Vehicle => vehicle;


        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }


    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "V8";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }

    class ShipBuilder : VehicleBuilder
    {
        public ShipBuilder()
        {
            vehicle = new Vehicle("Ship");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Ship Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "Ship Engine";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "0";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "100";
        }
    }
}