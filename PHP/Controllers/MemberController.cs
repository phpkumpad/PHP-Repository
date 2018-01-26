using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHP.Infrastructure;
using PHP.Models;
using PHP.Models.ViewModels;


namespace PHP.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository repository;

        public int PageSize = 50;

        private Cart cart;

        public DateTime? batchDate = new DateTime(2017, 12, 04, 0, 0, 0);

        public MemberController(IMemberRepository repo, Cart cartServices)
        {
            repository = repo;
            cart = cartServices;
        }

        // [Authorize]
        public ViewResult List(string pcp, int memberPage = 1)
        =>
            View(new MembersListViewModel
            {

                
                Members = repository.Members
                   
                    .OrderBy(m => m.MemberName)
                    //.Where(d => DateTime.Compare((DateTime) d.FormDate,(DateTime) batchDate) == 1)
                   
                    .Where(p=> pcp== null || p.Pcpname == pcp)
                    
                    .Skip((memberPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = memberPage,
                    ItemsPerPage = PageSize,
                    TotalItems = pcp == null ? repository.Members.Count() : 
                        repository.Members.Count(e => e.Pcpname == pcp)
                },
                CurrentPcp = pcp,
                Cart = cart
            });
 


    }
  
}
