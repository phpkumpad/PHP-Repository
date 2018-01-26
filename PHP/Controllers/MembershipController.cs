using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHP.Models;

namespace PHP.Controllers
{
    //[Authorize]
    public class MembershipController : Controller
    {
        private IMemberPcpRepository repository;


        public MembershipController(IMemberPcpRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.MemberPcps.OrderBy(m => m.MemberName));

        public ViewResult Edit(long memberPk) => View(repository.MemberPcps.FirstOrDefault(i => i.Pk == memberPk));

        [HttpPost]
        public IActionResult Edit(MemberPcp memberPcp)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMembership(memberPcp);
                TempData["message"] = $"{memberPcp.MemberName} has been saved";
                return RedirectToAction("Index");

            }
            else
            {
                return View(memberPcp);
            }
        }

        public ViewResult Create() => View("Edit", new MemberPcp());

        [HttpPost]
        public IActionResult Delete(long memberPk)
        {
            MemberPcp deleteMembership = repository.DeleteMembership(memberPk);
            if (deleteMembership != null)
            {
                TempData["message"] = $"{deleteMembership.MemberName} was deleted";
            }
            return RedirectToAction("Index");

        }


    }
}
