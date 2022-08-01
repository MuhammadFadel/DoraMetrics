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

        public DbSet<Group> Groups { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Links> Links{ get; set; }
        public DbSet<Permissions> Permissions{ get; set; }
        public DbSet<AccessInfo> AccessInfos{ get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<JiraIssueEvent> JiraIssueEvents { get; set; }
        public DbSet<Changelog> Changelogs { get; set; }                         
        public DbSet<Creator> Creators { get; set; }                         
        public DbSet<Fields> Fields { get; set; }                                       
        public DbSet<Issue> Issues { get; set; }                                       
        public DbSet<Issuetype> Issuetypes { get; set; }                                       
        public DbSet<Item> Items { get; set; }                                       
        public DbSet<Priority> Prioritys { get; set; }                                       
        public DbSet<Reporter> Reporters { get; set; }                                       
        public DbSet<Status> Status { get; set; }                                       
        public DbSet<StatusCategory> StatusCategories { get; set; }                                       
        public DbSet<User> Users { get; set; }                                       
        public DbSet<Watches> Watches { get; set; }                                                        
    }
}
