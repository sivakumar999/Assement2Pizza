using Microsoft.AspNetCore.Mvc;

namespace Pizza.Controllers
{
    public class PizzaSelectionController : Controller
    {
        public IActionResult PizzaSelection()
        {
            return View("PizzaSelection");
        }

        [HttpPost]
        public IActionResult OrderCheckout(string pizzaType)
        {
            // Process pizza selection and pass it to Order Checkout page
            return RedirectToAction("OrderCheckout", "Order", new { pizzaType });
        }
    }
}
