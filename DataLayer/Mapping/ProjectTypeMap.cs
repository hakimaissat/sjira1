using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class ProjectTypeMap : EntityTypeConfiguration<ProjectType>
    {
        public ProjectTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjectTypeId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ProjectType");
            this.Property(t => t.ProjectTypeId).HasColumnName("ProjectTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
