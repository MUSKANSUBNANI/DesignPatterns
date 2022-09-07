using System;
namespace DesignPatterns.Creational.AbstractFactory
{
        /// <summary>
        /// The 'AbstractFactory' abstract class
        /// </summary>

        public interface IContinentFactory
        {
            IHerbivore CreateHerbivore();
            ICarnivore CreateCarnivore();
        }

        /// <summary>
        /// The 'ConcreteFactory1' class
        /// </summary>

        class AfricaFactory : IContinentFactory
        {
            public IHerbivore CreateHerbivore()
            {
                return new Wildebeest();
            }
            public ICarnivore CreateCarnivore()
            {
                return new Lion();
            }
        }

        /// <summary>
        /// The 'ConcreteFactory2' class
        /// </summary>

        class AmericaFactory : IContinentFactory
        {
            public IHerbivore CreateHerbivore()
            {
                return new Bison();
            }
            public  ICarnivore CreateCarnivore()
            {
                return new Wolf();
            }
        }

        /// <summary>
        /// The 'AbstractProductA' abstract class
        /// </summary>

        public interface IHerbivore
        {
        }

        /// <summary>
        /// The 'AbstractProductB' abstract class
        /// </summary>

        public interface ICarnivore
        {
            public void Eat(IHerbivore h);
        }

        /// <summary>
        /// The 'ProductA1' class
        /// </summary>

        class Wildebeest : IHerbivore
        {
        }

        /// <summary>
        /// The 'ProductB1' class
        /// </summary>

        class Lion : ICarnivore
        {
            public void Eat(IHerbivore h)
            {
                // Eat Wildebeest

                Console.WriteLine(this.GetType().Name +
                  " eats " + h.GetType().Name);
            }
        }

        /// <summary>
        /// The 'ProductA2' class
        /// </summary>

        class Bison : IHerbivore
        {
        }

        /// <summary>
        /// The 'ProductB2' class
        /// </summary>

        class Wolf : ICarnivore
        {
            public void Eat(IHerbivore h)
            {
                // Eat Bison

                Console.WriteLine(this.GetType().Name +
                  " eats " + h.GetType().Name);
            }
        }

        /// <summary>
        /// The 'Client' class 
        /// </summary>

        class AnimalWorld
        {
            private IHerbivore _herbivore;
            private ICarnivore _carnivore;

            // Constructor

            public AnimalWorld(IContinentFactory factory)
            {
                _carnivore = factory.CreateCarnivore();
                _herbivore = factory.CreateHerbivore();
            }

            public void RunFoodChain()
            {
                _carnivore.Eat(_herbivore);
            }
        }



    /// <summary>
    /// MainApp startup class for Real-World
    /// Abstract Factory Design Pattern.
    /// </summary>

    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>

        public static void Main()
        {
            // Create and run the African animal world

            IContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world

            IContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            // Wait for user input

            Console.ReadKey();
        }
    }


}

