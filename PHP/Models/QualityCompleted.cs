using System;
using System.Collections.Generic;

namespace PHP.Models
{
    public partial class QualityCompleted
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MeasureId { get; set; }
        public DateTime? Dos { get; set; }
        public string Comments { get; set; }
        public long Pk { get; set; }
    }
}
