using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PHP.Models
{
    public partial class PHP_SandboxContext : DbContext
    {
        public PHP_SandboxContext(DbContextOptions<PHP_SandboxContext> options) : base(options) { }

        public virtual DbSet<Form> AttestationFormDetailsDev { get; set; }
        public virtual DbSet<Member> AttestationMemberListDev { get; set; }
        public virtual DbSet<MemberPcp> PcfmembersPcpassigmentDev { get; set; }
        public virtual DbSet<QualityCompleted> QualityMeasuresCompletedDev { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=PHPL118\SQLSERVERLOCAL;Database=PHP_Sandbox;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasKey(e => e.FormPk);

                entity.ToTable("AttestationFormDetails_dev", "MARisk");

                entity.Property(e => e.FormPk).HasColumnName("Form_Pk");

                entity.Property(e => e.FormCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormDate).HasColumnType("date");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Hcc)
                    .HasColumnName("HCC")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Hccdescription)
                    .HasColumnName("HCCDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icdcode)
                    .HasColumnName("ICDCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Icddescription)
                    .HasColumnName("ICDDescription")
                    .HasMaxLength(255);

                entity.Property(e => e.Icdorder).HasColumnName("ICDOrder");

                entity.Property(e => e.MeasureDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MeasureId)
                    .HasColumnName("MeasureID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PcpgrpTaxId)
                    .HasColumnName("PCPGrpTaxID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderId)
                    .HasColumnName("ProviderID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderNpi)
                    .HasColumnName("ProviderNPI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderReportDate).HasColumnType("date");

                entity.Property(e => e.ProviderSpecialty)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("AttestationMemberList_dev", "MARisk");

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cc2015).HasColumnName("CC_2015");

                entity.Property(e => e.Cc2016).HasColumnName("CC_2016");

                entity.Property(e => e.Cc2017).HasColumnName("CC_2017");

                entity.Property(e => e.CmsCount).HasColumnName("CMS_count");

                entity.Property(e => e.CmsRaScore)
                    .HasColumnName("CMS_RA_Score")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CmscoefficientSum).HasColumnName("CMSCoefficientSum");

                entity.Property(e => e.CpeProvName)
                    .HasColumnName("CPE_ProvName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpecount).HasColumnName("CPECount");

                entity.Property(e => e.CurrMcaidStatus)
                    .HasColumnName("CurrMCaidStatus")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CyEnrFromDt)
                    .HasColumnName("CY_EnrFromDt")
                    .HasColumnType("date");

                entity.Property(e => e.CyEnrThruDt)
                    .HasColumnName("CY_EnrThruDt")
                    .HasColumnType("date");

                entity.Property(e => e.CyMcaidMm).HasColumnName("CY_MCaidMM");

                entity.Property(e => e.CyMm).HasColumnName("CY_MM");

                entity.Property(e => e.DefaultRiskFactorCode)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Esrd)
                    .HasColumnName("ESRD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FormDate).HasColumnType("date");

                entity.Property(e => e.Hcontract)
                    .HasColumnName("HContract")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Hicn)
                    .HasColumnName("HICN")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HistCccount).HasColumnName("HistCCCount");

                entity.Property(e => e.HistIcdcount).HasColumnName("HistICDCount");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Hospice)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastCpe)
                    .HasColumnName("Last_CPE")
                    .HasColumnType("date");

                entity.Property(e => e.LastOffVis).HasColumnType("date");

                entity.Property(e => e.LastPcpvis)
                    .HasColumnName("LastPCPVis")
                    .HasColumnType("date");

                entity.Property(e => e.Lti)
                    .HasColumnName("LTI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Orec)
                    .HasColumnName("OREC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.P4p).HasColumnName("P4P");

                entity.Property(e => e.Pbp)
                    .HasColumnName("PBP")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PcpId)
                    .HasColumnName("PCP_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcpNpi)
                    .HasColumnName("PCP_NPI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PcpgrpName)
                    .HasColumnName("PCPGrpName")
                    .HasMaxLength(100);

                entity.Property(e => e.PcpgrpTaxId)
                    .HasColumnName("PCPGrpTaxID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pcpname)
                    .HasColumnName("PCPName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlanEnrollDt)
                    .HasColumnName("Plan_EnrollDt")
                    .HasColumnType("date");

                entity.Property(e => e.PlanMm).HasColumnName("Plan_MM");

                entity.Property(e => e.RaAge).HasColumnName("RA_Age");

                entity.Property(e => e.RaAgeBand)
                    .HasColumnName("RA_AgeBand")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RaMembPopSegment)
                    .HasColumnName("RA_MembPopSegment")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.RaOrec)
                    .HasColumnName("RA_OREC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RaSex)
                    .HasColumnName("RA_Sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RaftypeCode)
                    .HasColumnName("RAFTypeCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TotPcpvis).HasColumnName("TotPCPVis");
            });

            modelBuilder.Entity<MemberPcp>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("PCFMembersPCPAssigment_dev", "MARisk");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PcpId)
                    .HasColumnName("PCP_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcpNpi)
                    .HasColumnName("PCP_NPI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PcpgrpName)
                    .HasColumnName("PCPGrpName")
                    .HasMaxLength(100);

                entity.Property(e => e.PcpgrpTaxId)
                    .HasColumnName("PCPGrpTaxID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PcpName)
                    .HasColumnName("PCPName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualityCompleted>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("QualityMeasuresCompleted_dev", "MARisk");

                entity.Property(e => e.Comments).HasMaxLength(255);

                entity.Property(e => e.Dos)
                    .HasColumnName("DOS")
                    .HasColumnType("date");

                entity.Property(e => e.MeasureId)
                    .HasColumnName("MeasureID")
                    .HasMaxLength(20);

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasMaxLength(50);

                entity.Property(e => e.MemberName).HasMaxLength(255);
            });
        }
    }
}
