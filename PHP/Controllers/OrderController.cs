using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PHP.Models;

namespace PHP.Controllers
{
    public class OrderController : Controller
    {
        private Cart cart;

        public OrderController(Cart cartService)
        {
            cart = cartService;
        }

        public ViewResult Download() => View(cart);

        [HttpPost]
        public IActionResult Download(Cart cart)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            
            
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Completed));
            }
            else return View(cart);

            
            
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

    }
}
