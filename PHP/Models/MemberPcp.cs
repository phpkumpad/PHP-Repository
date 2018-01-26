using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PHP.Models
{
    public partial class MemberPcp
    {
        [Required(ErrorMessage = "Please Enter Member ID")]
        public string MemberId { get; set; }

        [Required(ErrorMessage = "Please Enter Member Name")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Please Enter PCP Group Tax ID")]
        public string PcpgrpTaxId { get; set; }

        [Required(ErrorMessage = "Please Enter PCP Group Name")]
        public string PcpgrpName { get; set; }

        
        public string PcpId { get; set; }

        [Required(ErrorMessage = "Please Enter PCP NPI")]
        public string PcpNpi { get; set; }

        [Required(ErrorMessage = "Please Enter PCP Name")]
        public string PcpName { get; set; }

    
        public long Pk { get; set; }
    }
}
