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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the thread safe singleton example
    /// </summary>
    public class ThreadSafeSingalton
    {
        /// <summary>
        /// Threadings this instance.
        /// </summary>
        public static void Threading()
        {
            Parallel.Invoke(
                () => Teacher(),
                () => Student()
                );
            Console.ReadLine();
        }

        /// <summary>
        /// Teachers this instance.
        /// </summary>
        private static void Teacher()
        {
            SingletonForThreadSafe fromTeacher = SingletonForThreadSafe.GetInstance();
            fromTeacher.Message("Teacher Here");
            Console.WriteLine(fromTeacher.GetHashCode());
        }

        /// <summary>
        /// Students this instance.
        /// </summary>
        private static void Student()
        {
            SingletonForThreadSafe fromStudent = SingletonForThreadSafe.GetInstance();
            fromStudent.Message("Student Here");
            Console.WriteLine(fromStudent.GetHashCode());
        }
    }
}
