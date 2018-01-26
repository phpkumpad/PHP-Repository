using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public interface IMemberRepository
    {
        IQueryable<Member> Members { get; }
    }
}
