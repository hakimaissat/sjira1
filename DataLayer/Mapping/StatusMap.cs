using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            // Primary Key
            this.HasKey(t => t.StatusId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Status");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Name).HasColumnName("StatusName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
        }
    }
}
