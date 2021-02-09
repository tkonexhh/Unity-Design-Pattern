using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Strategy
{
    public class StrategyStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Context context = new Context(new StrategyA());
            context.DoSomething();
            context = new Context(new StrategyB());
            context.DoSomething();
        }
    }

    abstract class Strategy
    {
        public abstract void Process();
    }


    class StrategyA : Strategy
    {
        public override void Process()
        {
            Debug.LogError("StrategyA Process");
        }
    }

    class StrategyB : Strategy
    {
        public override void Process()
        {
            Debug.LogError("StrategyB Process");
        }
    }

    class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomething()
        {
            strategy.Process();
        }
    }

}