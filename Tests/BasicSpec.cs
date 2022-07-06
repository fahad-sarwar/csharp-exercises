using System;
using Xunit;

namespace Tests
{
    public class BasicSpec
    {
        [Theory]
        [InlineData(2, 4, 5, 30)]
        [InlineData(3, 6, 35, 315)]
        [InlineData(-12, 5, 17, -119)]
        [InlineData(-40, 50, 60, 600)]
        [InlineData(1.7, 9.9, 0.01, 0.116)]
        public void Add_And_Multiply_Spec(double firstNumber, double secondNumber, double thirdNumber, double result)
            => Assert.Equal(result, Add_And_Multiply(firstNumber, secondNumber, thirdNumber));

        [Theory]
        [InlineData(0, "T = 32F")]
        [InlineData(-300, "Temperature below absolute zero!")]
        [InlineData(28.5, "T = 83.3F")]
        public void Celsius_To_Fahrenheit_Spec(double celsius, string result)
            => Assert.Equal(result, Celsius_To_Fahrenheit(celsius));

        [Theory]
        [InlineData(3, 8, "a + b = 11, a - b = -5, a * b = 24, a / b = 0.375")]
        [InlineData(-375, 25, "a + b = -350, a - b = -400, a * b = -9375, a / b = -15")]
        public void Elementary_Operations_Spec(double firstNumber, double secondNumber, string result)
            => Assert.Equal(result, Elementary_Operations(firstNumber, secondNumber));

        private static double Add_And_Multiply(double firstNumber, double secondNumber, double thirdNumber)
            => Math.Round((firstNumber + secondNumber) * thirdNumber, 3);

        private static string Celsius_To_Fahrenheit(double celsius)
        {
            if (celsius < -273.15)
                return "Temperature below absolute zero!";

            var fahrenheit = Math.Round(celsius * 1.8 + 32, 1);

            return $"T = {fahrenheit}F";
        }

        private static string Elementary_Operations(double firstNumber, double secondNumber)
        {
            var addition = firstNumber + secondNumber;
            var substraction = firstNumber - secondNumber;
            var multiplication = firstNumber * secondNumber;
            var division = firstNumber / secondNumber;

            return $"a + b = {addition}, a - b = {substraction}, a * b = {multiplication}, a / b = {division}";
        }
    }
}
