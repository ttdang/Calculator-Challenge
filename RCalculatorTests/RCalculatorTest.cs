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
            rc.Input_Num("4,-1000");
        }

        [TestMethod]
        public void No_Max_Num()
        {
            rc.Input_Num("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15");
        }

        [TestMethod]
        public void Alternate_Delimiter()
        {
            rc.Input_Num("1,2\n3");
        }

        [TestMethod]
        public void No_Negative_Numbers()
        {
            rc.Input_Num("1,2,3,4,-5,6,7,8,-9,10,11,-12,13,14,15");
        }

        [TestMethod]
        public void custom_delimiter()
        {
            rc.Input_Num("//#\n2#5");
            rc.Input_Num("//,\n2,ff,100");
            rc.Input_Num("//[***]\n11***22***33");
            rc.Input_Num("//[***]\n11***22***33,4");
            rc.Input_Num("//[*][!!][r9r]\n11r9r22*hh*33!!44");
            rc.Input_Num("2,,4,rrrr,1001,6");
        }
    }
}
