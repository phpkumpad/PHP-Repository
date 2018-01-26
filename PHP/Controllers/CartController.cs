using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PHP.Models;
using PHP.Models.ViewModels;
using PHP.Infrastructure;

namespace PHP.Controllers
{
    public class CartController : Controller
    {
        private IMemberRepository repository;

        private Cart cart;

        public CartController(IMemberRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel {Cart = cart, ReturnUrl = returnUrl});

        }

        public RedirectToActionResult AddToCart(string formId, string returnUrl)
        {
            Member member = repository.Members
                .FirstOrDefault(m => m.FormId == formId);

            if (member != null)
            {
                cart.AddItem(member);
                
            }
            return RedirectToAction("Index", new { returnUrl });


        }

        public RedirectToActionResult RemoveFromCart(string formId, string returnUrl)
        {
            Member member = repository.Members
                .FirstOrDefault(m => m.FormId == formId);

            if (member != null)
            {
                cart.RemoveLine(member);
                
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        
    }
}
