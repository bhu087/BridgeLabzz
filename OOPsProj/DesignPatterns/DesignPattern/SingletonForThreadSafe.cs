////...............................................
////<copyright file="SingletonForThreadSafe.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////................................................
namespace DesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is the singleton thread safe class
    /// </summary>
    class SingletonForThreadSafe
    {
        /// <summary>
        /// The count
        /// </summary>
        private static int count = 0;

        /// <summary>
        /// The instance
        /// </summary>
        private static SingletonForThreadSafe instance = null;

        /// <summary>
        /// The object
        /// </summary>
        private static readonly Object obj = new Object();

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonForThreadSafe"/> class.
        /// </summary>
        public SingletonForThreadSafe()
        {
            count++;
            Console.WriteLine("Count value is " + count);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>it returns the object</returns>
        public static SingletonForThreadSafe GetInstance()
        {
            ////if we remove it while thread actions chances of creating multiple objects
            ////then it breaks the singleton rukes so we use lock to avoid that
            //lock (obj)           
            //{
                if (instance == null)
                {
                ////in the above commented lock that requires more time because it checks every time
                ////so if we insert here it needed check once, when instance == null
                lock (obj)
                {
                    instance = new SingletonForThreadSafe();
                    return instance;
                }
                }
                return instance;
            //}
        }

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
