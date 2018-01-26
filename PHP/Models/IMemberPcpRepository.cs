using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public interface IMemberPcpRepository
    {
        IQueryable<MemberPcp> MemberPcps { get; }

        void SaveMembership(MemberPcp memberPcp);

        MemberPcp DeleteMembership(long memberPk);
    }
    
}
