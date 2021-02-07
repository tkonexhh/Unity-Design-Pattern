using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Design.Factory
{
    public class Test_Factory : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Tank tank = new Tank1Factory().CreateTank();
            tank.Shoot();
        }


    }
}