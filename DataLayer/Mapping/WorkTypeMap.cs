using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DomainClasses.Models;

namespace DataLayer.Mapping
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
