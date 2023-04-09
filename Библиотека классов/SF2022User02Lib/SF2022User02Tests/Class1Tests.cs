using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF2022User02Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SF2022User02Lib.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void MinAVGTest()
        {
            double expected = 5;
            string[] marks = new string[] { "5", "5", "5" };
            double actual = SF2022User02Lib.Class1.MinAVG(marks);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalculateAverage()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            // Act
            double result = Class1.CalculateAverage(numbers);

            // Assert
            Assert.AreEqual(3, result, 0.001); // Проверка на точность до трёх знаков после запятой
        }
        [TestMethod()]
        public void ReturnZero()
        {
            double expected = 0;
            string[] marks = new string[] {};
            double actual = SF2022User02Lib.Class1.MinAVG(marks);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            int result = a + b;

            // Assert
            Assert.AreEqual(result, 15);
        }
        [TestMethod]
        public void ReverseString_WithValidInput_ReturnsReversedString()
        {
            // Arrange
            string str = "hello";
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);
            string expectedOutput = "olleh";


            // Act
            string actualOutput = reversedStr;

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestAddTime()
        {
            // Arrange
            MyTime t1 = new MyTime(1, 30);
            MyTime t2 = new MyTime(0, 45);

            // Act
            MyTime result = t1 + t2;

            // Assert
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }



    }
}