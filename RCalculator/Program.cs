﻿using System;
using System.Text.RegularExpressions;

namespace RCalculator
{
    public class CalculatorC
    {
        public int m_total;

        public CalculatorC() {}

        public void Input_Num(string inpNnum)
        {
            string[] calcNum;
            String invalidNum = string.Empty;
            string pattern = @"[//#***!!\r9r\[\],\n]";
            int result;

            // Initialize
            m_total = 0;

            // Get a list of input #
            calcNum = Regex.Split(inpNnum, pattern);

            // Initialize inputNum array
            int[] inputNum = new int[calcNum.Length];

            // Validate user inputs
            for (int i = 0; i <= calcNum.Length - 1; i++)
            {
                //// Display the #
                //Console.WriteLine("Input number: {0}", calcNum[i]);

                // Set to 0 when empty input, missing number or invalid number(s)
                if (calcNum[i] == "" || !int.TryParse(calcNum[i], out result))
                {
                    inputNum[i] = 0;
                }
                else
                {
                    // Get the input #
                    inputNum[i] = Convert.ToInt32(calcNum[i]);

                    // Gather all negative numbers provided for later exception
                    if (inputNum[i] < 0)
                    {
                        if (invalidNum == string.Empty)
                        {
                            invalidNum = calcNum[i];
                        }
                        else
                        {
                            invalidNum = invalidNum + "," + calcNum[i];
                        }
                    }
                    else 
                    {
                        // Skip number that greater than 1000
                        if (inputNum[i] <= 1000)
                        {
                            // Add operation
                            Calculator_Add(inputNum[i]);
                        }
                    }                        
                }
            }

            // throw an exception that includes all of the negative numbers provided
            if (invalidNum != string.Empty)
            {
                throw new ArgumentOutOfRangeException(invalidNum + " No negative number(s) allowed!");
            }
        }

        public int total
        {
            get { return m_total; }
        }
        
        // Calculator Add operation
        public void Calculator_Add (int inputNum)
        {
          m_total   = m_total + inputNum;
        }
        static void Main(string[] args)
        {
            CalculatorC cc = new CalculatorC();

            // Tests
            cc.Input_Num("");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("20");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("4,1000");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("1,5000");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("5,yht");
            Console.WriteLine("Total: {0}", cc.total);

            //cc.Input_Num("1,2,3,-4,5,6,-7,8,9,10,-11,12 ");
            //Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("1\n2,3");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("//#\n2#5");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("//,\n2,ff,100");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("//[***]\n11***22***33");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("//[***]\n11***22***33[***],4");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("//[*][!!][r9r]\n11r9r22*hh*33!!44");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("2,,4,rrrr,1001,6");
            Console.WriteLine("Total: {0}", cc.total);
        }
    }
}
