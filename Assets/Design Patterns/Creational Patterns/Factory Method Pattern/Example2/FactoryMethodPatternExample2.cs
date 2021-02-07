using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Design.Factory
{
    public class FactoryMethodPatternExample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Document[] documents = new Document[2];
            documents[0] = new Report();
            documents[1] = new Resume();

            foreach (var document in documents)
            {
                Debug.LogError("\n" + document.GetType().Name + "---");
                foreach (var page in document.Pages)
                {
                    Debug.LogError(page.GetType().Name + "   ");
                }
            }
        }
    }


    abstract class Page
    {

    }


    class SkillPage : Page { }
    class SchoolPage : Page { }
    class ExperiencePage : Page { }
    class IntroductionPage : Page { }
    class ResultPage : Page { }


    abstract class Document
    {
        private List<Page> m_Pages = new List<Page>();
        public List<Page> Pages => m_Pages;

        public Document()
        {
            CreateDocument();
        }

        //工厂实现
        public abstract void CreateDocument();
    }


    class Report : Document
    {
        //各自的工厂模式
        public override void CreateDocument()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
        }
    }

    class Resume : Document
    {
        public override void CreateDocument()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new SkillPage());
            Pages.Add(new SchoolPage());
            Pages.Add(new ExperiencePage());
        }
    }
}
