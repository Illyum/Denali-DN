using Denali.Business.ArsScientia;
using Denali.Web.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Denali.UnitTests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        private DiscountCalculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new DiscountCalculator();
        }

        [TestMethod]
        public void DiscountForFirstPurchaseShouldBe15()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddYears(-22),
                FirstPurchaseDate = null
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.15m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiscountForEmployeeShouldBe10()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddYears(-26),
                IsEmployee = true,
                FirstPurchaseDate = DateTime.Today
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.10m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiscountForSeniorShouldBe5()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddYears(-65).AddSeconds(-1),
                FirstPurchaseDate = DateTime.Today.AddDays(-1)
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.05m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiscountForBirthdayShouldBe10()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddYears(-22),
                FirstPurchaseDate = DateTime.Today
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.10m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiscountFor5YearLoyaltyShouldBe12()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddDays(-26),
                FirstPurchaseDate = DateTime.Today.AddYears(-5)
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.12m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiscountFor5YearLoyaltyAndBirthdayShouldBe22()
        {
            // Arrange
            var customer = new Customer()
            {
                Birthday = DateTime.Today.AddYears(-26),
                FirstPurchaseDate = DateTime.Today.AddYears(-5)
            };

            // Act
            var actual = _calculator.CalculateDiscountPercentage(customer);

            // Assert
            var expected = 0.22m;
            Assert.AreEqual(expected, actual);
        }
    }
}
