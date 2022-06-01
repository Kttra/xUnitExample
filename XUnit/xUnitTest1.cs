using Xunit;
using ratioScaler;

namespace TestProject1
{
    public class xUnitTest1
    {
        //Fact = this is a test, Method name_what should happen
        [Fact]
        public void Test1()
        {
            //Arrange - Arrange our values to be setup to run our tests
            int expected = 5;

            //Act - Do the action we're testing
            int actual = Form1.addNum(1, 4);

            //Asset - Compare expected value and the resulting value
            Assert.Equal(expected, actual);
        }
        //Let's us pass in data, and run a test multiple times with different datasets
        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(21, 5, 26)]
        public void Add_SimpleValuesShouldCalculate(int x, int y, int expected)
        {
            //Act - Do the action we're testing
            int actual = Form1.addNum(x, y);

            //Asset - Compare expected value and the resulting value
            Assert.Equal(expected, actual);
        }
    }
}