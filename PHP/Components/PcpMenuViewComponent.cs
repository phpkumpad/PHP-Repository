using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PHP.Models;

namespace PHP.Components
{
    public class PcpMenuViewComponent : ViewComponent
    {

        private IMemberRepository repository;

        public PcpMenuViewComponent(IMemberRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedPcp = RouteData?.Values["pcp"];

            return View(repository.Members
                .Select(x => x.Pcpname)
                .Distinct()
            
                .OrderBy(x => x)

            );
        }   
                
           

       
    }
}
