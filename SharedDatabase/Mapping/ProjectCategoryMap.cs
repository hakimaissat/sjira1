using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class ProjectCategoryMap : EntityTypeConfiguration<ProjectCategory>
    {
        public ProjectCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjectCategoryId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ProjectCategory");
            this.Property(t => t.ProjectCategoryId).HasColumnName("ProjectCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
