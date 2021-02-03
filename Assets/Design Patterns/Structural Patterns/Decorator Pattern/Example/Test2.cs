using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Design.Decorator;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tank tank = new Tank_Heavy();
        Decorator_A decoratorA = new Decorator_A(tank);
        Decorator_B decoratorB = new Decorator_B(decoratorA);
        decoratorB.Shoot();
    }


}
