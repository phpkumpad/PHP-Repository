using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public class FakeMemberRepository : IMemberRepository
    {
        public IQueryable<Member> Members => new List<Member>
        {
            new Member
            {
                FormId = "N000001002-20171204",
                MemberId = "N000001002",
                MemberName = "Gustafson, Dean",
                PcpgrpName = "Ralston Medical",
                Pcpname = "Zamboni, Shannon",
                CoefficientSum = 0.568,
                TotalGapCount = 12
            },
            new Member
            {
                FormId = "N000001004-20171204",
                MemberId = "N000001004",
                MemberName = "Greene, Carol",
                PcpgrpName = "Complete Family Care",
                Pcpname = "Yco, Newton",
                CoefficientSum = 0.595,
                TotalGapCount = 8
            },

        }.AsQueryable<Member>();
    }
}
