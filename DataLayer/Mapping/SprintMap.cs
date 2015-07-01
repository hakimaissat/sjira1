using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
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
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.BoardId).HasColumnName("BoardId");

            // Relationships
            this.HasOptional(t => t.Board)
                .WithMany(t => t.Sprints)
                .HasForeignKey(d => d.BoardId);

        }
    }
}
