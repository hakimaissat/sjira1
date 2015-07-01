using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class IssueMap : EntityTypeConfiguration<Issue>
    {
        public IssueMap()
        {
            // Primary Key
            this.HasKey(t => t.IssueId);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(500);

            this.Property(t => t.Summary)
                .HasMaxLength(200);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Issue");
            this.Property(t => t.IssueId).HasColumnName("IssueId");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.IssuePriorityId).HasColumnName("IssuePriorityId");
            this.Property(t => t.IssueTypeId).HasColumnName("IssueTypeId");
            this.Property(t => t.IssueResolutionId).HasColumnName("IssueResolutionId");
            this.Property(t => t.TimeOriginalIstimate).HasColumnName("TimeOriginalIstimate");
            this.Property(t => t.Votes).HasColumnName("Votes");
            this.Property(t => t.Watches).HasColumnName("Watches");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasOptional(t => t.IssuePriority)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.IssuePriorityId);
            this.HasOptional(t => t.IssueResolution)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.IssueResolutionId);
            this.HasOptional(t => t.IssueType)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.IssueTypeId);
            this.HasOptional(t => t.Project)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.ProjectId);

        }
    }
}
