using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pizza.Controllers;

namespace Pizza.Tests
{
    [TestFixture]
    public class PizzaSelectionTests
    {
        [Test]
        public void PizzaSelectionPage_LoadsSuccessfully()
        {
            // Arrange
            var controller = new PizzaSelectionController();

            // Act
            var result = controller.PizzaSelection() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("PizzaSelection", result.ViewName);
        }

        // Add more test cases as needed
    }
}
