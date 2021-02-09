using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Interpreter
{
    //解释模式
    public class InterpreterPatternStructure : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Context context = new Context();
            ArrayList list = new ArrayList();

            list.Add(new ExpressionA());
            list.Add(new ExpressionB());
            list.Add(new ExpressionA());
            list.Add(new ExpressionA());

            foreach (Expression exp in list)
            {
                exp.Interpret(context);
            }
        }
    }


    abstract class Expression
    {
        public abstract void Interpret(Context context);
    }

    class ExpressionA : Expression
    {
        public override void Interpret(Context context)
        {
            Debug.LogError("ExpressionA.Interpret");
        }
    }

    class ExpressionB : Expression
    {
        public override void Interpret(Context context)
        {
            Debug.LogError("ExpressionB.Interpret");
        }
    }

    class Context { }

}
