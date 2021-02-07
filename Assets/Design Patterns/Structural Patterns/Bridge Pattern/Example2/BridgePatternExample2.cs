using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Bride
{
    public class BridgePatternExample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Circle circle = new Circle();
            Square square = new Square();
            Color circle_Red = new Red(circle);
            circle_Red.Show();
            Color square_Red = new Red(square);
            square_Red.Show();

            Color circle_Blue = new Blue(circle);
            circle_Blue.Show();
            Color square_Blue = new Blue(square);
            square_Blue.Show();
        }
    }

    public abstract class Shape
    {
        public abstract void Show();
    }

    public class Circle : Shape
    {
        public override void Show()
        {
            Debug.LogError("Circle");
        }
    }

    public class Square : Shape
    {
        public override void Show()
        {
            Debug.LogError("Square");
        }
    }


    public abstract class Color
    {
        protected Shape shape;
        public Color(Shape shape)
        {
            this.shape = shape;
        }
        public abstract void Show();
    }

    public class Blue : Color
    {
        public Blue(Shape shape) : base(shape) { }
        public override void Show()
        {
            shape.Show();
            Debug.LogError("Blue");
        }
    }

    public class Red : Color
    {
        public Red(Shape shape) : base(shape) { }
        public override void Show()
        {
            shape.Show();
            Debug.LogError("Red");
        }
    }
}