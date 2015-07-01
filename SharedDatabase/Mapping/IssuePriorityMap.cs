using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class IssuePriorityMap : EntityTypeConfiguration<IssuePriority>
    {
        public IssuePriorityMap()
        {
            // Primary Key
            this.HasKey(t => t.IssuePriorityId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.IconUrl)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("IssuePriority");
            this.Property(t => t.IssuePriorityId).HasColumnName("IssuePriorityId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.IconUrl).HasColumnName("IconUrl");
        }
    }
}
