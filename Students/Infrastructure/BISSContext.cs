using Microsoft.EntityFrameworkCore;

namespace Students.Infrastructure
{
    public partial class BISSContext : DbContext
    {
        public BISSContext()
        {
        }

        public BISSContext(DbContextOptions<BISSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TLernender> TLernenders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=BISS;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TLernender>(entity =>
            {
                entity.HasKey(e => e.LernId);

                entity.ToTable("t_Lernender");

                entity.HasIndex(e => e.LernErduId, "IX_t_Lernender_erdu_Id")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.LernErduId, "IX_t_Lernender_erdu_Id__lern_Id__lern_pers_Id__lern_staa_Id__lern_sgem_Id")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.LernErduId, e.LernId, e.LernPersId, e.LernStaaId }, "IX_t_Lernender_erdu_Id__lern_Id__lern_pers_Id__lern_staa_Id__plus")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.LernPersId, "IX_t_Lernender_pers_Id")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.LernErduId, e.LernPersId }, "UX_ErhebungsdurchfuehrungPerson")
                    .IsUnique()
                    .HasFillFactor(100);

                entity.Property(e => e.LernId).HasColumnName("lern_Id");

                entity.Property(e => e.InsTime)
                    .HasPrecision(0)
                    .HasColumnName("INS_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INS_USER")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LernAnzahlRepetitionen).HasColumnName("lern_AnzahlRepetitionen");

                entity.Property(e => e.LernAnzahlSpruenge).HasColumnName("lern_AnzahlSpruenge");

                entity.Property(e => e.LernErduId).HasColumnName("lern_erdu_Id");

                entity.Property(e => e.LernImpId).HasColumnName("lern_imp_Id");

                entity.Property(e => e.LernMatchingCode).HasColumnName("lern_MatchingCode");

                entity.Property(e => e.LernPersId).HasColumnName("lern_pers_Id");

                entity.Property(e => e.LernPgemId).HasColumnName("lern_pgem_Id");

                entity.Property(e => e.LernPublAbId).HasColumnName("lern_publ_Ab_Id");

                entity.Property(e => e.LernPublBisId).HasColumnName("lern_publ_Bis_Id");

                entity.Property(e => e.LernSgemId).HasColumnName("lern_sgem_Id");

                entity.Property(e => e.LernStaaId).HasColumnName("lern_staa_Id");

                entity.Property(e => e.LernStatus).HasColumnName("lern_Status");

                entity.Property(e => e.UpdTime)
                    .HasPrecision(0)
                    .HasColumnName("UPD_TIME");

                entity.Property(e => e.UpdUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPD_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
