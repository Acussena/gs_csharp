using gs_csharp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_csharp.src.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserSkill> UserSkills { get; set; } = null!;
        public DbSet<FutureCareer> FutureCareers { get; set; } = null!;
        public DbSet<CareerGapAnalysis> GapAnalyses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // USER ↔ USER SKILLS (1:N)
            // ==============================
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ==============================
            // USER ↔ CAREER GAP ANALYSIS (1:N)
            // ==============================
            modelBuilder.Entity<CareerGapAnalysis>()
                .HasOne(g => g.User)
                .WithMany(u => u.GapAnalyses)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==============================
            // FUTURECAREER ↔ CAREER GAP ANALYSIS (1:N)
            // ==============================
            modelBuilder.Entity<CareerGapAnalysis>()
                .HasOne(g => g.FutureCareer)
                .WithMany(fc => fc.GapAnalyses)
                .HasForeignKey(g => g.FutureCareerId)
                .OnDelete(DeleteBehavior.Cascade);

            // ==============================
            // FUTURECAREER ↔ METASKILLS REMOVIDO
            // ==============================
            // Não há mais N:N, vamos usar apenas a descrição da carreira
        }
    }
}
