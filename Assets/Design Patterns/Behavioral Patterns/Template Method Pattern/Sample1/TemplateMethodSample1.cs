using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.TemplateMethod
{
    public class TemplateMethodSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
    }

    abstract class GameAI
    {

        public abstract void TurnToTarget();
        public abstract void MoveToTarget();
        public abstract void Attack();

        void Turn()
        {
            TurnToTarget();
            MoveToTarget();
            Attack();
        }
    }

    class WarriorAI : GameAI
    {
        public override void TurnToTarget()
        {

        }

        public override void MoveToTarget() { }
        public override void Attack() { }
    }
}