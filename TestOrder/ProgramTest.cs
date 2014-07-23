using order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOrder
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        
        /// <summary>
        ///A test for InputCustomerOrder
        ///</summary>
        [TestMethod()]
        public void InputCustomerOrderTest()
        {
            dish[] dishes = { new dish("bagel"), new dish("Orange Juice") } ;
            string[] inputString = new string[] {"test", "2", "1", "2"};
            Program.InputCustomerOrder(dishes, inputString);
            Assert.AreEqual(dishes[0].Count, 1);
            Assert.AreEqual(dishes[1].Count, 2);
        }

        /// <summary>
        ///A test for OutputString
        ///</summary>
        [TestMethod()]
        public void OutputStringTest()
        {
            dish[] dishes = { new dish("eggs"), new dish("coffee") };
            dishes[1].AllowMultiple = true;
            string[] inputString = new string[] { "test", "2", "1", "2" };
            string expected = "eggs, coffee(x2)";
            string actual;
            Program.InputCustomerOrder(dishes, inputString);
            actual = Program.OutputString(dishes);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for resetDishCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("order.exe")]
        public void resetDishCountTest()
        {
            dish[] dishes = { new dish("bagel"), new dish("Orange Juice") };
            string[] inputString = new string[] { "test", "2", "1", "2" };
            Program_Accessor.resetDishCount(dishes);
            Assert.AreEqual(dishes[1].Count, 0);
        }
    }
}
