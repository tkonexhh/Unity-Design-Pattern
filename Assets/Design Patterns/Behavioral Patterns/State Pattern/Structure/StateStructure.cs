using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.State
{
    public class StateStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Context a = new Context(new ConcreteStateA());
            a.Request();

            a.State = new ConcreteStateB();
            a.Request();
        }
    }


    abstract class State
    {
        public abstract void Handle();
    }

    class ConcreteStateA : State
    {
        public override void Handle()
        {
            Debug.LogError("ConcreteStateA XXXX");
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle()
        {
            Debug.LogError("ConcreteStateB XXXX");
        }
    }

    class Context
    {
        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }
        public Context(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            state.Handle();
        }
    }

}
