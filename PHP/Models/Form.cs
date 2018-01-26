using System;
using System.Collections.Generic;

namespace PHP.Models
{
    public partial class Form
    {
        public string FormId { get; set; }
        public DateTime FormDate { get; set; }
        public string FormCategory { get; set; }
        public string PcpgrpTaxId { get; set; }
        public string MemberId { get; set; }
        public double? Coefficient { get; set; }
        public string Hcc { get; set; }
        public string Hccdescription { get; set; }
        public string Icdcode { get; set; }
        public string Icddescription { get; set; }
        public int? Icdorder { get; set; }
        public string MeasureId { get; set; }
        public string MeasureDescription { get; set; }
        public int? MeasureOrder { get; set; }
        public DateTime? ProviderReportDate { get; set; }
        public string ProviderId { get; set; }
        public string ProviderNpi { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSpecialty { get; set; }
        public long FormPk { get; set; }
    }
}
