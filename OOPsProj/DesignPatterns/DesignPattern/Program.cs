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
            SingletonMain singletonMain = new SingletonMain();
            singletonMain.Design();
        }
    }
}
