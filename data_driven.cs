using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //---Это нужно для DataDriven тестов---
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        //-------------[/]---------------------

        [TestMethod]
        public void TestSum5And10()
        {
            MyCalc.MyCalc mycalc = new MyCalc.MyCalc();
            double result = mycalc.Sum(5, 10);
            Assert.AreEqual(15,result);
        }

        [TestMethod]
        public void TestDivide4On2()
        {
            MyCalc.MyCalc mycalc = new MyCalc.MyCalc();
            double result = mycalc.Divide(4, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestDivide4On0()
        {
            MyCalc.MyCalc mycalc = new MyCalc.MyCalc();
            try
            {
                double result = mycalc.Divide(4, 0);
                Assert.Fail("Исключение не сгенерированно");
            }
            catch(MyCalc.MyDivideOnZeroException)
            {

            }
            catch(Exception ex)
            {
                Assert.Fail("Исключение сгенерированно некорректно ["+ex.Message+"]");
            }
        }

        [TestMethod]
        [DataRow(1,1,2)]
        [DataRow(2, 8, 10)]
        [DataRow(2,2,4)]
        public void TestSumAandB(double a, double b, double result_expected)
        {
            MyCalc.MyCalc mycalc = new MyCalc.MyCalc();
            double result_actual = mycalc.Sum(a, b);
            Assert.AreEqual(result_expected, result_actual);
        }

        // [DataSource(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Lect20220903\UnitTestProject1_bak\UnitTestProject1\bin\Debug\Tests.accdb", "Test_SumAandB")]
        
        [DataSource(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Lect20220903\UnitTestProject1_bak\UnitTestProject1\bin\Debug\Tests.accdb", "Test_SumAandB")]
        [TestMethod]
        public void DataDriven()
        {
            double a = Convert.ToDouble(TestContext.DataRow["a"]);
            double b = Convert.ToDouble(TestContext.DataRow["b"]);
            double result_expected = Convert.ToDouble(TestContext.DataRow["result_expected"]);
            MyCalc.MyCalc mycalc = new MyCalc.MyCalc();
            double result_actual = mycalc.Sum(a, b);
            Assert.AreEqual(result_expected, result_actual);
        }
    }
}
