using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class WorkMap : EntityTypeConfiguration<Work>
    {
        public WorkMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Work");
            this.Property(t => t.WorkId).HasColumnName("WorkId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.IssueId).HasColumnName("IssueId");
            this.Property(t => t.SprintId).HasColumnName("SprintId");
            this.Property(t => t.AssignerId).HasColumnName("AssignerId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.TimeWorked).HasColumnName("TimeWorked");
            this.Property(t => t.WorkTypeId).HasColumnName("WorkTypeId");

            // Relationships
            this.HasOptional(t => t.Issue)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.IssueId);
            this.HasOptional(t => t.Sprint)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.SprintId);
            this.HasOptional(t => t.Status)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.StatusId);
            this.HasOptional(t => t.UserProfile)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.AssignerId);
            this.HasOptional(t => t.WorkType)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.WorkTypeId);

        }
    }
}
