using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.ChainOfResponsibility.Structure
{
    public class ChainOfResponsibilityStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            Chain h1 = new ConcreteChain1();
            Chain h2 = new ConcreteChain2();
            Chain h3 = new ConcreteChain3();
            h1.SetNextChain(h2);
            h2.SetNextChain(h3);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }

    abstract class Chain
    {
        protected Chain nextChain;

        public void SetNextChain(Chain nextChain)
        {
            this.nextChain = nextChain;
        }

        public abstract void HandleRequest(int request);

    }

    class ConcreteChain1 : Chain
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Debug.LogError(this.GetType().Name + " handle request " + request);
            }
            else if (nextChain != null)
            {
                nextChain.HandleRequest(request);
            }
        }
    }

    class ConcreteChain2 : Chain
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Debug.LogError(this.GetType().Name + " handle request " + request);
            }
            else if (nextChain != null)
            {
                nextChain.HandleRequest(request);
            }
        }
    }

    class ConcreteChain3 : Chain
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Debug.LogError(this.GetType().Name + " handle request " + request);
            }
            else if (nextChain != null)
            {
                nextChain.HandleRequest(request);
            }
        }
    }
}