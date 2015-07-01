using SharedDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SharedDatabase.Mapping
{
    public class SprintMap : EntityTypeConfiguration<Sprint>
    {
        public SprintMap()
        {
            // Primary Key
            this.HasKey(t => t.SprintId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Sprint");
            this.Property(t => t.SprintId).HasColumnName("SprintId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DateRange_Start).HasColumnName("DateRange_Start");
            this.Property(t => t.DateRange_End).HasColumnName("DateRange_End");
        }
    }
}
