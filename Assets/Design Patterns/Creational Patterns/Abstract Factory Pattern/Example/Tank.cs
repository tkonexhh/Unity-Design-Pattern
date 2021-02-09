using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.AbsFactory
{
    public interface ITank
    {
        void Shoot();
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

    public abstract class Gun
    {
        //public abstract void Shoot();
    }

    public class Gun_AK : Gun { }
    public class Gun_M4 : Gun { }

    //////////////////////////////////////////////////////////////////
    public abstract class ArmyFactory
    {
        public abstract Tank CreateTank();
        public abstract Gun CreateGun();
    }


    public class ArmyFactory_Germany : ArmyFactory//德国坦克工厂
    {
        public override Tank CreateTank()
        {
            Tank tank = new Tank_Heavy();
            return tank;
        }


        public override Gun CreateGun()
        {
            Gun gun = new Gun_AK();
            return gun;
        }
    }


    public class ArmFactory_JP : ArmyFactory//德国兵工厂
    {
        public override Tank CreateTank()
        {
            Tank tank = new Tank_Light();
            return tank;
        }


        public override Gun CreateGun()
        {
            Gun gun = new Gun_M4();
            return gun;
        }
    }
}