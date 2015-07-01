using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjectId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Project");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LeadId).HasColumnName("LeadId");
            this.Property(t => t.ProjectCategoryId).HasColumnName("ProjectCategoryId");
            this.Property(t => t.TimeOriginalIstimate).HasColumnName("TimeOriginalIstimate");

            // Relationships
            this.HasOptional(t => t.ProjectCategory)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.ProjectCategoryId);
            this.HasOptional(t => t.UserProfile)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.LeadId);

        }
    }
}
