using SharedDatabase.Mapping;
using SharedDatabase.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace SharedDatabase
{
    public partial class SolidJira1Context : DbContext
    {
        static SolidJira1Context()
        {
            Database.SetInitializer<SolidJira1Context>(null);
        }

        public SolidJira1Context()
            : base("Name=SolidJira1Context")
        {

        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssuePriority> IssuePriorities { get; set; }
        public DbSet<IssueResolution> IssueResolutions { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new IssuePriorityMap());
            modelBuilder.Configurations.Add(new IssueResolutionMap());
            modelBuilder.Configurations.Add(new IssueTypeMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectCategoryMap());
            modelBuilder.Configurations.Add(new SprintMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new WorkMap());
            modelBuilder.Configurations.Add(new WorkTypeMap());
        }
    }
}
