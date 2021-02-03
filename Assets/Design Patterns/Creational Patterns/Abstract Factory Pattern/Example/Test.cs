using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Design.AbsFactory
{
    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ArmyFactory factory = new ArmyFactory_Germany();
            var tank = factory.CreateTank();
            tank.Shoot();
        }

    }
}