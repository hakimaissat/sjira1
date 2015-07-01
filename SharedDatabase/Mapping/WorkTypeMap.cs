using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class WorkTypeMap : EntityTypeConfiguration<WorkType>
    {
        public WorkTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkTypeId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("WorkType");
            this.Property(t => t.WorkTypeId).HasColumnName("WorkTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Duration).HasColumnName("Duration");
        }
    }
}
