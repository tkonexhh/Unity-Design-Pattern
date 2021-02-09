using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Visitor
{
    public class VisitorStructure : MonoBehaviour
    {
        void Start()
        {
            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.Attach(new ConcreteElementA());
            objectStructure.Attach(new ConcreteElementB());

            Visitor visitor1 = new ConcreteVisitor1();
            Visitor visitor2 = new ConcreteVisitor2();

            objectStructure.Accept(visitor1);
            objectStructure.Accept(visitor2);
        }
    }

    abstract class Visitor
    {
        public abstract void VisitElementA(ConcreteElementA concreteElementA);
        public abstract void VisitElementB(ConcreteElementB concreteElementB);
    }

    class ConcreteVisitor1 : Visitor
    {
        public override void VisitElementA(ConcreteElementA concreteElementA)
        {
            Debug.LogError("ConcreteVisitor1.VisitElementA");
        }

        public override void VisitElementB(ConcreteElementB concreteElementB)
        {
            Debug.LogError("ConcreteVisitor1.VisitElementB");
        }
    }

    class ConcreteVisitor2 : Visitor
    {
        public override void VisitElementA(ConcreteElementA concreteElementA)
        {
            Debug.LogError("ConcreteVisitor2.VisitElementA");
        }

        public override void VisitElementB(ConcreteElementB concreteElementB)
        {
            Debug.LogError("ConcreteVisitor2.VisitElementB");
        }
    }


    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementA(this);
        }
    }

    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementB(this);
        }
    }


    class ObjectStructure
    {
        private List<Element> elements = new List<Element>();

        public void Attach(Element element)
        {
            elements.Add(element);
        }

        public void Detach(Element element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (var e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}