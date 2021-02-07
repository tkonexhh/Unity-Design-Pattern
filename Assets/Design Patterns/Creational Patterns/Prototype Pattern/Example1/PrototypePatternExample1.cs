using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.ProtoType
{
    public class PrototypePatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ColorMgr colorMgr = new ColorMgr();
            colorMgr["red"] = new Color(255, 0, 0);
            colorMgr["blue"] = new Color(0, 0, 255);

            Color color1 = colorMgr["red"].Clone() as Color;
            color1.Show();

            Color color2 = colorMgr["blue"].Clone() as Color;
            color2.Show();
        }
    }

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int r;
        private int g;
        private int b;

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public void Show()
        {
            Debug.LogError("RGB:" + r + "-" + g + "-" + b);
        }

        public override ColorPrototype Clone()
        {
            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    class ColorMgr
    {
        private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors[key] = value; }
        }
    }
}