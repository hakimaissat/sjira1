using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using DomainClasses.Models;

namespace DataLayer.Mapping
{
    public class ComponentMap : EntityTypeConfiguration<Component>
    {
        public ComponentMap()
        {
            // Primary Key
            this.HasKey(t => t.ComponentId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Component");
            this.Property(t => t.ComponentId).HasColumnName("ComponentId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
