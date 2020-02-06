////...............................................
////<copyright file="SingletonMain.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////................................................
namespace DesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the singleton main method
    /// </summary>
    public class SingletonMain
    {
        /// <summary>
        /// Designs this instance.
        /// </summary>
        public void Design(int n)
        {
            if (n == 1)
            {
                Console.WriteLine("Eager Initialization");
                ////i have created 3 objects
                Singleton object1 = Singleton.GetInstance();
                object1.Message("Object One Here");
                Singleton object2 = Singleton.GetInstance();
                object2.Message("Object two Here");
                Singleton object3 = Singleton.GetInstance();
                object3.Message("Object Three Here");
                ////but it creates only a single instance we observe it by hash code of each objects
                Console.WriteLine("Object one Hash Code " + object1.GetHashCode());
                Console.WriteLine("Object two Hash Code " + object2.GetHashCode());
                Console.WriteLine("Object two Hash Code " + object3.GetHashCode());
                return;
            }
            if (n == 2)
            {
                Console.WriteLine("Lazy Initialization");
                ////i have created 3 objects
                SingletonLazy object1 = SingletonLazy.GetInstance();
                object1.Message("Object One Here");
                SingletonLazy object2 = SingletonLazy.GetInstance();
                object2.Message("Object two Here");
                SingletonLazy object3 = SingletonLazy.GetInstance();
                object3.Message("Object Three Here");
                ////but it creates only a single instance we observe it by hash code of each objects
                Console.WriteLine("Object one Hash Code " + object1.GetHashCode());
                Console.WriteLine("Object two Hash Code " + object2.GetHashCode());
                Console.WriteLine("Object two Hash Code " + object3.GetHashCode());
                return;
            }
        }

        /*
            OUTPUT
            Count value 1
            Object One Here
            Object two Here
            Object Three Here
            Object one Hash Code 58225482
            Object two Hash Code 58225482
            Object two Hash Code 58225482
         */
    }
}
