using Microsoft.EntityFrameworkCore;

namespace LocalAuthority.Infrastructure
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

        public virtual DbSet<TnPolitischeGemeinde> TnPolitischeGemeindes { get; set; } = null!;

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
            modelBuilder.Entity<TnPolitischeGemeinde>(entity =>
            {
                entity.HasKey(e => e.PgemId);

                entity.ToTable("tn_PolitischeGemeinde");

                entity.HasIndex(e => e.PgemBezId, "IX_tn_PolitischeGemeinde_bez_Id_with_pgem_Id_BFSCode_Bezeichnung")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.PgemKanId, "IX_tn_PolitischeGemeinde_kan_Id")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.PgemPgem, "UX_pgem")
                    .IsUnique()
                    .HasFillFactor(70);

                entity.Property(e => e.PgemId).HasColumnName("pgem_Id");

                entity.Property(e => e.InsTime)
                    .HasPrecision(0)
                    .HasColumnName("INS_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INS_USER")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.PgemBezId).HasColumnName("pgem_bez_Id");

                entity.Property(e => e.PgemBezeichnung)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("pgem_Bezeichnung");

                entity.Property(e => e.PgemBfscode).HasColumnName("pgem_BFSCode");

                entity.Property(e => e.PgemGueltigAb).HasColumnName("pgem_GueltigAb");

                entity.Property(e => e.PgemGueltigBis).HasColumnName("pgem_GueltigBis");

                entity.Property(e => e.PgemKanId).HasColumnName("pgem_kan_Id");

                entity.Property(e => e.PgemPgem).HasColumnName("pgem_pgem");

                entity.Property(e => e.PgemPregId).HasColumnName("pgem_preg_Id");

                entity.Property(e => e.PgemRaglId).HasColumnName("pgem_ragl_Id");

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
