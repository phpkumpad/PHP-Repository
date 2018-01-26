using System;
using System.Collections.Generic;

namespace PHP.Models
{
    public partial class Member
    {

        public string FileName()
        {

            string member = MemberName.Replace(",", "");
            return "/Documents/_Latest PCF/" + PcpgrpName+ "/" + member + " - " + FormId + ".pdf";
        }

        

        public DateTime? FormDate { get; set; }
        public string FormId { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime? Dob { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string HomePhone { get; set; }
        public string PcpgrpTaxId { get; set; }
        public string PcpgrpName { get; set; }
        public string PcpId { get; set; }
        public string PcpNpi { get; set; }
        public string Pcpname { get; set; }
        public string Hicn { get; set; }
        public string Hcontract { get; set; }
        public string Region { get; set; }
        public string Pbp { get; set; }
        public string RaftypeCode { get; set; }
        public string Orec { get; set; }
        public string DefaultRiskFactorCode { get; set; }
        public string CurrMcaidStatus { get; set; }
        public string Esrd { get; set; }
        public string Lti { get; set; }
        public string Hospice { get; set; }
        public string CmsRaScore { get; set; }
        public int? RaAge { get; set; }
        public string RaAgeBand { get; set; }
        public string RaSex { get; set; }
        public string RaOrec { get; set; }
        public string RaMembPopSegment { get; set; }
        public DateTime? CyEnrFromDt { get; set; }
        public DateTime? CyEnrThruDt { get; set; }
        public int? CyMcaidMm { get; set; }
        public int? CyMm { get; set; }
        public DateTime? PlanEnrollDt { get; set; }
        public int? PlanMm { get; set; }
        public int? TotOffVis { get; set; }
        public DateTime? LastOffVis { get; set; }
        public int? TotPcpvis { get; set; }
        public DateTime? LastPcpvis { get; set; }
        public DateTime? LastCpe { get; set; }
        public string CpeProvName { get; set; }
        public int? Cc2015 { get; set; }
        public int? Cc2016 { get; set; }
        public int? Cc2017 { get; set; }
        public int? HistCccount { get; set; }
        public int? HistIcdcount { get; set; }
        public double? HistCoefficientSum { get; set; }
        public int? CmsCount { get; set; }
        public double? CmscoefficientSum { get; set; }
        public int? QualityCount { get; set; }
        public int? SuspectCount { get; set; }
        public int? ScreeningCount { get; set; }
        public double CoefficientSum { get; set; }
        public int? CronicCondCount { get; set; }
        public int? TotalGapCount { get; set; }
        public int? Cpecount { get; set; }
        public int Payable { get; set; }
        public double? P4p { get; set; }
        public int? QualitySort { get; set; }

        
    }
}
