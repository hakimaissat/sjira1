using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
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

            // Table & Column Mappings
            this.ToTable("Project");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.LeadId).HasColumnName("LeadId");
            this.Property(t => t.ProjectCategoryId).HasColumnName("ProjectCategoryId");
            this.Property(t => t.ProjectTypeId).HasColumnName("ProjectTypeId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.ProjectCategory)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.ProjectCategoryId);
            this.HasOptional(t => t.ProjectType)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.ProjectTypeId);
            this.HasOptional(t => t.ApplicationUser)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.LeadId);

        }
    }
}
