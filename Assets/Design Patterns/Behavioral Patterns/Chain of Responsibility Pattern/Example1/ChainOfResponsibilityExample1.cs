using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.ChainOfResponsibility
{
    public class ChainOfResponsibilityExample1 : MonoBehaviour
    {
        void Start()
        {
        }
    }


    abstract class Chain
    {
        protected Chain nextChain;

        public void SetNextChain(Chain nextChain)
        {
            this.nextChain = nextChain;
        }

        public abstract void Calculate();

    }

    class AddNumbers : Chain
    {
        public override void Calculate()
        {

        }
    }
};