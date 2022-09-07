using System;
namespace DesignPatterns.Creational.FactoryMethod
{
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Document
    {
        private List<IPage> _pages = new();
        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }
        public List<IPage> Pages
        {
            get { return _pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }
    /// <summary>
    /// A 'ConcreteCreator' class responsible for object creation
    /// </summary>
    class Resume : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class responsible for object creation
    /// </summary>
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }


    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    interface IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SkillsPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class EducationPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ExperiencePage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class IntroductionPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ResultsPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConclusionPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SummaryPage : IPage
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class BibliographyPage : IPage
    {
    }
   


    /// <summary>
    /// MainApp startup class for Real-World 
    /// Factory Method Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Note: constructors call Factory Method
            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();
            // Display document pages
            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (IPage page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
            // Wait for user
            Console.ReadKey();
        }
    }

}

