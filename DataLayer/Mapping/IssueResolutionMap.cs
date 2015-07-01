using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class IssueResolutionMap : EntityTypeConfiguration<IssueResolution>
    {
        public IssueResolutionMap()
        {
            // Primary Key
            this.HasKey(t => t.IssueResolutionId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.IconUrl)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("IssueResolution");
            this.Property(t => t.IssueResolutionId).HasColumnName("IssueResolutionId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.IconUrl).HasColumnName("IconUrl");
        }
    }
}
