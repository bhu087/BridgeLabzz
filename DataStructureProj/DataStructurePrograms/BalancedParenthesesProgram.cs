﻿//<auto-generated/>
namespace DataStructurePrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is the class for balanced parentheses program
    /// </summary>
    class BalancedParenthesesProgram
    {
        public static void BalancedParentheses()
        {
            Utility BalancedParenthesesUTL = new Utility();
            Console.WriteLine("Enter your Expression");
            //This is our Expression string
            string ExpressionString = Console.ReadLine();
            BalancedParenthesesUTL.BalancedExpression(ExpressionString);
        }
    }
}
