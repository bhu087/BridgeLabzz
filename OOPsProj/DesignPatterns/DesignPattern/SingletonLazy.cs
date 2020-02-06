////...............................................
////<copyright file="SingletonLazy.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////................................................
namespace DesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is singleton example it gives only one instance every time
    /// </summary>
    public sealed class SingletonLazy       ////make it sealed
    {
        /// <summary>
        /// The count
        /// </summary>
        private static int count = 0;

        /// <summary>
        /// The instance
        /// </summary>
        private static Lazy<SingletonLazy> instance = new Lazy<SingletonLazy>(()=>new SingletonLazy());
        /// <summary>
        /// Prevents a default instance of the <see cref="SingletonLazy"/> class from being created.
        /// </summary>
        private SingletonLazy()
        {
            count++;
            Console.WriteLine("Count value {0}", count);
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>Singleton object</returns>
        public static SingletonLazy GetInstance()
        {
            return instance.Value;
        }
    }
}
