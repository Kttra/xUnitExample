using ratioScaler;

namespace MSTestSample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTest()
        {
            //Arrange - Arrange our values to be setup to run our tests
            int expected = 5;

            //Act - Do the action we're testing
            int actual = Form1.addNum(1, 4);

            //Asset - Compare expected value and the resulting value
            Assert.AreEqual(expected, actual);
        }
        [DataTestMethod]
        [DataRow(4, 3, 7)]
        [DataRow(21, 5, 26)]
        public void MultiTest(int x, int y, int expected)
        {
            //Act - Do the action we're testing
            int actual = Form1.addNum(x, y);

            //Asset - Compare expected value and the resulting value
            Assert.AreEqual(expected, actual);
        }
    }
}