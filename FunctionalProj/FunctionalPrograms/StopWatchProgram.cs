﻿// <auto-generated/>
namespace FunctionalPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is the Stop watch timer program
    /// </summary>
    class StopWatchProgram
    {
        public static void SopWatch()
        {
            Utility StopWatchUTL = new Utility();
            TimeSpan ts = StopWatchUTL.StopWatchUtility();
            Console.WriteLine("it is in the format of HH:MM:SS " + ts.ToString(@"hh\:mm\:ss"));
        }

    }

}

