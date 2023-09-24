using NUnit.Framework;
using Pizza.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Pizza.Tests
{
    [TestFixture]
    public class OrderCheckoutTests
    {
        [Test]
        public void OrderCheckoutPage_LoadsSuccessfully()
        {
            // Arrange
            var controller = new OrderController();

            // Act
            var result = controller.OrderCheckout("Margherita") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("OrderCheckout", result.ViewName);
        }
    }
}