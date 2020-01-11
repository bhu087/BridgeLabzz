﻿// <auto-generated/>
namespace FunctionalPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// This is the Utility class for Functional programs
    /// </summary>
    class Utility
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StringsCount"></param>
        //Anagram Utility
        public void StoringToArray(int StringsCount)
        {
            //This string array for storing strings
            String[] StringArray = new String[StringsCount];
            //this is the duplicate array to show the string while displaying
            String[] TempStringArray = new string[StringsCount];
            //This line asks for entering the StringsCount Arrays
            Console.WriteLine("Enter {0} a string and press enter key after every String", StringsCount);
            //it stores the strings in array
            for (int i = 0; i < StringsCount; i++)
            {
                StringArray[i] = Console.ReadLine();
                TempStringArray[i] = StringArray[i];
            }

            Console.WriteLine("Your Strings Anagrams List below");
            //In this block all the strings are in sorted order
            for (int i = 0; i < StringsCount; i++)
            {
                String TempString = StringArray[i];
                //converting to character array
                char[] CharectorArray = TempString.ToCharArray();
                //sort a char array
                Array.Sort(CharectorArray);
                //store back to string position
                StringArray[i] = new string(CharectorArray);
            }
            //this compares the strimgs and if matches then display the position and anagram values
            for (int i = 0; i < StringsCount - 1; i++)
            {
                for (int j = i + 1; j < StringsCount; j++)
                {
                    if (StringArray[i].Equals(StringArray[j]))
                    {
                        Console.WriteLine("{0}th value {1} have a {2} anagram at {3}th position", i + 1, TempStringArray[i], TempStringArray[j], j + 1);
                    }
                }
            }
        }

        //Integer check if given input is integer it gives the number else
        //it returns -1
        public int IntInput()
        {
            bool Success = Int32.TryParse(Console.ReadLine(), out int Number);
            if (Success)
            {
                return Number;
            }
            else
            {
                Console.WriteLine("you entered non integer value");
                return -1;
            }
        }

        //FlipCoin Utility
        public float FlipCoinUtility(int Value)
        {
            //tails and heads counts are zero initially
            float TailsCount = 0;
            float HeadsCount = 0;
            for (int i = 0; i < Value; i++)
            {
                Random random = new Random();
                //Randomly generate a value between 0.0 to 1.0
                //if random value is below 0.5 it increases tails count else heads
                if ((float)random.Next(10) / 10 > 0.5)
                {
                    TailsCount++;
                }
                else
                {
                    HeadsCount++;
                }
            }
            Console.WriteLine("tails count is " + TailsCount);
            Console.WriteLine("heads count is " + HeadsCount);
            //Heads vs Tails percentage
            float ans = ((HeadsCount / TailsCount) * 100);
            return ans;
        }

        //Leap Year utility
        public bool IsLeapYear(int YearIs)
        {
            //remainder is zero it returns zero but it the yera is multiples of 100
            // and that should satisfy for year % 400 is 0
            if (YearIs % 4 == 0)
            {
                if (YearIs % 100 == 0)
                {
                    if (YearIs % 400 == 0)
                    {
                        return true;
                    }
                    return false;
                }
                    return true;
            }
            else
            {
                return false;
            }
        }

        //This is for checking given number is 4 digit or not
        public bool IsFourDigit(int Number)
        {
            if (Number > 999 && Number < 10000)
            {
                return true;
            }
            else
                return false;
        }

        //Hormonic Number Utility
        //Hormonic Number Utility
        public float HormonicUtility(int Num)
        {
            float Ans = 0F;
            float Temp;
            for (int i = 1; i <= Num; i++)
            {
                Temp = i;
                Ans += (1 / Temp);
            }
            return Ans;
        }

        //Utility for Finding Factors
        public void FactrosUtility(int Number)
        {
            int Count=0;
            //it checks the factors for a give number is any factors available between
            //(2 to Number/2)
            for (int i = 2; i <= Number / 2; i++)
            {
                if (Number % i == 0)
                {
                    Console.WriteLine(i);
                    Count++;
                }
            }
            if (Count == 0)
            {
                Console.WriteLine("No Factors are available for {0}",Number);
            }
        }

        //Two D Array Utility
        public void TwoDArrayUtility(int m, int n)
        {
            //a[][] is a two dimensional array
            int[,] a = new int[m, n];
            //stores the m X n elements
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Enter " + i + "th row " + j + "th column value");
                    a[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            //print it Here
            Console.WriteLine("Your 2D array is");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        //Quadratic Equation Utility
        public void FindRoots(double a, double b, double c)
        {
            double Delta = ((b * b) - (4 * a * c));
            double rePart, imPart;
            double root1, root2;
            if (Delta > 0)
            {       //roots are real and different ex:1,6,5
                root1 = ((-b + Math.Sqrt(Delta)) / (2 * a));
                root2 = ((-b - Math.Sqrt(Delta)) / (2 * a));
                Console.WriteLine("root1 = {0:0.00}, root2 = {1:0.00}", root1, root2);
            }
            if (Delta == 0)
            {   //roots are same ex:1,-2,1
                root1 = ((-b / (2 * a)));
                root2 = root1;
                Console.WriteLine("root1 = {0:0.00}, root2 = {1:0.00}", root1, root2);
            }
            if (Delta < 0)
            {       //roots are imaginary ex:1,-3,10
                rePart = ((-b / (2 * a)));
                imPart = Math.Sqrt(-Delta / (2 * a));
                Console.WriteLine("root1 = {0:0.00}+{1:0.00}i and root2 = {0:0.00}+{1:0.00}i", rePart, imPart, rePart, imPart);
            }
        }

        //Wind Chill Utility program
        public double WindChillUtility(double Temp, double Vel)
        {
            if (!(Temp > 50 || Vel > 120 || Vel < 3))
            {

                double Wind = (35.74 + 0.6215 * Temp + (0.4275 * Temp - 35.75) * Math.Pow(Vel, 0.16));
                return Wind;
            }
            else
                return -1;
        }

        //Tic Tac Toe Play Control
        public void TicTakToeControl()
        {
            Random random = new Random();
            int turns = 9;
            char[] a = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };

            
                if (random.Next(10) > 5)
                {
                    User1Playing();
                }
                else
                    User2Playing();
            

            void User1Playing()
            {
                Console.WriteLine("Enter a position user 1 (0 to 8)");
                goto User1Home;
            US1:
                Console.WriteLine("Enter a Correct/Anethor position user 1 (0 to 8)");
            User1Home: try
                {
                    int i = int.Parse(Console.ReadLine());

                    if (turns > 0)
                    {
                        if (a[i] == '-')
                        {
                            a[i] = 'O';
                            turns--;
                            if (GameCheck('O'))
                            {
                                Console.WriteLine("User 1 Wins");
                                Displaying();
                                Ending();
                            }
                            Displaying();
                            if (turns > 0)
                            {
                                User2Playing();
                            }
                            else
                            {
                                Displaying();
                                Console.WriteLine("No one wins");
                                Ending();
                            }

                        }
                        else
                        {
                            goto US1;
                        }
                    }
                }
                catch (Exception)
                {
                    goto US1;
                }
            }

            void User2Playing()
            {
                Console.WriteLine("Enter a position user 2 (0 to 8)");
                goto User2Home;
            US2:
                Console.WriteLine("Enter a Correct/Anethor position User 2 (0 to 8)");
            User2Home: try
                {
                    int i = int.Parse(Console.ReadLine());
                    if (turns > 0)
                    {
                        if (a[i] == '-')
                        {
                            a[i] = 'X';
                            turns--;
                            if (GameCheck('X'))
                            {
                                Console.WriteLine("User 2 Wins");
                                Displaying();
                                Ending();
                            }
                            Displaying();
                            if (turns > 0)
                            {
                                User1Playing();
                            }
                            else
                            {
                                Displaying();
                                Console.WriteLine("No one wins");
                                Ending();
                            }
                        }
                        else
                        {
                            goto US2;
                        }
                    }
                }
                catch (Exception)
                {
                    goto US2;
                }
            }
            bool GameCheck(char s)
            {
                if (((a[0] == a[1]) && (a[1] == a[2]) && (a[2] == s)) || (a[3] == a[4]) && (a[4] == a[5]) && (a[5] == s) || (a[6] == a[7]) && (a[7] == a[8]) && (a[8] == s)
                        || (a[0] == a[3]) && (a[3] == a[6]) && (a[6] == s) || (a[1] == a[4]) && (a[4] == a[7]) && (a[7] == s) || (a[2] == a[5]) && (a[5] == a[8]) && (a[8] == s) ||
                        (a[0] == a[4]) && (a[4] == a[8]) && (a[8] == s) || (a[2] == a[4]) && (a[4] == a[6]) && (a[6] == s))
                {
                    return true;
                }
                else
                    return false;
            }
            void Displaying()
            {

                Console.WriteLine("{0} {1} {2}", a[0], a[1], a[2]);
                Console.WriteLine("{0} {1} {2}", a[3], a[4], a[5]);
                Console.WriteLine("{0} {1} {2}", a[6], a[7], a[8]);
            }
            void Ending()
            {
                Console.WriteLine("Thank you for playing\nDo you want to play again press 1 else any Number");
                try
                {
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        TicTakToeControl();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    Environment.Exit(0);
                }
            }
        }

        //Gambler BL
        public void GamblerPlaying()
        {
            Console.WriteLine("Enter your Stake");
            int stake = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your goal");
            int goal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter trails");
            int trails = Int32.Parse(Console.ReadLine());
            GamblerPlay(trails, stake, goal);

        }

        //Gambler Utility program
        public void GamblerPlay(int trails, int stake, int goal)
        {
            int Wins = 0, Bets = 0;
            float Bets1 = 0, Wins1 = 0;
            Random random = new Random();
            for (int i = 0; i < trails; i++)
            {
                int Cash = stake;
                while (Cash > 0 && Cash < goal)
                {
                    Bets++;
                    if (random.Next(10) < 5)
                    {
                        //Console.WriteLine(random.Next(10));
                        Cash++;
                    }
                    else
                        //Console.WriteLine(random.Next(10));
                        Cash--;
                }
                if (Cash >= goal)
                {
                    Wins++;
                    Console.WriteLine("Win at " + i + "th Game");
                }
            }
            Bets1 = Bets;
            Wins1 = Wins;
            Console.WriteLine("Number of Wins " + Wins);
            Console.WriteLine("Number of Bets " + Bets);
            Console.WriteLine("wins percentage " + ((Wins1 / Bets1) * 100));
            Console.WriteLine("loss percentage " + ((Bets1 - Wins1) / Bets1) * 100);

        }
    }
}
