using Microsoft.EntityFrameworkCore;
using Project.Domain.Conditions;
using Project.Domain.Doctors;
using Project.Domain.Company;
using Project.Persistence.Data.Configurations;
using Project.Domain.News;

namespace Project.Persistence.Data
{
    public class OogArtsDbContext : DbContext
    {
        public OogArtsDbContext(DbContextOptions<OogArtsDbContext> options) : base(options) { }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<NewsArticle> News { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConditionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NewsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
        }
    }
}
