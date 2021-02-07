using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Design.Factory
{
    public abstract class Tank
    {
        public abstract void Shoot();
    }

    public class Tank1 : Tank
    {
        public override void Shoot()
        {
            Debug.LogError("Tank1 Shoot");
        }
    }

    public class Tank2 : Tank
    {
        public override void Shoot()
        {
            Debug.LogError("Tank2 Shoot");
        }
    }

    //////Factory
    public abstract class TankFactory
    {
        public abstract Tank CreateTank();
    }

    public class Tank1Factory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank1();
        }
    }

    public class Tank2Factory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank2();
        }
    }
}