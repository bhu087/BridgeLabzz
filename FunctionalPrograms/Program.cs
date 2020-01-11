﻿// <auto-generated/>
namespace FunctionalPrograms
{
    using System;

    /// <summary>
    /// This is the main program for selecting the Functional programs
    /// </summary>
    class Program
    {

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Option\n1 for Anagram for array of strings" +
                "\n2 for String Replace\n3 for Flip Coin\n4 for Leap Year" +
                "\n5 for power of two\n6 for Hormonic Number\n7 for Factors for " +
                "\n8 for Two dimensional Array\n9 for Distance from (0,0) to (X,Y)" +
                "\n10 for finding roots of Quadratic equation\n11 for Wind chill" +
                "\n12 for tic tac Toe program\n13 for playing Gambler Game" +
                "\n14 for Coupon generation\n15 for Stop Watch\n16 for Few Number of Notes Count" +
                "\n17 for Day of the week\n18 for Temperature Conversion (F -> C) or (C -> F)");
            int Option = int.Parse(Console.ReadLine());
            switch (Option)
            {
                case 1:
                    Anagram.Anagrams();
                    break;
                case 2:
                    StringReplaceProgram.StringReplace();
                    break;
                case 3:
                    FlipCoinProgram.FlipCoin();
                    break;
                case 4:
                    LeapYearProgram.LeapYear();
                    break;
                case 5:
                    PowerOfTwoProgram.PowerOfTwo();
                    break;
                case 6:
                    HormonicNumberProgram.Hormonic();
                    break;
                case 7:
                    FactorsProgram.Factors();
                    break;
                case 8:
                    TwoDArrayProgram.TwoDArray();
                    break;
                case 9:
                    DistanceFind.Distance();
                    break;
                case 10:
                    QuadraticEquationProgram.Quadratic();
                    break;
                case 11:
                    WindChillProgram.WindChill();
                    break;
                case 12:
                    TicTacToeProgram.TicTacToe();
                    break;
                case 13:
                    GamblerProgram.Gambler();
                    break;
                case 14:
                    CouponNumberProgram.CouponNumber();
                    break;
                case 15:
                    StopWatchProgram.SopWatch();
                    break;
                case 16:
                    FewNumberOfNotesProgram.FewNumberOfNotes();
                    break;
                case 17:
                    DayOfWeekProgram.DayOfTheWeek();
                    break;
                case 18:
                    TemperatureConversionProgram.TemperatureConversion();
                    break;
                default:
                    Console.WriteLine("You are selecting invalid option");
                    break;
            }
        }
    }
}
