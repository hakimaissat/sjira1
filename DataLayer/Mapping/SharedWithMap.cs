using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class SharedWithMap : EntityTypeConfiguration<SharedWith>
    {
        public SharedWithMap()
        {
            // Primary Key
            this.HasKey(t => t.SharedWithId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SharedWith");
            this.Property(t => t.SharedWithId).HasColumnName("SharedWithId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
