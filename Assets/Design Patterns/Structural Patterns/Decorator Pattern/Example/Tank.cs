﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Design.Decorator
{
    public interface ITank
    {
        void Shoot();
    }

    public interface AutoReload
    {
        //
    }

    public interface WaterMove
    {

    }

    public abstract class Tank : ITank
    {
        public abstract void Shoot();

    }

    public class Tank_Heavy : Tank
    {
        public override void Shoot()
        {
            Debug.LogError("Tank_Heavy Shoot");
        }
    }

    public class Tank_Light : Tank
    {
        public override void Shoot()
        {
            Debug.LogError("Tank_Light Shoot");
        }
    }

    public class Tank_Heavy_A_W : Tank, AutoReload, WaterMove
    {
        public override void Shoot()
        {
            //在水里shoot cd短
            Debug.LogError("Tank_Heavy_A_W Shoot");
        }
    }
    //Tank_Heavy_A Tank_Heavy_W asdasdasd
    //Tank_Light_A Tank_Light_W ASDSAFXVFASDJXKZDB

    public abstract class Decorator : Tank
    {
        protected Tank tank;
        public Decorator(Tank tank)
        {
            this.tank = tank;
        }
        public override void Shoot()
        {
            tank.Shoot();
        }
    }

    public class Decorator_A : Decorator
    {
        public Decorator_A(Tank tank) : base(tank) { }
        public override void Shoot()
        {
            base.Shoot();
            Debug.LogError("Decorator_A Shoot");
        }
    }

    public class Decorator_B : Decorator
    {
        public Decorator_B(Tank tank) : base(tank) { }
        public override void Shoot()
        {
            base.Shoot();
            Debug.LogError("Decorator_B Shoot");
        }
    }
}