using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Proxy
{
    public class ProxyPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            MathProxy proxy = new MathProxy();

            // Do the math
            Debug.LogError("4 + 2 = " + proxy.Add(4, 2));
            Debug.LogError("4 - 2 = " + proxy.Sub(4, 2));
            Debug.LogError("4 * 2 = " + proxy.Mul(4, 2));
            Debug.LogError("4 / 2 = " + proxy.Div(4, 2));
        }
    }

    interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y) { return math.Add(x, y); }
        public double Sub(double x, double y) { return math.Sub(x, y); }
        public double Mul(double x, double y) { return math.Mul(x, y); }
        public double Div(double x, double y) { return math.Div(x, y); }
    }
}