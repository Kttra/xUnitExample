# An Example of using xUnit
This repo will provide an example and instructions to use xunit for unit testing. In my example, I will be using xunit for a .NET 6 windows application.

So let's say my main form that I want to test looks like this:
```csharp
using System;
using System.Windows.Forms;
namespace ratioScaler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int addNum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
```
In this file, we can see the name space is ratioScaler and the function we want to test is called addNum. The funciton addNum is inside of the Form1 class. Let's make sure to remember this for later.

To add the xunit file, we need to right click on our solution, hover over add, and press on new project.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671531-03fbe36e-3cdb-41fb-bc61-3cce8a35230e.png" width = "700", height = "524"><img>
</p>

Then we want to search for xunit and press on xUnit Test Project. You can name the project whatever you want, in my example, I have named it TestProject1.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671563-0be40ff2-0a2d-47df-a767-270ebd4a5dfc.png" width = "700", height = "410"><img>
</p>

After adding the test project, we need to add a reference to the project we want to test. We begin by right clicking on TestProject1, then going to add, and pressing on project reference.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671600-46c88f24-2b65-42b2-99d1-fb19717e6882.png" width = "600", height = "620"><img>
</p>

Afterwards, we check the project we want to test. In this example, we will check ratioScaler.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671632-4b7a6aea-aa85-4b94-a0f0-4bbd4e150247.png" width = "600", height = "414"><img>
</p>

Now under our test project, there will be a file named "UnitTest1.cs". We will want to open that file. At the top we want to make sure to add "using ratioScaler" because that was the namespace of the project we want to test. When we call methods from the ratioScaler namespace, we start with "Form1." because the method is located within that class in this example. I will not go into detail how write the tests as this guide is really more to set up and give an example of a xunit test.

```csharp
using Xunit;
using ratioScaler;

namespace TestProject1
{
    public class UnitTest1
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
```
As for running the tests. Just right click on the solution and press run tests. To see the results, look at the test explorer.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169672022-ab562967-70aa-45f5-b60a-ab673486bfbb.png"><img>
</p>


**Cannot be Referenced Error**
--------------------
If you run into an error that looks similar to what is shown below, make sure to change the target framework and target OS in the test project properties.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671864-e51da387-459f-49e6-a194-39121668e20d.png"><img>
</p>

# An Example of using MSTest
This half of the project will go over unit testing using MSTest. MSTest is one type of framework that provides the facility to test code without using any third-party tool.

**Creating a MSTest**
--------------
Creating a MSTest project file is similar to creating a XUnit project file. We right click on our solution and add a new project.
<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/171320878-2205d5d0-5645-412c-bafa-99e2d09066d8.png" width = "600" height = "494"><img>
</p>

Then we search for MSTest and select the MSTest Test Project from the list of projects.
<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/171321154-8a4fc9e3-e56b-4007-bb56-1e4eab2945e5.png"><img>
</p>

For this example, I will name my project "MSTestSample". We need to right click on the MSTest solution to add the original project as a reference.
<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/171321475-940a71ec-dc15-447e-bedb-79433d6367a0.png" width = "600" height = "467"><img>
</p>
Then we just select the project we want to test.
<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/169671632-4b7a6aea-aa85-4b94-a0f0-4bbd4e150247.png" width = "600", height = "414"><img>
</p>

You may need to restart visual studio for the added reference to update. You may also need to make sure to change the target framework to match the project you are testing. For the most part, MSTest is similar to XUnit, so I won't be explaining what's going on below.

```cs
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
```
