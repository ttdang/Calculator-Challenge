using System;

namespace RCalculator
{
    public class CalculatorC
    {
        public int m_total = 0;

        public CalculatorC() {}

        public void Input_Num(string inpNnum)
        {
            string[] calcNum;
            int[] inputNum = new int[2];
            int result;

            // get the list of #
            calcNum = inpNnum.Split(',');

            // Validation: Only 2 numbers allows
            if (calcNum.Length > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(calcNum), "The Calculator only support a maximum of 2 numbers");
            }

            // Validate user inputs
            for (int i = 0; i <= calcNum.Length - 1; i++)
            {
                // Display the #
                Console.WriteLine("Input number: {0}", calcNum[i]);

                // Set to 0 when empty input, missing number or invalid number(s)
                if (calcNum[i] == "" || !int.TryParse(calcNum[i], out result))
                {
                    inputNum[i] = 0;
                }
                else
                {
                    inputNum[i] = Convert.ToInt32(calcNum[i]);
                }

            }

            // Add operation
            Calculator_Add(inputNum);

        }
        public int total
        {
            get { return m_total; }
        }
        public void Calculator_Add (int[] inputNum)
        {
          m_total   = inputNum[0] + inputNum[1];
        }
        static void Main(string[] args)
        {
            CalculatorC cc = new CalculatorC();

            // Tests
            cc.Input_Num("");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num ("20");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("4,-3");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("1,5000");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("5,yht");
            Console.WriteLine("Total: {0}", cc.total);

        }
    }
}
