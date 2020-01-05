using System;

namespace RCalculator
{
    public class CalculatorC
    {
        public int m_total;

        public CalculatorC() {}

        public void Input_Num(string inpNnum)
        {
            string[] calcNum;
            int result;

            // Initialize
            m_total = 0;

            // get the list of #
            calcNum = inpNnum.Split(',');

            // Initialize inputNum array
            int[] inputNum = new int[calcNum.Length];

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
                    // Add operation
                    Calculator_Add(inputNum[i]);
                }

            }
        }
        public int total
        {
            get { return m_total; }
        }
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

            cc.Input_Num ("20");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("4,-3");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("1,5000");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("5,yht");
            Console.WriteLine("Total: {0}", cc.total);

            cc.Input_Num("1,2,3,4,5,6,7,8,9,10,11,12 ");
            Console.WriteLine("Total: {0}", cc.total);
        }
    }
}
