using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pizza.Controllers;

namespace Pizza.Tests
{
    [TestFixture]
    public class OrderConfirmationTests
    {
        [Test]
        public void OrderConfirmationPage_LoadsSuccessfully()
        {
            // Arrange
            var controller = new OrderController();
            var pizzaType = "Pepperoni";
            var quantity = 2;

            // Act
            var result = controller.OrderConfirmation(pizzaType, quantity) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("OrderConfirmation", result.ViewName);
        }
    }
}