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
        public void Design()
        {
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
