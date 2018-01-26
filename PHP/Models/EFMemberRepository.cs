using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public class EFMemberRepository : IMemberRepository
    {
        private PHP_SandboxContext context;

        public EFMemberRepository(PHP_SandboxContext ctx)
        {
            context = ctx;
        }

        public DateTime? batchDate = new DateTime(2017, 12, 04, 0, 0, 0);


        public IQueryable<Member> Members => context.AttestationMemberListDev
            .Where(p=> p.PcpgrpTaxId == "943199117")
            .Where(d => d.FormDate == batchDate);


    }
}
