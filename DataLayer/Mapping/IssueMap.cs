using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
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
            this.Property(t => t.Environment).HasColumnName("Environment");
            this.Property(t => t.Attachement).HasColumnName("Attachement");
            this.Property(t => t.Labels).HasColumnName("Labels");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.IssuePriorityId).HasColumnName("IssuePriorityId");
            this.Property(t => t.IssueTypeId).HasColumnName("IssueTypeId");
            this.Property(t => t.IssueResolutionId).HasColumnName("IssueResolutionId");
            this.Property(t => t.TimeOriginalIstimate).HasColumnName("TimeOriginalIstimate");
            this.Property(t => t.AssigneeId).HasColumnName("AssigneeId");
            this.Property(t => t.ReporterId).HasColumnName("ReporterId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Votes).HasColumnName("Votes");
            this.Property(t => t.Watches).HasColumnName("Watches");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

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

            this.HasOptional(t => t.Assignee)
                .WithMany(t => t.AssigneeIssues)
                .HasForeignKey(d => d.AssigneeId);

            this.HasOptional(t => t.Status)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.StatusId);

            this.HasOptional(t => t.Reporter)
                .WithMany(t => t.ReporterIssues)
                .HasForeignKey(d => d.ReporterId);

        }
    }
}
