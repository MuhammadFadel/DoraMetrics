using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Links> Links{ get; set; }
        public DbSet<Permissions> Permissions{ get; set; }
        public DbSet<AccessInfo> AccessInfos{ get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<MetricData> MetricData { get; set; }               
    }
}
