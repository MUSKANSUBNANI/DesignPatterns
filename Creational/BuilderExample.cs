using System;
namespace DesignPatterns.Creational.Builder
{
    
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(IVehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    interface IVehicleBuilder
    {
        
        // build methods
        public void BuildFrame();
        public  void BuildEngine();
        public  void BuildWheels();
        public  void BuildDoors();
        //getter
        public Vehicle Vehicle { get; }

    }
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : IVehicleBuilder
    {
        private Vehicle vehicle;
        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }
        public  void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }
        public  void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }
        public void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : IVehicleBuilder
    {
        private Vehicle vehicle;
        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }
        public void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }
        public void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
        public void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : IVehicleBuilder
    {

        private Vehicle vehicle;
        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }
        public void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }
        public void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();
        // Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }


    /// <summary>
    /// MainApp startup class for Real-World 
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create shop with vehicle builders
            Shop shop = new Shop();
            // Construct and display vehicles
            IVehicleBuilder builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            // Wait for user
            Console.ReadKey();
        }
    }
}

