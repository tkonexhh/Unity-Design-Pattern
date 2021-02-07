﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Design.Decorator;

namespace Design.Decorator
{
    public class Test2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Tank tank = new Tank_Heavy();
            tank = new Decorator_A(tank);
            tank = new Decorator_B(tank);
            tank.Shoot();
        }
    }
}