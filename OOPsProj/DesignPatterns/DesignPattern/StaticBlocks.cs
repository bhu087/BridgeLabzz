
namespace DesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    class StaticBlocks
    {
        public static int Data;

        /// <summary>
        /// Initializes the <see cref="StaticBlocks"/> class.
        /// </summary>
        static StaticBlocks()       ////Static blocks are used to initialize the static elements
            {
                Data =80;
            }

        /// <summary>
        /// Statics the block access.
        /// </summary>
        public void StaticBlockAccess()
        {
            Data -= 10;
            Console.WriteLine(Data);
        }
    }
}
