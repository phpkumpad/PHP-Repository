using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public class EFMemberPcpRepository : IMemberPcpRepository
    {
        private PHP_SandboxContext context;

        public EFMemberPcpRepository(PHP_SandboxContext ctx)
        {
            context = ctx;
        }

        public IQueryable<MemberPcp> MemberPcps => context.PcfmembersPcpassigmentDev;

     

        public void SaveMembership(MemberPcp memberPcp)
        {
            if (memberPcp.Pk == 0)
            {
                context.Add(memberPcp);
            }
            else
            {
                MemberPcp dbEntry = context.PcfmembersPcpassigmentDev.FirstOrDefault(p => p.Pk == memberPcp.Pk);

                if (dbEntry != null)
                {
                    dbEntry.MemberId = memberPcp.MemberId;
                    dbEntry.MemberName = memberPcp.MemberName;
                    dbEntry.PcpgrpTaxId = memberPcp.PcpgrpTaxId;
                    dbEntry.PcpgrpName = memberPcp.PcpgrpName;
                    dbEntry.PcpNpi = memberPcp.PcpNpi;
                    dbEntry.PcpName = memberPcp.PcpName;

                }
            }
            context.SaveChanges();

        }

        public MemberPcp DeleteMembership(long memberPk)
        {
            MemberPcp dbEntry = context.PcfmembersPcpassigmentDev.FirstOrDefault(m => m.Pk == memberPk);
            if (dbEntry != null)
            {
                context.PcfmembersPcpassigmentDev.Remove(dbEntry);
                context.SaveChanges();

            }
            return dbEntry;
        }
    }
}
