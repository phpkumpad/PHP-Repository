using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PHP.Models;

namespace PHP.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartServices)
        {
            cart = cartServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);

        }
    }
}
