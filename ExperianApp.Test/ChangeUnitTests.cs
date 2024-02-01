namespace ExperianApp.Test
{
    [TestClass]
    public class ChangeUnitTests
    {
        [TestMethod]
        public void TestChangeCorrect()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(20, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { (20.0m, 1) }, changeResult);
        }

        [TestMethod]
        public void TestChangeCorrect2()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(82.5m, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { (50.0m, 1), (20.0m, 1), (10.0m, 1), (2m, 1), (0.5m, 1) }, changeResult);
        }

        [TestMethod]
        public void TestChangeCorrect3()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(82.5m, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { (50.0m, 1), (20.0m, 1), (10.0m, 1), (2m, 1), (0.5m, 1) }, changeResult);
        }

        [TestMethod]
        public void TestChangeCorrect4()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(14.3m, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { (10.0m, 1), (2m, 2), (0.2m, 1), (0.1m, 1) }, changeResult);
        }

        [TestMethod]
        public void TestChangeNegativeValue()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(-5, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { }, changeResult);
        }


        [TestMethod]
        public void TestChangeTooSmallValue()
        {
            var strategy = new UKMoneyStrategy();
            var changeCommand = new CalculateChangeCommand();

            var changeResult = changeCommand.Calculate(0.0005m, strategy).ToArray();
            CollectionAssert.AreEqual(new (decimal, int)[] { }, changeResult);
        }

        [TestMethod]
        public void TestChangeDecimalMax()
        {
            try
            {
                var strategy = new UKMoneyStrategy();
                var changeCommand = new CalculateChangeCommand();

                var changeResult = changeCommand.Calculate(Decimal.MaxValue, strategy).ToArray();
                Assert.Fail("An exception should have been thrown");
            }
            catch (OverflowException ex)
            {
                Assert.AreEqual("Value was either too large or too small for an Int32.", ex.Message);
            }
           
        }
    }
}