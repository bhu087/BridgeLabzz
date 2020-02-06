////...............................................
////<copyright file="Program.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////................................................
namespace DesignPattern
{
    using System;

    /// <summary>
    /// the program for design pattern
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Utility mainUtility = new Utility();
            Console.WriteLine("1 for Eager Initializatin\n2 for Lazy initialization");
            Console.WriteLine("3 for Static block initialization\n4 for Thread safe singleton");
            Console.WriteLine("5 for Factory Pattern");
            int option = mainUtility.IntiInput();
            SingletonMain singletonMain = new SingletonMain();
            switch (option)
            {
                case 1:
                    singletonMain.Design(1);
                    break;
                case 2:
                    singletonMain.Design(2);
                    break;
                case 3:
                    StaticBlocks staticBlocks = new StaticBlocks();
                    staticBlocks.StaticBlockAccess();
                    break;
                case 4:
                    //ThreadSafeSingalton threadSafeSingalton = new ThreadSafeSingalton();
                    ThreadSafeSingalton.Threading();
                    break;
                case 5:
                    FactoryPattern.Factory.FactoryDeviceDetails();
                    break;
                default:
                    break;
            }
        }
    }
}
