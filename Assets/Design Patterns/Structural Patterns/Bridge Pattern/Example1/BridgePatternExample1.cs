using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Bride
{
    public class BridgePatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Controller attack = new AttackController();
            Controller jump = new JumpController();

            Platform pc = new KeyboardPlatform(jump);
            pc.OnClick();
            pc.Cancle();
            pc = new KeyboardPlatform(attack);
            pc.OnClick();
            pc.Cancle();

            Debug.LogError("--------Switch To Xbox--------");
            Platform xbox = new XBoxPlatform(jump);
            xbox.OnClick();
            xbox.Cancle();
            xbox = new XBoxPlatform(attack);
            xbox.OnClick();
            xbox.Cancle();
        }


    }


    public abstract class Controller
    {
        public abstract void Click();
        public abstract void Cancle();
    }

    public class JumpController : Controller
    {
        public override void Click()
        {
            Debug.LogError("Role jump");
        }

        public override void Cancle()
        {
            Debug.LogError("Role cancle jump");
        }
    }

    public class AttackController : Controller
    {
        public override void Click()
        {
            Debug.LogError("Role attack");
        }

        public override void Cancle()
        {
            Debug.LogError("Role cancle attack");
        }
    }

    public abstract class Platform
    {
        private Controller controler;
        public Platform(Controller controler)
        {
            this.controler = controler;
        }

        public virtual void OnClick()
        {
            controler.Click();
        }

        public virtual void Cancle()
        {
            controler.Cancle();
        }
    }

    public class KeyboardPlatform : Platform
    {
        public KeyboardPlatform(Controller controller) : base(controller) { }

        public override void OnClick()
        {
            base.OnClick();
            Debug.LogError("KeyboardPlatform OnClick");
        }

        public override void Cancle()
        {
            base.Cancle();
            Debug.LogError("KeyboardPlatform Cancle");
        }
    }

    public class XBoxPlatform : Platform
    {
        public XBoxPlatform(Controller controller) : base(controller) { }

        public override void OnClick()
        {
            base.OnClick();
            Debug.LogError("XBoxPlatform OnClick");
        }

        public override void Cancle()
        {
            base.Cancle();
            Debug.LogError("XBoxPlatform Cancle");
        }
    }
}