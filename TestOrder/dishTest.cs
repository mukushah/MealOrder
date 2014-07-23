using order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOrder
{
    
    
    /// <summary>
    ///This is a test class for dishTest and is intended
    ///to contain all dishTest Unit Tests
    ///</summary>
    [TestClass()]
    public class dishTest
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
        ///A test for dish Constructor
        ///</summary>
        [TestMethod()]
        public void dishConstructorTest()
        {
            string name = "eggs";
            dish target = new dish(name);
            Assert.AreEqual(target.Name, name);
        }

        /// <summary>
        ///A test for AddDish
        ///</summary>
        [TestMethod()]
        public void AddDishTest()
        {
            string name = "stake";
            dish target = new dish(name);
            target.AddDish();
            Assert.AreEqual(target.Count, 1);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string name = "coffee";
            dish target = new dish(name);
            target.AllowMultiple = true;
            target.AddDish();
            target.AddDish();
            string expected = "coffee(x2)";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for isValid
        ///</summary>
        [TestMethod()]
        public void isValidTest()
        {
            string name = "toast";
            dish target = new dish(name);
            target.AllowMultiple = false;
            target.AddDish();
            target.AddDish();
            bool expected = false;
            bool actual;
            actual = target.isValid();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for resetDishCount
        ///</summary>
        [TestMethod()]
        public void resetDishCountTest()
        {
            string name = "bagel";
            dish target = new dish(name);
            target.AddDish();
            target.resetDishCount();
            Assert.AreEqual(target.Count, 0);
        }

        /// <summary>
        ///A test for AllowMultiple
        ///</summary>
        [TestMethod()]
        public void AllowMultipleTest()
        {
            string name = string.Empty;
            dish target = new dish(name);
            bool expected = false;
            bool actual;
            target.AllowMultiple = expected;
            actual = target.AllowMultiple;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            string name = string.Empty;
            dish target = new dish(name);
            int expected = 10;
            int actual;
            target.Count = expected;
            actual = target.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string name = "";
            dish target = new dish(name);
            string expected = "cake";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
