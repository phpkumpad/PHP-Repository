using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PHP.Models.ViewModels
{
    public class MembersListViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentPcp { get; set; }
        public Cart Cart { get; set; }
    }
}
