using Microsoft.AspNetCore.Mvc;
using Pizza.Models;
using System;

namespace Pizza.Controllers
{
    
    public class OrderController : Controller
    {
        public static List<Order> Orders = new List<Order>();
        [HttpGet]
        public IActionResult OrderCheckout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderCheckout(string selectedPizzaType)
        {
            ViewBag.PizzaType = selectedPizzaType;
            return View("OrderCheckout");
        }

        [HttpPost]
        public IActionResult OrderConfirmation(string pizzaType, int quantity)
        {
            // Process order and pass it to Order Confirmation page
            int orderId = GenerateOrderId();

            Orders.Add(new Order
            {
                OrderId = orderId,
                PizzaType = pizzaType,
                Quantity = quantity
            });

            ViewBag.PizzaType = pizzaType;
            ViewBag.Quantity = quantity;
            ViewBag.OrderId = orderId;

            return View("OrderConfirmation");
        }
        public IActionResult ViewOrders()
        {
            return View(Orders);
        }


        private int GenerateOrderId()
        {
            // Logic to generate a unique order ID
            return new Random().Next(1000, 9999);
        }
    }
}