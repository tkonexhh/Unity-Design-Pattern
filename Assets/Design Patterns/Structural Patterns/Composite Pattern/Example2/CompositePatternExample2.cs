using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Composite
{
    public class CompositePatternExample2 : MonoBehaviour
    {

        void Start()
        {
            LevelMgr levelMgr = new LevelMgr();
            levelMgr.AddComponent(new StageComponent());
            levelMgr.AddComponent(new EnemyComponent());

            levelMgr.LevelInit();
            levelMgr.LevelStart();
            levelMgr.LevelEnd();
        }
    }

    interface ILevelComponent
    {
        void LevelInit();
        void LevelStart();
        void LevelEnd();
    }

    abstract class AbstractLevelComponent : ILevelComponent
    {
        public abstract void LevelInit();
        public abstract void LevelStart();
        public abstract void LevelEnd();
    }

    class StageComponent : AbstractLevelComponent
    {
        public override void LevelInit()
        {
            Debug.LogError("StageComponent LevelInit");
        }
        public override void LevelStart()
        {
            Debug.LogError("StageComponent LevelStart");
        }
        public override void LevelEnd()
        {
            Debug.LogError("StageComponent LevelEnd");
        }
    }

    class EnemyComponent : AbstractLevelComponent
    {
        public override void LevelInit()
        {
            Debug.LogError("EnemyComponent LevelInit");
        }
        public override void LevelStart()
        {
            Debug.LogError("EnemyComponent LevelStart");
        }
        public override void LevelEnd()
        {
            Debug.LogError("EnemyComponent LevelEnd");
        }
    }

    class LevelMgr
    {
        List<ILevelComponent> _components = new List<ILevelComponent>();

        public void AddComponent(ILevelComponent component)
        {
            _components.Add(component);
        }

        public void LevelInit()
        {
            foreach (var compoent in _components)
            {
                compoent.LevelInit();
            }
        }

        public void LevelStart()
        {
            foreach (var compoent in _components)
            {
                compoent.LevelStart();
            }
        }

        public void LevelEnd()
        {
            foreach (var compoent in _components)
            {
                compoent.LevelEnd();
            }
        }
    }
}