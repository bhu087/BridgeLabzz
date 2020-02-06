using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
    class ThreadSafeSingalton
    {
        public void Threading()
        {
            Parallel.Invoke(
                () => Teacher(),
                () => Student()
                );

        }
        private static void Teacher()
        {
            Singleton singleton = Singleton.GetInstance();
            singleton.Message("Teacher Here");
            Thread.Sleep(1000);
            Console.WriteLine(singleton.GetHashCode());
        }
        private static void Student()
        {
            Singleton singleton = Singleton.GetInstance();
            singleton.Message("Student Here");
            Console.WriteLine(singleton.GetHashCode());
        }
    }
}
