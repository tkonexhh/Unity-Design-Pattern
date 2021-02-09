using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.TemplateMethod
{
    public class TemplateMethodStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AbstractClass a = new ConcreteClassA();
            a.TemplateMethod();

            AbstractClass b = new ConcreteClassB();
            b.TemplateMethod();
        }
    }

    abstract class AbstractClass
    {
        public abstract void Operation1();
        public abstract void Operation2();
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
            Debug.LogError("");
        }
    }

    class ConcreteClassA : AbstractClass
    {
        public override void Operation1()
        {
            Debug.LogError("ConcreteClassA.Operation1");
        }

        public override void Operation2()
        {
            Debug.LogError("ConcreteClassA.Operation2");
        }
    }

    class ConcreteClassB : AbstractClass
    {
        public override void Operation1()
        {
            Debug.LogError("ConcreteClassB.Operation1");
        }

        public override void Operation2()
        {
            Debug.LogError("ConcreteClassB.Operation2");
        }
    }
}
