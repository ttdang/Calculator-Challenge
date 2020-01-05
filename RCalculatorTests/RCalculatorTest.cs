using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCalculator;

namespace RCalculatorTests
{
    [TestClass]
    public class RCalculatorTest
    {
        CalculatorC rc = new CalculatorC();

        [TestMethod]
        public void One_Input()
        {            
            rc.Input_Num("20");
        }

        [TestMethod]
        public void Empty_Input()
        {
            rc.Input_Num("");
        }

        [TestMethod]
        public void Invalid_number()
        {
            rc.Input_Num("5,tytyt");
        }

        [TestMethod]
        public void Exceed_Max_Num()
        {
            rc.Input_Num("4,2,6");
        }

        [TestMethod]
        public void Neg_num()
        {
            rc.Input_Num("4,-3");
        }

        [TestMethod]
        public void No_Max_Num()
        {
            rc.Input_Num("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15");
        }
    }
}
